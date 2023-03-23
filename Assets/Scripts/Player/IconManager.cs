using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
Sets the icons for the balloon, defender, background, and the theme for the obstacles.
*/
public class IconManager : MonoBehaviour
{
    const string BALLOON = "BalloonSprite";
    const string BACKGROUND = "BackgroundSprite";

    [SerializeField] SpriteRenderer balloonSR;
    [SerializeField] SpriteRenderer backgroundSR;

    void Start()
    {
        if (PlayerPrefs.HasKey(BALLOON))
        {
            Sprite sp = Resources.Load<Sprite>("Art/Balloon/" + PlayerPrefs.GetString(BALLOON));
            balloonSR.sprite = sp;
        }
        if (PlayerPrefs.HasKey(BACKGROUND))
        {
            Sprite sp = Resources.Load<Sprite>("Art/Background/" + PlayerPrefs.GetString(BACKGROUND));
            backgroundSR.sprite = sp;
        }
    }

    public void SetBalloon(Sprite newSprite)
    {
        balloonSR.sprite = newSprite;
        PlayerPrefs.SetString(BALLOON, newSprite.name);
    }

    public void SetBackground(Sprite newSprite)
    {
        backgroundSR.sprite = newSprite;
        PlayerPrefs.SetString(BACKGROUND, newSprite.name);
    }
}
