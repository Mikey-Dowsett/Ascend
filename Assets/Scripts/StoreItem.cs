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

    public void OnClick()
    {
        displayStoreItem.ShowItem(itemImage, title, unlocked, this, cost, type);
    }

    public void Unlock()
    {
        unlocked = true;
        lockedImage.SetActive(false);
        PlayerPrefs.SetInt(title + UNLOCKSTRING, 1);
        PlayerPrefs.Save();
    }
}
