using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

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
    [SerializeField] GameObject deathUI;
    [SerializeField] GameObject respawnButton;
    [SerializeField] TMP_Text respawnText;

    private bool hasRespawned;
    private bool gameStarted;

    public void Update()
    {
        if (Input.GetMouseButton(0) && !gameStarted)
        {
            BeginGame();
            gameStarted = true;
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
        if (FindObjectOfType<DisplayStoreItem>()) FindObjectOfType<DisplayStoreItem>().SelectStoreMenu(0);
        menuUI.SetActive(true);
        storeUI.SetActive(false);
        settingsUI.SetActive(false);
    }

    public void OpenSettings()
    {
        menuUI.SetActive(false);
        settingsUI.SetActive(true);
    }

    public void DeathScreen()
    {
        deathUI.SetActive(true);
        if (hasRespawned) respawnButton.SetActive(false);
    }

    public void Respawn()
    {
        deathUI.SetActive(false);
        respawnText.text = "Tap to Continue";
        FindObjectOfType<Balloon>().Respawn();
        hasRespawned = true;
    }

    public void ReloadScene()
    {
        SceneManager.LoadScene(0);
    }
}
