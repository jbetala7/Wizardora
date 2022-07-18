using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class HintMessage : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{

    public GameObject hintBox;
    public Text message;
    private bool displaying = true;
    private bool overIcon = false;
    public int objectType = 0;

    private Vector3 screenPoint;

    public void OnPointerEnter(PointerEventData eventData)
    {
        overIcon = true;
        if(displaying == true)
        {
            hintBox.SetActive(true);
            screenPoint.x = Input.mousePosition.x + 500;
            screenPoint.y = Input.mousePosition.y;
            screenPoint.z = 1f;
            hintBox.transform.position = Camera.main.ScreenToWorldPoint(screenPoint);
            MessageDisplay();
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        overIcon = false;
        hintBox.SetActive(false);
    }

    // Start is called before the first frame update
    void Start()
    {
        hintBox.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(overIcon == true)
        {
            if(Input.GetMouseButtonDown(0))
            {
                displaying = false;
                hintBox.SetActive(false);
            }
        }
        if (Input.GetMouseButtonUp(0))
        {
            displaying = true;
        }
    }

    void MessageDisplay()
    {
        if(objectType == 0)
        {
            message.text = "empty";
        }
        if(objectType == 1)
        {
            message.text = Inventory.redMushrooms.ToString() + " red mushrooms to be used in potions";
        }
        if (objectType == 2)
        {
            message.text = Inventory.purpleMushrooms.ToString() + " purple mushrooms to be used in potions";
        }
        if (objectType == 3)
        {
            message.text = Inventory.brownMushrooms.ToString() + " brown mushrooms to be used in potions";
        }
        if (objectType == 4)
        {
            message.text = Inventory.bluePlants.ToString() + " blue plants to be used in potions";
        }
        if (objectType == 5)
        {
            message.text = Inventory.redFlowers.ToString() + " red flowers to be used in potions";
        }
        if (objectType == 6)
        {
            message.text = Inventory.roots.ToString() + " roots flowers to be used in potions";
        }
        if (objectType == 7)
        {
            message.text = Inventory.leafDew.ToString() + " leaf dew to be used in potions";
        }
        if (objectType == 8)
        {
            message.text = "key to open chests";
        }
        if (objectType == 9)
        {
            message.text = Inventory.dragonEgg.ToString() + " dragon eggs to be used in potions";
        }
        if (objectType == 10)
        {
            message.text = Inventory.redPotion.ToString() + " red potion to be used in potions";
        }
        if (objectType == 11)
        {
            message.text = Inventory.bluePotion.ToString() + " blue potion to be used in potions";
        }
        if (objectType == 12)
        {
            message.text = Inventory.greenPotion.ToString() + " green potion to be used in potions";
        }
        if (objectType == 13)
        {
            message.text = Inventory.purplePotion.ToString() + " purple potion to be used in potions";
        }
        if (objectType == 14)
        {
            message.text = Inventory.bread.ToString() + " bread used to replenish health";
        }
        if(objectType == 15)
        {
            message.text = Inventory.cheese.ToString() + " cheese used to replenish health";
        }
        if(objectType == 16)
        {
            message.text = Inventory.meat.ToString() + " meat used to replenish health";
        }
    }
}
