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

    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void Next()
    {
        if (player < characters.Length - 1)
        {
            characters[player].SetActive(false);
            player++;
            characters[player].SetActive(true);
        }
    }

    public void Back()
    {
        if (player > 0)
        {
            characters[player].SetActive(false);
            player--;
            characters[player].SetActive(true);
        }
    }

    public void Accept()
    {
        SaveScript.pCharacter = player;
        SaveScript.pName = playerName.text;
        SceneManager.LoadScene(1);
    }
}
