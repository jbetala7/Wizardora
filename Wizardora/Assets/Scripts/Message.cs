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
        bartenderMessage.text = "oi " + SaveScript.pName + " you looking for something";
    }

    public void Message1()
    {
        bartenderMessage.text = shopMessage;
        if(inventoryObject != null)
        {
            if(shopMessage != "go hurry. find the blacksmith." && shopMessage != "i'm in lot of pain right now." 
                && shopMessage != "people never come back from the woods." && shopMessage != "the monster killed the children of the village."
                && shopMessage != "bad and evil times." && shopMessage != "a man learns everything with patience."
                && shopMessage != "let your knowledge explore it's options." && shopMessage != "i like to barter things with gold.")
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
                bartenderMessage.text = "oi " + SaveScript.pName + " you looking for something";
                shopUI[shopNumber].SetActive(false);
            }
        }
    }
}
