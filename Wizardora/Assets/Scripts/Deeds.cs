using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Deeds : MonoBehaviour
{
    public GameObject inventoryObject;
    public Text[] deeds;
    public bool canUpdate = false;

    // Update is called once per frame
    void Update()
    {
        if(canUpdate == true)
        {
            canUpdate = false;
            for (int i = 0; i < inventoryObject.GetComponent<Inventory>().messages.Length; i++)
            {
                if (inventoryObject.GetComponent<Inventory>().messages[i].text != "empty")
                {
                    deeds[i].text = inventoryObject.GetComponent<Inventory>().messages[i].text;
                    deeds[i].color = new Color(255, 255, 255, 255);
                }
            }
        }
    }
}
