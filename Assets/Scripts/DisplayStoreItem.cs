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
    [SerializeField] TMP_SpriteAsset coinAsset;

    [SerializeField] GameObject[] storeMenus;
    [SerializeField] StoreItem[] defaultItems;

    StoreItem storeItem;
    string type = "";
    int curStoreMenu;
    int price;

    //Shows the balloon item onto the display
    public void ShowItem(Sprite _itemImage, string _title, bool unlocked, StoreItem si, int _price, string _itemType)
    {
        itemImage.sprite = _itemImage;
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
        }

    }

    public void UnlockItem()
    {
        if (scoreObj.SpendCoin(price))
        {
            storeItem.Unlock();
            selectButton.interactable = true;
            unlockButton.interactable = false;
        }

    }

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
