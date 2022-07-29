using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Roof : MonoBehaviour
{
    public GameObject roof;
    public GameObject props;
    public GameObject myCamera;
    public bool bar = true;
    public bool wizard = false;
    public bool blacksmith = false;

    // Start is called before the first frame update
    void Start()
    {
        roof.SetActive(true);
        props.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            roof.SetActive(false);
            props.SetActive(true);
            SaveScript.internalHouse = true;
            if(bar == true)
            {
                myCamera.GetComponent<AudioManager>().musicState = 2;
                myCamera.GetComponent<AudioManager>().canPlay = true;
            }
            if (wizard == true)
            {
                myCamera.GetComponent<AudioManager>().musicState = 4;
                myCamera.GetComponent<AudioManager>().canPlay = true;
            }
            if (blacksmith == true)
            {
                myCamera.GetComponent<AudioManager>().musicState = 5;
                myCamera.GetComponent<AudioManager>().canPlay = true;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            roof.SetActive(true);
            props.SetActive(false);
            SaveScript.internalHouse = false;
            myCamera.GetComponent<AudioManager>().musicState = 1;
            myCamera.GetComponent<AudioManager>().canPlay = true;
        }
    }
}
