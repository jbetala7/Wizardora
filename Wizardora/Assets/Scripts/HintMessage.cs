using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class HintMessage : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{

    public GameObject hintBox;
    public Text message;
    private bool displaying = true;
    private bool overIcon = false;
    public int objectType = 0;

    private Vector3 screenPoint;
    public GameObject canvas;
    public Sprite cursorBasic;
    public Sprite cursorHand;
    public Image cursorImage;
    public AudioSource audioSource;

    public GameObject inventoryObject;
    public bool magic = false;
    public bool spells = false;
    public bool left = true;

    public void OnPointerEnter(PointerEventData eventData)
    {
        overIcon = true;
        if(displaying == true)
        {
            cursorImage.sprite = cursorHand;
            hintBox.SetActive(true);
            if(left == true)
            {
                screenPoint.x = Input.mousePosition.x + Screen.width / 2.5f;
            }if(left == false)
            {
                screenPoint.x = Input.mousePosition.x - Screen.width / 2.5f;
            }
            screenPoint.y = Input.mousePosition.y;
            screenPoint.z = 1f;
            hintBox.transform.position = Camera.main.ScreenToWorldPoint(screenPoint);
            MessageDisplay();
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        cursorImage.sprite = cursorBasic;
        overIcon = false;
        hintBox.SetActive(false);
    }

    // Start is called before the first frame update
    void Start()
    {
        hintBox.SetActive(false);
        audioSource = inventoryObject.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if(overIcon == true)
        {
            if(Input.GetMouseButtonDown(0))
            {

                audioSource.clip = inventoryObject.GetComponent<Inventory>().selectSound;
                audioSource.Play();
                displaying = false;
                hintBox.SetActive(false);
                if(magic == true)
                {
                    if(objectType != 0)
                    {
                        inventoryObject.GetComponent<Inventory>().selected = objectType - 20;
                        inventoryObject.GetComponent<Inventory>().set = true;
                    }
                    
                }
                if (spells == true)
                {
                    if (objectType != 0)
                    {
                        inventoryObject.GetComponent<Inventory>().selected = objectType - 30;
                        inventoryObject.GetComponent<Inventory>().setTwo = true;
                    }

                }
                if(objectType == 14)
                {
                    SaveScript.playerHealth += 0.05f;
                    Inventory.bread--;
                }
                if (objectType == 15)
                {
                    SaveScript.playerHealth += 0.08f;
                    Inventory.cheese--;
                }
                if (objectType == 16)
                {
                    SaveScript.playerHealth += 0.1f;
                    Inventory.meat--;
                }
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
            message.text = Inventory.redPotion.ToString() + " red elixir to be used in potions";
        }
        if (objectType == 11)
        {
            message.text = Inventory.bluePotion.ToString() + " blue elixir to be used in potions";
        }
        if (objectType == 12)
        {
            message.text = Inventory.greenPotion.ToString() + " green elixir to be used in potions";
        }
        if (objectType == 13)
        {
            message.text = Inventory.purplePotion.ToString() + " purple elixir to be used in potions";
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

        if (objectType == 20)
        {
            message.text = "explosive fire attack with 5 fireballs. damage 10% per fireball";
        }
        if (objectType == 21)
        {
            message.text = "replenish health for as long as mana lasts";
        }
        if (objectType == 22)
        {
            message.text = "become invisible for as long as mana lasts";
        }
        if (objectType == 23)
        {
            message.text = "become invulnerable for as long as mana last";
        }
        if (objectType == 24)
        {
            message.text = "double strength for as long as mana lasts";
        }
        if (objectType == 25)
        {
            message.text = "swirl. damage 70%";
        }
        if (objectType == 30)
        {
            message.text = "tornado. damage 40%";
        }
        if (objectType == 31)
        { 
            message.text = "firetwist. damage 15% per fireball";
        }
        if (objectType == 32)
        {
            message.text = "nova. damage 20%";
        }
        if (objectType == 33)
        {
            message.text = "fireballs. damage 10% per fireball";
        }
        if (objectType == 34)
        {
            message.text = "shockwave. damage 50%";
        }
        if (objectType == 35)
        {
            message.text = "blast. damage 30%";
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        canvas.GetComponent<CreatePotion>().thisValue = objectType;
        canvas.GetComponent<CreatePotion>().UpdateValues();
    }
}
