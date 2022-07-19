using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Speech : MonoBehaviour
{
    public GameObject messageBox;
    public int shopNumber = 0;

    private void OnTriggerStay(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            messageBox.SetActive(true);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            messageBox.GetComponentInChildren<Message>().shopNumber = shopNumber;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            messageBox.SetActive(false);
        }
    }

    
}
