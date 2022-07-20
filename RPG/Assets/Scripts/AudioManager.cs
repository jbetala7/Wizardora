using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    private AudioSource audioSource;
    public AudioClip mainLoop;
    public AudioClip tavernLoop;
    public AudioClip battleLoop;
    public int musicState = 1;

    [HideInInspector]
    public bool canPlay = true;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();   
    }

    // Update is called once per frame
    void Update()
    {
        if(canPlay == true)
        {
            canPlay = false;
            if (musicState == 1)
            {
                audioSource.clip = mainLoop;
                audioSource.Play();
            }
            if (musicState == 2)
            {
                audioSource.clip = tavernLoop;
                audioSource.Play();
            }
            if (musicState == 3)
            {
                audioSource.clip = battleLoop;
                audioSource.Play();
            }
        }
    }
}
