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
    [SerializeField] Image itemImage;
    [SerializeField] TMP_Text title;
    [SerializeField] Button selectButton;
    [SerializeField] Button unlockButton;
    [SerializeField] TMP_Text unlockCost;

    [SerializeField] IconManager iconManager;
    [SerializeField] TMP_SpriteAsset coinAsset;

    BalloonStoreItem balloonStoreItem;

    //Shows the balloon item onto the display
    public void ShowBalloonItem(Sprite _itemImage, string _title, bool unlocked, BalloonStoreItem bsi, int price)
    {
        itemImage.sprite = _itemImage;
        title.text = _title;
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
        balloonStoreItem = bsi;

        string[] temp = unlockCost.text.Split(' ');
        unlockCost.text = $"{temp[0]} {temp[1]} {temp[2]} {price}";
    }

    //Sets the selected balloon to be the new icon.
    public void SelectBalloonItem()
    {
        iconManager.SetBalloon(itemImage.sprite);
    }

    public void UnlockItem()
    {
        balloonStoreItem.Unlock();
        selectButton.interactable = true;
        unlockButton.interactable = false;
    }
}
