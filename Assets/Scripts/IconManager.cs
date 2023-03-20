using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
Sets the icons for the balloon, defender, background, and the theme for the obstacles.
*/
public class IconManager : MonoBehaviour
{
    [SerializeField] SpriteRenderer balloonSR;
    [SerializeField] SpriteRenderer backgroundSR;

    public void SetBalloon(Sprite newSprite)
    {
        balloonSR.sprite = newSprite;
    }

    public void SetBackground(Sprite newSprite)
    {
        backgroundSR.sprite = newSprite;
        print("SR Set");
    }
}
