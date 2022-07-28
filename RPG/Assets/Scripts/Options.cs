using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class Options : MonoBehaviour
{
    public Slider musicSliderr;
    public Slider SFXSlider;
    public AudioMixer musicMixer;
    public AudioMixer SFXMixer;
    private GameObject saveObject;

    public void ChangeMusicVolume()
    {
        musicMixer.SetFloat("musicVolume", musicSliderr.value);
    }

    public void ChangeSFXVolume()
    {
        musicMixer.SetFloat("SFXVolume", SFXSlider.value);
    }

    public void MainMenu()
    {
        SaveScript.playerHealth = 1.0f;
        SaveScript.instance = 0;
        saveObject = GameObject.Find("SaveObject");
        Destroy(saveObject);
        SceneManager.LoadScene(0);
    }
}
