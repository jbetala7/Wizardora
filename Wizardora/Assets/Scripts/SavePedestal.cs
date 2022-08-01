using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SavePedestal : MonoBehaviour
{
    public GameObject saveScreen;
    public GameObject saveText;
    public GameObject playerObject;
    public GameObject inventoryObject;
    public AudioSource audioSource;
    private bool savePause = false;

    // Start is called before the first frame update
    void Start()
    {
        inventoryObject = GameObject.Find("InventoryCanvas");
        audioSource = inventoryObject.GetComponent<AudioSource>();
        playerObject = GameObject.FindGameObjectWithTag("Player");
        saveScreen.SetActive(false);
        saveText.SetActive(false);
        //Vector3 poisiton = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z + 10f);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player") && savePause == false)
        {
            saveScreen.SetActive(true);
            Time.timeScale = 0;
            savePause = true;
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
        var xPos = playerObject.transform.position.x;
        var yPos = playerObject.transform.position.y;
        var zPos = playerObject.transform.position.z + 10f;
        PlayerPrefs.SetFloat("X", xPos);
        PlayerPrefs.SetFloat("Y", yPos);
        PlayerPrefs.SetFloat("Z", zPos);
        PlayerPrefs.Save();
    }

    public void Yes()
    {
        SavePlayerPosition();
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
