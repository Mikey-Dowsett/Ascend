using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Settings : MonoBehaviour
{
    [SerializeField] Sprite soundON, soundOFF;
    [SerializeField] Sprite musicON, musicOFF;
    [SerializeField] Sprite hapticON, hapticOFF;
    [SerializeField] Sprite notificationsON, notificationsOFF;

    [SerializeField] Image soundImg, musicImg, hapticImg, notificationImg;
    [SerializeField] GameObject confirmDisplay;

    public bool sound = true,
        music = true,
        haptic = true,
        notifications = true;

    private void Start()
    {
        if (PlayerPrefs.GetString("SOUND") == "False") ToggleSound();
        if (PlayerPrefs.GetString("MUSIC") == "False") ToggleMusic();
        if (PlayerPrefs.GetString("HAPTIC") == "False") ToggleHaptic();
        if (PlayerPrefs.GetString("NOTIFICATIONS") == "False") ToggleNotifications();
    }

    public void ToggleSound()
    {
        sound = !sound;
        soundImg.sprite = sound ? soundON : soundOFF;
        foreach (AudioSource audioS in GameObject.FindObjectsOfType<AudioSource>())
        {
            if (audioS.CompareTag("Sound")) audioS.enabled = sound;
            if (audioS.CompareTag("Enemy")) audioS.enabled = sound;
        }
        PlayerPrefs.SetString("SOUND", sound.ToString());
    }

    public void ToggleMusic()
    {
        music = !music;
        musicImg.sprite = music ? musicON : musicOFF;
        GameObject.FindGameObjectWithTag("Music").GetComponent<AudioSource>().enabled = music;
        PlayerPrefs.SetString("MUSIC", music.ToString());
    }

    public void ToggleHaptic()
    {
        haptic = !haptic;
        hapticImg.sprite = haptic ? hapticON : hapticOFF;
        PlayerPrefs.SetString("HAPTIC", haptic.ToString());
    }

    public void ToggleNotifications()
    {
        notifications = !notifications;
        notificationImg.sprite = notifications ? notificationsON : notificationsOFF;
        PlayerPrefs.SetString("NOTIFICATIONS", notifications.ToString());
    }

    public void DeleteSave()
    {
        if (!confirmDisplay.activeSelf)
            confirmDisplay.SetActive(true);
        else
        {
            confirmDisplay.SetActive(false);
            PlayerPrefs.DeleteAll();
            SceneManager.LoadScene(0);
        }
    }

    public void CancelDeleteSave()
    {
        confirmDisplay.SetActive(false);
    }
}
