using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuyWeapons : MonoBehaviour
{
    public int weaponNumber;
    public int armourNumber;
    public int weaponCost;
    public Text currencyText;
    public GameObject inventoryObject;

    [HideInInspector]
    public AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        inventoryObject = GameObject.Find("InventoryCanvas");
        currencyText.text = Inventory.gold.ToString();
        audioSource = inventoryObject.GetComponent<AudioSource>();
    }

    public void BuyWeaponButton()
    {
        if(Inventory.gold >= weaponCost && inventoryObject.GetComponent<Inventory>().weapons[weaponNumber] == false)
        {
            Inventory.gold -= weaponCost;
            inventoryObject.GetComponent<Inventory>().weapons[weaponNumber] = true;
            audioSource.clip = inventoryObject.GetComponent<Inventory>().buySound;
            audioSource.Play();
            currencyText.text = Inventory.gold.ToString();
        }
    }

    public void BuyArmourButton()
    {
        if(Inventory.gold >= weaponCost && armourNumber != SaveScript.armour)
        {
            SaveScript.armour = armourNumber;
            SaveScript.changeArmour = true;
            Inventory.gold -= weaponCost;
            audioSource.clip = inventoryObject.GetComponent<Inventory>().buySound;
            audioSource.Play();
            currencyText.text = Inventory.gold.ToString();
        }
    }
}
