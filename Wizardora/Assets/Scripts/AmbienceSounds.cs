using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmbienceSounds : MonoBehaviour
{
    private AudioSource audioSource;
    public AudioClip[] birdClips;
    public AudioClip[] insectClips;
    public bool birds = false;
    public bool insects = false;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        if(birds == true)
        {
            StartCoroutine(BirdsDelay());
        }
        
        if(insects == true)
        {
            StartCoroutine(InsectsDelay());
        }
    }

    void BirdSounds()
    {
        if (birds == true)
        {
            audioSource.clip = birdClips[Random.Range(0, birdClips.Length)];
        }
    }

    void InsectSounds()
    {
        if (insects == true)
        {
            audioSource.clip = insectClips[Random.Range(0, insectClips.Length)];
        }
    }

    IEnumerator BirdsDelay()
    {
        yield return new WaitForSeconds(7);
        BirdSounds();
        audioSource.Play();
        StartCoroutine(BirdsDelay());
    }
    IEnumerator InsectsDelay()
    {
        yield return new WaitForSeconds(3);
        InsectSounds();
        audioSource.Play();
        StartCoroutine(InsectsDelay());
    }
}
