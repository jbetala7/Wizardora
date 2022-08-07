using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Speech : MonoBehaviour
{
    public GameObject messageBox;
    public int shopNumber = 0;
    public string answer;
    public GameObject question;
    public GameObject question2;
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
            question.GetComponent<Message>().shopNumber = shopNumber;
            question2.GetComponent<Message>().shopNumber = shopNumber;
            //messageBox.GetComponentInChildren<Message>().shopNumber = shopNumber;
            for (int i = 0; i < inventoryObject.GetComponent<Inventory>().messages.Length; i++)
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
            else if (haveRead == true && shopNumber == 0)
            {
                question.GetComponent<Message>().shopMessage = "go hurry. find the blacksmith.";
            }
            else if (haveRead == true && shopNumber == 1)
            {
                question.GetComponent<Message>().shopMessage = "i'm in lot of pain right now.";
            }
            else if (haveRead == true && shopNumber == 2)
            {
                question.GetComponent<Message>().shopMessage = "people never come back from the woods.";
            }
            else if (haveRead == true && shopNumber == 3)
            {
                question.GetComponent<Message>().shopMessage = "bad and evil times.";
            }
            else if (haveRead == true && shopNumber == 4)
            {
                question.GetComponent<Message>().shopMessage = "a man learns everything with patience.";
            }
            else if (haveRead == true && shopNumber == 5)
            {
                question.GetComponent<Message>().shopMessage = "let your knowledge explore it's options.";
            }
            else if (haveRead == true && shopNumber == 6)
            {
                question.GetComponent<Message>().shopMessage = "i like to barter things with gold.";
            }
            if (shopNumber == 0)
            {
                question.GetComponent<Message>().buttonText.text = "battle ahead, where can i buy weapons?";
            }
            else if (shopNumber == 1)
            {
                question.GetComponent<Message>().buttonText.text = "pity! i feel sorry for your children.";
            }
            else if (shopNumber == 2)
            {
                question.GetComponent<Message>().buttonText.text = "my lady, why is this town so quiet? where is everyone?";
            }
            else if (shopNumber == 3)
            {
                question.GetComponent<Message>().buttonText.text = "good sir, why is this town so dull? what is wrong here?";
            }
            else if (shopNumber == 4)
            {
                question.GetComponent<Message>().buttonText.text = "how can one defeat this monstrous creature?";
            }
            else if (shopNumber == 5)
            {
                question.GetComponent<Message>().buttonText.text = "i am keen to know more about wizardry";
            }
            else if (shopNumber == 6)
            {
                question.GetComponent<Message>().buttonText.text = "oh boy! how do i buy these expensive weapons and armoury?";
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
