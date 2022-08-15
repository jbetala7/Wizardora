using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectBook : MonoBehaviour
{
    public GameObject magicUI;
    public GameObject spellsUI;
    public GameObject magicBookMessage;
    public GameObject spellBookMessage;
    public GameObject inventoryObject;
    public AudioClip openBook;
    public static bool magicCollected = false;
    public static bool spellsCollected = false;
    public bool magicBook = false;
    public bool spellsBook = false;

    // Start is called before the first frame update
    void Start()
    {
        if(magicBook == true)
        {
            magicUI.SetActive(false);
            magicBookMessage.SetActive(false);
        }
        if (spellsBook == true)
        {
            spellsUI.SetActive(false);
            spellBookMessage.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            if(magicBook == true)
            {
                if (magicCollected == false)
                {
                    magicUI.SetActive(true);
                    magicCollected = true;
                    StartCoroutine(DisplayMessage());
                }
            }
            if (spellsBook == true)
            {
                if (spellsCollected == false)
                {
                    spellsUI.SetActive(true);
                    spellsCollected = true;
                    StartCoroutine(DisplayMessage());
                }
            }
        }
    }

    IEnumerator DisplayMessage()
    {
        yield return new WaitForSeconds(0.5f);
        inventoryObject.GetComponent<AudioSource>().clip = openBook;
        inventoryObject.GetComponent<AudioSource>().Play();
        if(magicBook == true)
        {
            magicBookMessage.SetActive(true);
        }
        if (spellsBook == true)
        {
            spellBookMessage.SetActive(true);
        }
        yield return new WaitForSeconds(3);
        if (magicBook == true)
        {
            magicBookMessage.SetActive(false);
        }
        if (spellsBook == true)
        {
            spellBookMessage.SetActive(false);
        }
        Destroy(gameObject);
    }
}
