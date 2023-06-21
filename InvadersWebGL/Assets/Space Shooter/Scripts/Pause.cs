using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{
    private bool isPaused;
    public GameObject pausePanel;

    private void Start()
    {
        Time.timeScale = 1f;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PauseScreen();
        }  
    }

    void PauseScreen()
    {
        if (isPaused)
        {
            isPaused = false;
            Time.timeScale = 1f;
            pausePanel.SetActive(false);
            /*Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;*/
        }
        else
        {
            isPaused = true;
            Time.timeScale = 0f;
            /*Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;*/
            pausePanel.SetActive(true);
        }
    }

    public void BackToMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Menu");
    }

}
