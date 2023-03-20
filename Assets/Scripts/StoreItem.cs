using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
Script for each balloon image store item.
Saves unlocked state
*/
public class StoreItem : MonoBehaviour
{
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
    }
}
