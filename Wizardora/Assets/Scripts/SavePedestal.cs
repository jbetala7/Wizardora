using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SavePedestal : MonoBehaviour
{
    public GameObject saveScreen;
    public GameObject saveText;
    public GameObject playerObject;
    private bool savePause = false;

    // Start is called before the first frame update
    void Start()
    {
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

    public void Yes()
    {
        //var xPos = playerObject.transform.position.x;
        //var yPos = playerObject.transform.position.y;
        //var zPos = playerObject.transform.position.z + 10f;
        //PlayerPrefs.SetFloat("X", xPos);
        //PlayerPrefs.SetFloat("Y", yPos);
        //PlayerPrefs.SetFloat("Z", zPos);
        //PlayerPrefs.Save();
        SaveScript.saving = true;
        saveText.SetActive(true);
        Time.timeScale = 1;
        StartCoroutine(Continue());
    }
    public void No()
    {
        Time.timeScale = 1;
        saveScreen.SetActive(false);
    }

    IEnumerator Continue()
    {
        yield return new WaitForSeconds(1);
        saveScreen.SetActive(false);
        saveText.SetActive(false);
    }
}
