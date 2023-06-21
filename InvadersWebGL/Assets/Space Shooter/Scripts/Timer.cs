using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Timer : Player
{
    public static Timer instance;
    bool timeActive = true;
    float currentTime;
    public Text currentTimeText;
    public float timeRecord = 5000000;
    public Text timeRecordText;
    public GameObject inimigosFase;

    private void Awake()
    {
        instance = this;
        inimigosFase.SetActive(false);
    }
    void Start()
    {
        //timeRecord
        timeRecord = PlayerPrefs.GetFloat("timeRecord", 0);
        timeRecordText.text = timeRecord.ToString();

    }


    void Update()
    {
        if (timeActive == true)
        {
            currentTime = currentTime + Time.deltaTime;
        }
        TimeSpan time = TimeSpan.FromSeconds(currentTime);
        currentTimeText.text = time.ToString(@"mm\:ss\:fff");
        //currentTimeText.text = time.Minutes.ToString()+ ":"+ time.Seconds.ToString();

        if (currentTime > 40.000000)
        {
            inimigosFase.SetActive(true);
        }
    }

    public void Repasa()
    {
        if (currentTime < timeRecord)
        {
            Debug.Log("tempo");
            PlayerPrefs.SetFloat("timeRecord", currentTime);
            timeRecord = currentTime;
            timeRecordText.text = timeRecord.ToString();
        }

        if (timeRecord == 0)
        {
            PlayerPrefs.SetFloat("timeRecord", currentTime);
            timeRecord = currentTime;
        }
    }

}


