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
    [SerializeField] Score scoreObj;
    [SerializeField] Image itemImage;
    [SerializeField] TMP_Text title;
    [SerializeField] Button selectButton;
    [SerializeField] Button unlockButton;
    [SerializeField] TMP_Text unlockCost;

    [SerializeField] IconManager iconManager;

    [SerializeField] GameObject[] storeMenus;
    [SerializeField] StoreItem[] defaultItems;

    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip[] goodBadAudio;

    StoreItem storeItem;
    string type = "";
    int curStoreMenu;
    int price;

    private void Start()
    {
        defaultItems[0].OnClick();
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

        string[] temp = unlockCost.text.Split(' ');
        unlockCost.text = $"{temp[0]} {temp[1]} {price}";
    }

    //Sets the selected balloon to be the new icon.
    public void SelectItem()
    {
        switch (type)
        {
            case "1": iconManager.SetBalloon(itemImage.sprite); break;
            case "2": iconManager.SetBackground(itemImage.sprite); break;
            case "3": iconManager.SetObstacle(itemImage.color); break;
            case "4": iconManager.SetTrail(itemImage.material); break;
            case "5": iconManager.SetDefender(itemImage.sprite); break;
        }

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
    //Scrolls through the store menus.
    public void NextStoreMenu(int dir)
    {
        storeMenus[curStoreMenu].SetActive(false);
        curStoreMenu += dir;

        if (curStoreMenu >= storeMenus.Length)
            curStoreMenu = 0;
        else if (curStoreMenu <= -1)
            curStoreMenu = storeMenus.Length - 1;

        storeMenus[curStoreMenu].SetActive(true);
        defaultItems[curStoreMenu].OnClick();
    }
}
