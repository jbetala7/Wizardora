using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinGame : MonoBehaviour
{
    public static WinGame Instance {get;set;}
    public GameObject myCamera;
    public bool isWinGame = false;
    public Animator animator;

    void Awake()
    {
        Instance = this;
        animator = GetComponent<Animator>();    
    }

    private void Start()
    {
        myCamera = GameObject.Find("Main Camera");
    }

    // Update is called once per frame
    void Update()
    {
        if(isWinGame)
        {
            animator.SetBool("win", true);
            myCamera.GetComponent<AudioManager>().musicState = 7;
            myCamera.GetComponent<AudioManager>().canPlay = true;
            isWinGame = false;
        }
    }

    public void StartMenuScene()
    {
        SceneManager.LoadScene("MainMenu");
    }

}
