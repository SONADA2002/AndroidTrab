using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    public string cena;
    public GameObject optionsPanel;
    public GameObject menuPanel;
    public GameObject tutorialPanel;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartGame()
    {
        SceneManager.LoadScene(cena);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void ShowOptions()
    {
        optionsPanel.SetActive(true);
        menuPanel.SetActive(false);
    }

    public void ShowTutorial()
    {
        tutorialPanel.SetActive(true);
        menuPanel.SetActive(false);
    }


    public void BackToMenu()
    {
        optionsPanel.SetActive(false);
        menuPanel.SetActive(true);
        tutorialPanel.SetActive(false);
    }

    public void SetFullScreen(bool isFullScreen)
    {
        Screen.fullScreen = isFullScreen;
    }
}
