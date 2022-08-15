using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SavePedestal : MonoBehaviour
{
    public GameObject saveScreen;
    public GameObject saveText;
    [HideInInspector]
    public GameObject inventoryObject;
    [HideInInspector]
    public AudioSource audioSource;
    private bool savePause = false;
    public Transform playerPosition;
    public Button yesButton;
    public Button noButton;


    // Start is called before the first frame update
    void Start()
    {
        inventoryObject = GameObject.Find("InventoryCanvas");
        audioSource = inventoryObject.GetComponent<AudioSource>();
        saveScreen.SetActive(false);
        saveText.SetActive(false);
        playerPosition.transform.parent = null;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && savePause == false)
        {
            saveScreen.SetActive(true);
            Time.timeScale = 0;
            savePause = true;

            yesButton.onClick.RemoveAllListeners();
            noButton.onClick.RemoveAllListeners();

            yesButton.onClick.AddListener(Yes);
            noButton.onClick.AddListener(No);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player") && savePause == true)
        {
            savePause = false;
        }
    }

    public void SavePlayerPosition()
    {
        PlayerPrefs.SetInt("IsPlayerSaved", 1);

        var xPos = playerPosition.transform.position.x;
        var yPos = playerPosition.transform.position.y;
        var zPos = playerPosition.transform.position.z;

        PlayerPrefs.SetFloat("X", xPos);
        PlayerPrefs.SetFloat("Y", yPos);
        PlayerPrefs.SetFloat("Z", zPos);
    }

    public void Yes()
    {
        SavePlayerPosition();
        inventoryObject.GetComponent<Inventory>().SaveDeeds();
        SaveScript.saving = true;
        saveText.SetActive(true);
        Time.timeScale = 1;
        StartCoroutine(Continue());
        audioSource.clip = inventoryObject.GetComponent<Inventory>().selectSound;
        audioSource.Play();
    }
    public void No()
    {
        Time.timeScale = 1;
        saveScreen.SetActive(false);
        audioSource.clip = inventoryObject.GetComponent<Inventory>().selectSound;
        audioSource.Play();
    }

    IEnumerator Continue()
    {
        yield return new WaitForSeconds(1);
        saveScreen.SetActive(false);
        saveText.SetActive(false);
    }
}
