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
            if(haveRead == false)
            {
                haveRead = false;
                question.GetComponent<Message>().shopMessage = answer;
                StartCoroutine(FirstEntry());
            }
            else if (haveRead == true && shopNumber == 1 || shopNumber == 4 || shopNumber == 5 || shopNumber == 6)
            {
                question.GetComponent<Message>().shopMessage = "not much";
            }
            else if (haveRead == true && shopNumber == 0 || shopNumber == 3 || shopNumber == 2)
            {
                question.GetComponent<Message>().shopMessage = "oolala";
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            messageBox.SetActive(false);
        }
    }

    IEnumerator FirstEntry()
    {
        yield return new WaitForSeconds(1);
        haveRead = true;
    }
}
