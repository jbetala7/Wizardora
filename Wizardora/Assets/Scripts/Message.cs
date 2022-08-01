using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Message : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public Text buttonText;
    public Text bartenderMessage;
    public Color32 messageOff;
    public Color32 messageOn;
    public GameObject[] shopUI;
    public string shopMessage;
    public GameObject inventoryObject;

    [HideInInspector]
    public int shopNumber = 0;

    public void OnPointerEnter(PointerEventData eventData)
    {
        buttonText.color = messageOn;
        PlayerMovement.canMove = false;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        buttonText.color = messageOff;
        PlayerMovement.canMove = true;
    }

    // Start is called before the first frame update
    private void Start()
    {
        if(shopNumber == 0)
        {
            bartenderMessage.text = "yo";
        }
        else
        {
            bartenderMessage.text = "oi " + SaveScript.pName + " you looking for something";
        }
        
    }

    public void Message1()
    {
        bartenderMessage.text = shopMessage;
        if(inventoryObject != null)
        {
            if(shopMessage != "not much" && shopMessage != "oolala")
            {
                inventoryObject.GetComponent<Inventory>().UpdateMessages(shopMessage);
            }
        }
    }

    public void Message2()
    {
        bartenderMessage.text = "shop items from the list";
        shopUI[shopNumber].SetActive(true);
        if(shopNumber < 6)
        {
            shopUI[shopNumber].GetComponent<Buy>().UpdateGold();
        }
    }

    // Update is called once per frame
    private void Update()
    {
        if(PlayerMovement.canMove == true && PlayerMovement.isMoving == true)
        {
            if (shopUI != null)
            {
                if (shopNumber == 0)
                {
                    bartenderMessage.text = "yo";
                }
                else
                {
                    bartenderMessage.text = "oi " + SaveScript.pName + " you looking for something";
                }
                shopUI[shopNumber].SetActive(false);
            }
        }
    }
}
