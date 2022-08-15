using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckBook : MonoBehaviour
{
    public GameObject magicBook;
    public GameObject spellBook;
    void Start()
    {
        if(GameObject.Find("SaveObject").GetComponent<SaveScript>().magicCollectedS == true && magicBook != null)
        {
            magicBook.SetActive(false);
        }
        if (GameObject.Find("SaveObject").GetComponent<SaveScript>().spellsCollectedS == true && spellBook != null)
        {
            spellBook.SetActive(false);
        }
    }
}
