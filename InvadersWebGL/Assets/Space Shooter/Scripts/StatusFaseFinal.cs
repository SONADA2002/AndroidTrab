using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class StatusFaseFinal : Enemy
{
    public enum StatusFase { Ligado, Desligado, Finalizado }

    //public delegate void TodosMorreram();
    //public TodosMorreram OnTodosMorreram;

    public float tempoIntervalo = 10f;

    public static StatusFaseFinal instance;

    public Enemy[] inimigos;
    public StatusFase status;
    public float totalInimigos;
    public GameObject fimPanel;
    public GameObject canvas;

    private void Awake()
    {
        instance = this;
        fimPanel.SetActive(false);
    }

    private void Start()
    {
        totalInimigos = inimigos.Length;
        status = StatusFase.Ligado;
        canvas = GameObject.FindWithTag("Canvas");
    }

    public void Update()
    {

        if (totalInimigos == 0)
        {
            Timer.instance.Repasa();
            status = StatusFase.Desligado;
            totalInimigos -= 1;
            canvas.GetComponent <Timer>().enabled = false;
            fimPanel.SetActive(true);
            Player.instance.GetInvulnerable();
            StartCoroutine(IntervaloTempo());
        }

    }
    public void RemoverInimigo()
    {
            totalInimigos--;
    }

    public IEnumerator IntervaloTempo()
    {
        Debug.Log("Entrei");
        yield return new WaitForSeconds(10f);
        SceneManager.LoadScene("Menu");
        yield return null;
    }
}

