using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Speech : MonoBehaviour
{
    public GameObject messageBox;
    public int shopNumber = 0;
    public string answer;
    public GameObject question;
    private bool haveRead = false;
    private GameObject miniMapView;
    private GameObject miniMapCompass;
    private GameObject inventoryObject;

    private void Start()
    {
        inventoryObject = GameObject.Find("InventoryCanvas");
        miniMapView = GameObject.FindGameObjectWithTag("MiniMapItem");
        miniMapCompass = GameObject.FindGameObjectWithTag("Compass");
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            messageBox.SetActive(true);
            miniMapView.SetActive(false);
            miniMapCompass.SetActive(false);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            messageBox.GetComponentInChildren<Message>().shopNumber = shopNumber;
            for(int i = 0; i < inventoryObject.GetComponent<Inventory>().messages.Length; i++)
            {
                if(answer == inventoryObject.GetComponent<Inventory>().messages[i].text)
                {
                    haveRead = true;
                }
            }
            if(haveRead == false)
            {
                haveRead = false;
                question.GetComponent<Message>().shopMessage = answer;
            }
            else if (haveRead == true && shopNumber == 1 || shopNumber == 4 || shopNumber == 5 || shopNumber == 6)
            {
                question.GetComponent<Message>().shopMessage = "not much";
            }
            else if (haveRead == true && shopNumber == 0 || shopNumber == 3 || shopNumber == 2)
            {
                question.GetComponent<Message>().shopMessage = "oolala";
            }
            if(shopNumber == 0)
            {
                question.GetComponent<Message>().buttonText.text = "Hello";
            }
            else if (shopNumber == 1)
            {
                question.GetComponent<Message>().buttonText.text = "Yo";
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            messageBox.SetActive(false);
            miniMapView.SetActive(true);
            miniMapCompass.SetActive(true);
        }
    }
}
