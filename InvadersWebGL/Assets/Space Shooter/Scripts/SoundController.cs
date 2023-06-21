using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundController : MonoBehaviour
{
    public float volumeMaster;
    public float volumeSFX;
    public float volumeMusic;
    public Slider sliderMaster;
    public Slider sliderSFX;
    public Slider sliderMusic;

    // Start is called before the first frame update
    public void Start()
    {
        if (sliderMaster != null)
        {
            sliderMaster.value = PlayerPrefs.GetFloat("Master");
        }
        if (sliderSFX != null)
        {
            sliderSFX.value = PlayerPrefs.GetFloat("SFX");
        }
        if (sliderMusic != null)
        {
            sliderMusic.value = PlayerPrefs.GetFloat("Music");
        }
    }

    // Update is called once per frame
    void Update()
    {

    }


    public void VolumeMaster(float volume)
    {
        volumeMaster = volume;
        AudioListener.volume = volumeMaster;
        PlayerPrefs.SetFloat("Master", volumeMaster);
    }

    public void VolumeSFX(float volume)
    {
        volumeSFX = volume;
        GameObject [] Sfx = GameObject.FindGameObjectsWithTag("SFX");
        for (int i = 0; i < Sfx.Length; i++)
        {
            Sfx[i].GetComponent<AudioSource>().volume = volumeSFX;
        }
        PlayerPrefs.SetFloat("SFX", volumeSFX);
    }

    public void VolumeMusica(float volume)
    {
        volumeMusic = volume;
        GameObject[] Musicas = GameObject.FindGameObjectsWithTag("Musicas");
        for (int i = 0; i < Musicas.Length; i++)
        {
            Musicas[i].GetComponent<AudioSource>().volume = volumeMusic;
        }
        PlayerPrefs.SetFloat("Music", volumeMusic);
    }
}
