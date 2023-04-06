using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
Sets the icons for the balloon, defender, background, and the theme for the obstacles.
*/
public class IconManager : MonoBehaviour
{
    const string BALLOON = "BalloonSprite";
    const string DEFENDER = "DefenderSprite";
    const string BACKGROUND = "BackgroundSprite";
    const string OBSTACLE = "ObstacleColor";
    const string TRAIL = "TrailMaterial";

    [SerializeField] SpriteRenderer balloonSR;
    [SerializeField] SpriteRenderer defenderSR;
    [SerializeField] SpriteRenderer backgroundSR;
    [SerializeField] TrailRenderer trailMatObj;

    public Color32 color = new Color32(255, 255, 255, 255);

    //Load visual configurations for balloon, background, obstacle, and trail.
    void Awake()
    {
        if (PlayerPrefs.HasKey(BALLOON))
        {
            balloonSR.sprite = Resources.Load<Sprite>("Art/Balloon/" + PlayerPrefs.GetString(BALLOON));
        }
        if (PlayerPrefs.HasKey(DEFENDER))
        {
            defenderSR.sprite = Resources.Load<Sprite>("Art/Defender/" + PlayerPrefs.GetString(DEFENDER));
        }
        if (PlayerPrefs.HasKey(BACKGROUND))
        {
            backgroundSR.sprite = Resources.Load<Sprite>("Art/Background/" + PlayerPrefs.GetString(BACKGROUND));
        }
        if (PlayerPrefs.HasKey(OBSTACLE))
        {
            string[] newColor = (PlayerPrefs.GetString(OBSTACLE)).Remove(0, 5).Split(",");
            color = new Color32(byte.Parse(newColor[0]), byte.Parse(newColor[1]), byte.Parse(newColor[2]), 255);
        }
        if (PlayerPrefs.HasKey(TRAIL))
        {
            trailMatObj.material = Resources.Load<Material>("Art/Trail/" + PlayerPrefs.GetString(TRAIL));
        }
    }

    public void SetBalloon(Sprite newSprite)
    {
        balloonSR.sprite = newSprite;
        PlayerPrefs.SetString(BALLOON, newSprite.name);
    }

    public void SetDefender(Sprite newSprite)
    {
        defenderSR.sprite = newSprite;
        PlayerPrefs.SetString(DEFENDER, newSprite.name);
    }

    public void SetBackground(Sprite newSprite)
    {
        backgroundSR.sprite = newSprite;
        PlayerPrefs.SetString(BACKGROUND, newSprite.name);
    }

    public void SetObstacle(Color newColor)
    {
        color = newColor;
        PlayerPrefs.SetString(OBSTACLE, color.ToString());
    }

    public void SetTrail(Material mat)
    {
        trailMatObj.material = mat;
        string[] matName = mat.ToString().Split(' ');
        PlayerPrefs.SetString(TRAIL, matName[0]);
    }
}
