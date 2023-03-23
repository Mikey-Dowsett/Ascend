using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
Controls the menus.
*/
public class StartGame : MonoBehaviour
{
    [SerializeField] Player player;
    [SerializeField] GameObject menuUI;
    [SerializeField] GameObject gameUI;
    [SerializeField] GameObject storeUI;
    [SerializeField] GameObject settingsUI;

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            PlayerPrefs.DeleteAll();
        }
    }

    public void BeginGame()
    {
        menuUI.SetActive(false);
        gameUI.SetActive(true);
        player.StartGame();
    }

    public void OpenStore()
    {
        menuUI.SetActive(false);
        storeUI.SetActive(true);
    }

    public void CloseStore()
    {
        menuUI.SetActive(true);
        storeUI.SetActive(false);
        settingsUI.SetActive(false);
    }

    public void OpenSettings()
    {
        menuUI.SetActive(false);
        settingsUI.SetActive(true);
    }
}
