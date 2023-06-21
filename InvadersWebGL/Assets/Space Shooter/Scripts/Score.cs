using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public static Score instance;

    public Text scoreText;
    public Text highScoreText;

    int score = 0;
    public int highScore = 0;

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        highScore = PlayerPrefs.GetInt("highScore", 0);
        scoreText.text = score.ToString() + " Points:";
        highScoreText.text = "HighScore: " + highScore.ToString();


    }

    public void AddPoint()
    {
       
        score += 1;

        if (score > highScore)
        {
            PlayerPrefs.SetInt("highScore", score);
            highScore = score;
        }
       

        scoreText.text = score.ToString() + " Points";
        highScoreText.text = "HighScore: " + highScore.ToString();
    }
    public void ResetPoint()
    {
        score = 0;
        scoreText.text = score.ToString() + " Points";
    }

     
    
}
