using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinGame : MonoBehaviour
{
    public static WinGame Instance {get;set;}

    public bool isWinGame = false;
    public Animator animator;

    void Awake()
    {
        Instance = this;
        animator = GetComponent<Animator>();    
    }

    // Update is called once per frame
    void Update()
    {
        if(isWinGame)
        {
            animator.SetBool("win", true);
            isWinGame = false;
        }
    }

    public void StartMenuScene()
    {
        SceneManager.LoadScene("MainMenu");
    }

}
