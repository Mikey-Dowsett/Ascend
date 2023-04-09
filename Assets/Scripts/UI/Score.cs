using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

/*
Saves the highscore, displays current score
*/
public class Score : MonoBehaviour
{
    [SerializeField] TMP_Text gameScoreText;
    [SerializeField] TMP_Text highScoreText;
    [SerializeField] TMP_Text gameCoinsText;
    [SerializeField] TMP_Text storeCoinsText;

    int highscore;
    int score;
    int coins;

    Transform playerTransfrom;
    void Start()
    {
        highscore = PlayerPrefs.GetInt("Highscore");
        highScoreText.text = $"Highscore\n{highscore}";

        coins = PlayerPrefs.GetInt("Coins");
        gameCoinsText.text = coins.ToString();
        storeCoinsText.text = coins.ToString();

        playerTransfrom = GameObject.Find("Balloon").transform;
    }

    // Update is called once per frame
    void Update()
    {
        //Updates the score based on the players height
        score = ((int)(playerTransfrom.position.y / 2));
        gameScoreText.text = score.ToString();

        if (score > highscore)
        {
            highscore = score;
            PlayerPrefs.SetInt("Highscore", highscore);
        }
        highScoreText.text = $"{score}/{highscore}";
    }

    public void AddCoin()
    {
        coins += 10;
        gameCoinsText.text = coins.ToString();
        PlayerPrefs.SetInt("Coins", coins);
    }

    public bool SpendCoin(int cost)
    {
        if (coins >= cost)
        {
            coins -= cost;
            gameCoinsText.text = coins.ToString();
            storeCoinsText.text = coins.ToString();
            PlayerPrefs.SetInt("Coins", coins);
            return true;
        }
        else return false;
    }
}
