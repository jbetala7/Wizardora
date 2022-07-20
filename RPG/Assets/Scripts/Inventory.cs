using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public GameObject inventoryMenu;
    public GameObject closedBook;
    public GameObject openBook;
    public GameObject potionBook;
    private AudioSource audioSource;
    public AudioClip bookOpenSound;
    public AudioClip selectSound;
    public AudioClip buySound;
    public AudioClip createPotionSound;
    public AudioClip pickupSound;

    public GameObject messageBox;

    public Image[] emptySlots;
    public Sprite[] icons;
    public Sprite emptyIcon;

    public static int redMushrooms = 0;
    public static int purpleMushrooms = 0;
    public static int brownMushrooms = 0;
    public static int bluePlants = 0;
    public static int redFlowers = 0;
    public static int roots = 0;
    public static int leafDew = 0;
    public static bool key = true;
    public static int dragonEgg = 0;
    public static int redPotion = 0;
    public static int bluePotion = 0;
    public static int greenPotion = 0;
    public static int purplePotion = 0;
    public static int bread = 0;
    public static int cheese = 0;
    public static int meat = 0;

    public static int newIcon = 0;
    public static int gold = 30000;
    public static bool iconUpdate = false;
    private int max;
    public GameObject canvas;

    [HideInInspector]
    public string entry;

    public string[] items;

    [HideInInspector]
    public int currentID = 0;
    [HideInInspector]
    public int checkAmount = 0;
    [HideInInspector]
    public int selected = 0;

    private int maxTwo;
    private int maxThree;

    public Image[] UISlot;
    public Sprite[] magicIcons;
    public Sprite[] spellIcons;
    public KeyCode[] keys; 
    public int[] magicAttack;
    public bool set = false;
    public bool setTwo = false;

    // Start is called before the first frame update
    void Start()
    {
        inventoryMenu.SetActive(false);
        openBook.SetActive(false);
        closedBook.SetActive(true);
        potionBook.SetActive(false);
        max = emptySlots.Length;
        maxTwo = items.Length;
        maxThree = emptySlots.Length;
        audioSource = GetComponent<AudioSource>();

        //temporary
        redMushrooms = 0;
        purpleMushrooms = 0;
        brownMushrooms = 0;
        bluePlants = 0;
        redFlowers = 0;
        roots = 0;
        leafDew = 0;
        dragonEgg = 0;
        redPotion = 0;
        bluePotion = 0;
        greenPotion = 0;
        purplePotion = 0;
        bread = 0;
        cheese = 0;
        meat = 0;

    }

    // Update is called once per frame
    void Update()
    {
        if(iconUpdate == true)
        {
            for(int i =0; i < max; i++)
            {
                if (emptySlots[i].sprite == emptyIcon)
                {
                    max = i;
                    emptySlots[i].sprite = icons[newIcon];
                    emptySlots[i].transform.gameObject.GetComponent<HintMessage>().objectType = newIcon;
                }
            }
            StartCoroutine(Reset());
        }
        if(set == true)
        {
            for(int i =0; i < UISlot.Length; i++)
            {
                if (Input.GetKeyDown(keys[i]))
                {
                    set = false;
                    UISlot[i].sprite = magicIcons[selected];
                    magicAttack[i] = selected;
                    canvas.GetComponent<CreatePotion>().Remove(selected);
                }
            }
        }
        if (setTwo == true)
        {
            for (int i = 0; i < UISlot.Length; i++)
            {
                if (Input.GetKeyDown(keys[i]))
                {
                    setTwo = false;
                    UISlot[i].sprite = spellIcons[selected];
                    magicAttack[i] = selected += 6;
                }
            }
        }
    }

    public void CheckStats()
    {
        for(int i = 0; i < maxTwo; i++)
        {
            if(i == currentID)
            {
                maxTwo = i;
                entry = items[i];
                checkAmount = System.Convert.ToInt32(typeof(Inventory).GetField(entry).GetValue(null));
                checkAmount--;
                typeof(Inventory).GetField(entry).SetValue(null, checkAmount);
                if(checkAmount == 0)
                {
                    RemoveIcon(i);
                }
            }
        }
        maxTwo = items.Length;
    }

    public void RemoveIcon(int _iconType)
    {
        for(int i = 0; i < maxThree; i++)
        {
            if (emptySlots[i].sprite == icons[_iconType])
            {
                maxThree = i;
                emptySlots[i].sprite = icons[0];
                emptySlots[i].transform.gameObject.GetComponent<HintMessage>().objectType = 0;
            }
        }
        maxThree = emptySlots.Length;
    }

    public void OpenMenu()
    {
        messageBox.SetActive(false);
        inventoryMenu.SetActive(true);
        openBook.SetActive(true);
        closedBook.SetActive(false);
        audioSource.clip = bookOpenSound;
        audioSource.Play();
        Time.timeScale = 0;
    }

    public void CloseMenu()
    {
        inventoryMenu.SetActive(false);
        openBook.SetActive(false);
        closedBook.SetActive(true);
        audioSource.clip = bookOpenSound;
        audioSource.Play();
        Time.timeScale = 1;
    }
    public void OpenPotionBook()
    {
        potionBook.SetActive(true);
    }

    public void ClosePotionBook()
    {
        canvas.GetComponent<CreatePotion>().value = 0;
        canvas.GetComponent<CreatePotion>().thisValue = 0;
        potionBook.SetActive(false);
        audioSource.clip = selectSound;
        audioSource.Play();
    }

    IEnumerator Reset()
    {
        yield return new WaitForSeconds(0.1f);
        iconUpdate = false;
        max = emptySlots.Length;
    }
}
