using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerChoose : MonoBehaviour
{
    public GameObject[] characters;
    private int player = 0;
    public Text playerName;
    private AudioSource audioSource;
    public AudioClip selectSound;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    public void Next()
    {
        if (player < characters.Length - 1)
        {
            audioSource.clip = selectSound;
            audioSource.Play();
            characters[player].SetActive(false);
            player++;
            characters[player].SetActive(true);
        }
    }

    public void Back()
    {
        if (player > 0)
        {
            audioSource.clip = selectSound;
            audioSource.Play();
            characters[player].SetActive(false);
            player--;
            characters[player].SetActive(true);
        }
    }

    public void Accept()
    {
        audioSource.clip = selectSound;
        audioSource.Play();
        SaveScript.pCharacter = player;
        if (playerName.text == "")
        {
            playerName.text = SaveScript.pName;
        }
        else
        {
            SaveScript.pName = playerName.text;
        }
        SceneManager.LoadScene(2);
    }
}
