using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmbienceSounds : MonoBehaviour
{
    private AudioSource audioSource;
    public WaitForSeconds waitTime = new WaitForSeconds(3);

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        StartCoroutine(AnimalSounds());
    }

    IEnumerator AnimalSounds()
    {
        yield return waitTime;
        audioSource.Play();
        StartCoroutine(AnimalSounds()); //looping the sound
    }
}
