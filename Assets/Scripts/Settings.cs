using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Settings : MonoBehaviour
{
    [SerializeField] Sprite soundON, soundOFF;
    [SerializeField] Sprite musicON, musicOFF;
    [SerializeField] Sprite hapticON, hapticOFF;
    [SerializeField] Sprite notificationsON, notificationsOFF;

    [SerializeField] Image soundImg, musicImg, hapticImg, notificationImg;

    public bool sound = true,
        music = true,
        haptic = true,
        notifications = true;

    public void ToggleSound()
    {
        sound = !sound;
        soundImg.sprite = sound ? soundON : soundOFF;
        foreach (AudioSource audioS in GameObject.FindObjectsOfType<AudioSource>())
        {
            if (audioS.CompareTag("Sound")) audioS.enabled = sound;
            if (audioS.CompareTag("Enemy")) audioS.enabled = sound;
        }
    }

    public void ToggleMusic()
    {
        music = !music;
        musicImg.sprite = music ? musicON : musicOFF;
    }

    public void ToggleHaptic()
    {
        haptic = !haptic;
        hapticImg.sprite = haptic ? hapticON : hapticOFF;
    }

    public void ToggleNotifications()
    {
        notifications = !notifications;
        notificationImg.sprite = notifications ? notificationsON : notificationsOFF;
    }
}
