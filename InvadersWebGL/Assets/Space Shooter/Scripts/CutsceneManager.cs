using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CutsceneManager : MonoBehaviour
{

    public GameObject panelSkip;

    private void Awake()
    {
        panelSkip.SetActive(false);
    }

    void Start()
    {
        StartCoroutine(FimCutscene());
        StartCoroutine(Panel());
    }

    private IEnumerator FimCutscene()
    {
        yield return new WaitForSeconds(40f);
        Debug.Log("OLÁ");
        SceneManager.LoadScene("Game");
        yield return null;
    }

    private IEnumerator Panel()
    {
        Debug.Log("Entrou");
        yield return new WaitForSeconds(6f);
        panelSkip.SetActive(true);
        yield return null;
    }

    public void SkipCutscene()
    {
        SceneManager.LoadScene("Game");
    }
}

