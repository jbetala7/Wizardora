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
    public bool key = false;
    public bool coins = false;
    public bool isSpider = false;
    public bool isDragon = false;
    public bool isWolfRider = false;
    public bool isSkeleton = false;
    public bool isOrcPig = false;
    public bool isSmallSkeleton = false;

    [HideInInspector]
    public GameObject inventoryObject;
    public AudioSource audioSource;

    // Start is called before the first frame update
    private void Start()
    {
        inventoryObject = GameObject.Find("InventoryCanvas");
        audioSource = inventoryObject.GetComponent<AudioSource>();
        if(coins == true)
        {
            Destroy(gameObject, 5f);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            audioSource.clip = inventoryObject.GetComponent<Inventory>().pickupSound;
            audioSource.Play();

            if (redMushroom == true)
            {
                if(Inventory.redMushrooms == 0)
                {
                    DisplayIcons();
                }
                Inventory.redMushrooms++;
                Destroy(gameObject);
            }
            else if (purpleMushroom == true)
            {
                if (Inventory.purpleMushrooms == 0)
                {
                    DisplayIcons();
                }
                Inventory.purpleMushrooms++;
                Destroy(gameObject);
            }
            else if (brownMushroom == true)
            {
                if (Inventory.brownMushrooms == 0)
                {
                    DisplayIcons();
                }
                Inventory.brownMushrooms++;
                Destroy(gameObject);
            }
            else if (redFlower == true)
            {
                if (Inventory.redFlowers == 0)
                {
                    DisplayIcons();
                }
                Inventory.redFlowers++;
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
            else if (key == true)
            {
                DisplayIcons();
                Inventory.key = true;
                Destroy(gameObject);
            }
            else if (coins == true)
            {
                if (isSpider == true)
                {
                    Inventory.gold += 500;
                    Destroy(gameObject);
                }
                else if (isDragon == true)
                {
                    Inventory.gold += 1000;
                    Destroy(gameObject);
                }
                else if (isWolfRider == true)
                {
                    Inventory.gold += Random.Range(100, 200);
                    Destroy(gameObject);
                }
                else if (isSkeleton == true)
                {
                    Inventory.gold += Random.Range(50, 150);
                    Destroy(gameObject);
                }
                else if (isOrcPig == true)
                {
                    Inventory.gold += Random.Range(30, 70);
                    Destroy(gameObject);
                }
                else if (isSmallSkeleton == true)
                {
                    Inventory.gold += Random.Range(10, 50);
                    Destroy(gameObject);
                }
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
