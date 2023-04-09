using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

/*
Displays the selected item onto the screen in the store
*/
public class DisplayStoreItem : MonoBehaviour
{
    const string DEFAULTBALLOON = "DefaultBalloon",
                 DEFAULTDEFENDER = "DefaultDefender",
                 DEFAULTBACKGROUND = "DefaultBackground",
                 DEFAULTOBSTACLE = "DefaultObstacle",
                 DEFAULTTRAIL = "DefaultTrail";

    [SerializeField] Score scoreObj;
    [SerializeField] Image itemImage;
    [SerializeField] TMP_Text title;
    [SerializeField] Button selectButton;
    [SerializeField] Button unlockButton;
    [SerializeField] TMP_Text unlockCost;

    [SerializeField] IconManager iconManager;

    [SerializeField] GameObject[] storeMenus;
    [SerializeField] Image[] storeButtons;
    [SerializeField] StoreItem[] defaultItems;

    [SerializeField] Color selectedButtonColor;
    [SerializeField] Color unselectedButtonColor;

    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip[] goodBadAudio;

    StoreItem storeItem;
    StoreItem oldStoreItem;
    string type = "";
    int curStoreMenu;
    int price;

    private void Start()
    {
        BlipMenus(true);
        if (PlayerPrefs.HasKey(DEFAULTBALLOON))
            defaultItems[0] = GameObject.Find(PlayerPrefs.GetString(DEFAULTBALLOON)).GetComponent<StoreItem>();
        if (PlayerPrefs.HasKey(DEFAULTDEFENDER))
            defaultItems[1] = GameObject.Find(PlayerPrefs.GetString(DEFAULTDEFENDER)).GetComponent<StoreItem>();
        if (PlayerPrefs.HasKey(DEFAULTBACKGROUND))
            defaultItems[2] = GameObject.Find(PlayerPrefs.GetString(DEFAULTBACKGROUND)).GetComponent<StoreItem>();
        if (PlayerPrefs.GetString(DEFAULTOBSTACLE).Length > 2)
            defaultItems[3] = GameObject.Find(PlayerPrefs.GetString(DEFAULTOBSTACLE)).GetComponent<StoreItem>();
        if (PlayerPrefs.HasKey(DEFAULTTRAIL))
            defaultItems[4] = GameObject.Find(PlayerPrefs.GetString(DEFAULTTRAIL)).GetComponent<StoreItem>();
        BlipMenus(false);
        foreach (StoreItem item in defaultItems)
        {
            item.ChangeFrame(0);
        }

        storeMenus[0].SetActive(true);
        oldStoreItem = storeItem = defaultItems[0];
        storeItem.OnClick();
    }

    //Shows the balloon item onto the display
    public void ShowItem(Sprite _itemImage, Color32 color, Material trailMat, string _title, bool unlocked, StoreItem si, int _price, string _itemType)
    {
        itemImage.sprite = _itemImage;
        itemImage.color = color;
        itemImage.material = trailMat;
        title.text = _title;
        price = _price;
        if (unlocked)
        {
            selectButton.interactable = true;
            unlockButton.interactable = false;
        }
        else
        {
            selectButton.interactable = false;
            unlockButton.interactable = true;
        }
        storeItem = si;
        type = _itemType;

        unlockCost.text = !unlocked ? $"<sprite index=0>{price}" : "Unlocked";
    }

    //Sets the selected balloon to be the new icon.
    public void SelectItem()
    {
        storeItem.ChangeFrame(0);
        if (oldStoreItem) oldStoreItem.ChangeFrame(1);
        oldStoreItem = storeItem;
        switch (type)
        {
            case "1": //Ballon
                iconManager.SetBalloon(itemImage.sprite);
                PlayerPrefs.SetString(DEFAULTBALLOON, title.text);
                break;
            case "2": //Background
                iconManager.SetBackground(itemImage.sprite);
                PlayerPrefs.SetString(DEFAULTBACKGROUND, title.text);
                break;
            case "3": //Obstacle
                iconManager.SetObstacle(itemImage.color);
                PlayerPrefs.SetString(DEFAULTOBSTACLE, title.text);
                break;
            case "4": //Trail
                iconManager.SetTrail(itemImage.material);
                PlayerPrefs.SetString(DEFAULTTRAIL, title.text);
                break;
            case "5": //Defender
                iconManager.SetDefender(itemImage.sprite);
                PlayerPrefs.SetString(DEFAULTDEFENDER, title.text);
                break;
        }
        PlayerPrefs.Save();
    }
    //Unlocks the selected item.
    public void UnlockItem()
    {
        if (scoreObj.SpendCoin(price))
        {
            storeItem.Unlock();
            selectButton.interactable = true;
            unlockButton.interactable = false;
            audioSource.clip = goodBadAudio[0];
            if (audioSource.enabled) audioSource.Play();
        }
        else
        {
            audioSource.clip = goodBadAudio[1];
            if (audioSource.enabled) audioSource.Play();
        }

    }

    private void ResetMenus()
    {
        for (int i = 0; i < storeMenus.Length; i++)
        {
            storeMenus[i].SetActive(false);
            storeButtons[i].color = unselectedButtonColor;
        }
    }

    //Scrolls through the store menus.
    public void SelectStoreMenu(int menuNum)
    {
        ResetMenus();
        storeMenus[menuNum].SetActive(true);
        storeButtons[menuNum].color = selectedButtonColor;
        defaultItems[menuNum].OnClick();
        oldStoreItem = defaultItems[menuNum];
    }

    private void BlipMenus(bool status)
    {
        foreach (GameObject menu in storeMenus)
        {
            menu.SetActive(status);
        }
    }
}
