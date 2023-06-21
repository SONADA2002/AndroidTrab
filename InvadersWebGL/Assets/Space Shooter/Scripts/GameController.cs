using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{

    public GameOverScreen GameOverScreen;
    public TimerCountdown Timer;
    public Score Points;

    private void Start()
    {
        Time.timeScale = 1f;
    }

    public void GameOver(int highScore)
    {
        GameOverScreen.Setup(highScore);
        Time.timeScale = 0f;
    }
    private void Update()
    {
        if (Timer.secondsLeft == 0)
        {
            
            GameOver(Points.highScore);
        }
    }

}
