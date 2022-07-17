using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickups : MonoBehaviour
{
    public int number;
    public bool redMushroom = false;
    public bool blueFlower = false;

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            if(redMushroom == true)
            {
                if(Inventory.redMushrooms == 0)
                {
                    DisplayIcons();
                }
                Inventory.redMushrooms++;
                Destroy(gameObject);
            }
            else if (blueFlower == true)
            {
                if (Inventory.blueFlowers == 0)
                {
                    DisplayIcons();
                }
                Inventory.blueFlowers++;
                Destroy(gameObject);
            }
            else
            {
                DisplayIcons();
                Destroy(gameObject);
            }
        }
    }

    void DisplayIcons()
    {
        Inventory.newIcon = number;
        Inventory.iconUpdate = true;
    }

}
