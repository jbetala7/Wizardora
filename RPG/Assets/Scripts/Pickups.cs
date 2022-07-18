using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickups : MonoBehaviour
{
    public int number;
    public bool redMushroom = false;
    public bool purpleMushroom = false;
    public bool brownMushroom = false;
    public bool bluePlants = false;
    public bool redFlower = false;

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
            else if (bluePlants == true)
            {
                if (Inventory.bluePlants == 0)
                {
                    DisplayIcons();
                }
                Inventory.bluePlants++;
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
