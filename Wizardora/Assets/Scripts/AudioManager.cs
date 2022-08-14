using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    private AudioSource audioSource;
    public AudioClip mainLoop;
    public AudioClip tavernLoop;
    public AudioClip battleLoop;
    public AudioClip wizardLoop;
    public AudioClip blacksmithLoop;
    public AudioClip deathLoop;
    public AudioClip winLoop;
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
        if (canPlay == true)
        {
            canPlay = false;
            if (musicState == 1)
            {
                audioSource.clip = mainLoop;
                audioSource.volume = 0.7f;
                audioSource.Play();
            }
            if (musicState == 2)
            {
                audioSource.clip = tavernLoop;
                audioSource.volume = 0.4f;
                audioSource.Play();
            }
            if (musicState == 3)
            {
                audioSource.clip = battleLoop;
                audioSource.volume = 0.3f;
                audioSource.Play();
            }
            if (musicState == 4)
            {
                audioSource.clip = wizardLoop;
                audioSource.volume = 0.4f;
                audioSource.Play();
            }
            if (musicState == 5)
            {
                audioSource.clip = blacksmithLoop;
                audioSource.volume = 0.4f;
                audioSource.Play();
            }
            if (musicState == 6)
            {
                audioSource.clip = deathLoop;
                audioSource.volume = 0.7f;
                audioSource.Play();
            }
            if (musicState == 7)
            {
                audioSource.clip = winLoop;
                audioSource.volume = 0.7f;
                audioSource.Play();
            }
        }
    }
}
