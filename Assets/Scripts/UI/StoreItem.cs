using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
Script for each balloon image store item.
Saves unlocked state
*/
public class StoreItem : MonoBehaviour
{
    const string UNLOCKSTRING = "LockedState";

    [SerializeField] Sprite itemImage;
    [SerializeField] string title;
    [SerializeField] bool unlocked;
    [SerializeField] DisplayStoreItem displayStoreItem;
    [SerializeField] int cost;
    [SerializeField] string type;
    [SerializeField] Color color = Color.white;
    [SerializeField] Material trailMat = null;

    [SerializeField] GameObject lockedImage;

    //Save if it's unlocked or not
    void Start()
    {
        if (PlayerPrefs.GetInt(title + UNLOCKSTRING) == 1 || unlocked)
        {
            unlocked = true;
        }
        else
        {
            unlocked = false;
        }
        lockedImage.SetActive(!unlocked ? true : false);
    }
    //Displays the item in the store menu.
    public void OnClick()
    {
        displayStoreItem.ShowItem(itemImage, color, trailMat, title, unlocked, this, cost, type);
    }
    //Permantly unlocks the item.
    public void Unlock()
    {
        unlocked = true;
        lockedImage.SetActive(false);
        PlayerPrefs.SetInt(title + UNLOCKSTRING, 1);
        PlayerPrefs.Save();
    }
}
