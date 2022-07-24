using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayWeapons : MonoBehaviour
{
    public GameObject[] items;

    // Start is called before the first frame update
    void Start()
    {
        Invoke("SetWeapons", 0);
    }

    void SetWeapons()
    {
        if (SaveScript.pCharacter == 0 || SaveScript.pCharacter == 2 || SaveScript.pCharacter == 4)
        {
            items[0].SetActive(true);
        }
        else
        {
            items[1].SetActive(true);
        }
    }
}
