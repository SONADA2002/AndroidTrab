using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverScreen : MonoBehaviour
{
    public Text pointsText;
    
    public GameObject player;
    

    public void Setup(int highScore)
    {

            gameObject.SetActive(true);
            pointsText.text = highScore.ToString() + " Points";
            

    }
    public void RestartButton()
    {
        
        SceneManager.LoadScene("Game");
        

    }
    public void ExitButton()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
