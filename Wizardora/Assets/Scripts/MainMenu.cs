using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject continueButton;
    public GameObject loadingScreen;
    public GameObject saveObject;
    private AudioSource audioSource;
    public AudioClip selectSound;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();

        if (System.IO.File.Exists(Application.persistentDataPath + "/save.dat"))
        {
            SaveScript.notSavedYet = false;
        }
        else
        {
            SaveScript.notSavedYet = true;
        }

        if (SaveScript.notSavedYet == true)
        {
            continueButton.SetActive(false);
        }
        if (SaveScript.notSavedYet == false)
        {
            continueButton.SetActive(true);
        }

        Time.timeScale = 1;
    }

    public void ContinueGame()
    {
        loadingScreen.SetActive(true);
        saveObject.SetActive(true);
        SaveScript.continueData = true;
        StartCoroutine(WaitToLoad());
        audioSource.clip = selectSound;
        audioSource.Play();
    }

    public void NewGame()
    {
        PlayerPrefs.SetInt("IsPlayerSaved", 0);
        SaveScript.playerHealth = 1.0f;
        SaveScript.newGame = true;
        SceneManager.LoadScene(1);
        audioSource.clip = selectSound;
        audioSource.Play();
    }

    public void QuitGame()
    {
        Application.Quit();
        audioSource.clip = selectSound;
        audioSource.Play();
    }

    IEnumerator WaitToLoad()
    {
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(2);
    }
}