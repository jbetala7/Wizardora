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
    public GameObject inventoryScreen;
    public GameObject statsScreen;
    public GameObject deedsScreen;
    public GameObject characterDisplay;
    private AudioSource audioSource;
    public AudioClip bookOpenSound;
    public AudioClip selectSound;
    public AudioClip buySound;
    public AudioClip createPotionSound;
    public AudioClip pickupSound;

    private GameObject playerObject;
    private Animator playerAnimation;
    private float weightAmount = 1.0f;
    private bool changeWeight = false;
    private AnimatorStateInfo playerInfo;

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
    public static bool key = false;
    public static int dragonEgg = 0;
    public static int redPotion = 0;
    public static int bluePotion = 0;
    public static int greenPotion = 0;
    public static int purplePotion = 0;
    public static int bread = 0;
    public static int cheese = 0;
    public static int meat = 0;


    public static int newIcon = 0;
    public static int gold = 7000;
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

    public GameObject[] magicParticles;
    public AudioClip[] magicSounds;
    public Image manaBar;
    public Image staminaBar;
    public Image healthBar;
    public bool[] weapons;
    public Text[] messages;
    private int maxFour;
    private GameObject miniMapView;
    private GameObject miniMapCompass;
    public GameObject mapScreen;
    public GameObject mapCamera;
    public GameObject magicUI;
    public GameObject spellsUI;
    public GameObject optionsScreen;
    public GameObject tutorialsScreen;
    private bool optionsOpen = false;

    private void Awake()
    {
        if(SaveScript.newGame == true)
        {
            tutorialsScreen.SetActive(true);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        inventoryMenu.SetActive(false);
        openBook.SetActive(false);
        closedBook.SetActive(true);
        potionBook.SetActive(false);
        deedsScreen.SetActive(false);
        optionsScreen.SetActive(false);
        
        max = emptySlots.Length;
        maxTwo = items.Length;
        maxThree = emptySlots.Length;
        maxFour = messages.Length;
        audioSource = GetComponent<AudioSource>();
        playerObject = GameObject.FindGameObjectWithTag("Player");
        playerAnimation = playerObject.GetComponent<Animator>();
        miniMapView = GameObject.FindGameObjectWithTag("MiniMapItem");
        miniMapCompass = GameObject.FindGameObjectWithTag("Compass");

        if(SaveScript.newGame == true)
        {
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
            gold = 300;
            newIcon = 0;
            iconUpdate = false;
        }

    }

    // Update is called once per frame
    void Update()
    {
        if(SaveScript.newGame == true)
        {
            SaveScript.newGame = false;
        }
        playerInfo = playerAnimation.GetCurrentAnimatorStateInfo(1);
        healthBar.fillAmount = SaveScript.playerHealth;

        if (iconUpdate == true)
        {
            for (int i = 0; i < max; i++)
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
        if (set == true)
        {
            for (int i = 0; i < UISlot.Length; i++)
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
        if (Input.anyKey && Time.timeScale == 1)
        {
            for (int i = 0; i < UISlot.Length; i++)
            {
                if (Input.GetKeyDown(keys[i]))
                {
                    if (UISlot[i].sprite != emptyIcon)
                    {
                        if(SaveScript.manaAmount > 0.1f)
                        {
                            Instantiate(magicParticles[magicAttack[i]], SaveScript.firePoint.transform.position,
                                SaveScript.firePoint.transform.rotation);
                            audioSource.clip = magicSounds[magicAttack[i]];
                            audioSource.Play();
                            playerAnimation.SetTrigger("magicAttack");
                            playerAnimation.SetLayerWeight(1, 1);
                            weightAmount = 1;
                        }
                        if (magicAttack[i] < 6 && SaveScript.manaAmount > 0.1)
                        {
                            UISlot[i].sprite = emptyIcon;
                        }
                        if (magicAttack[i] >=6 && magicAttack[i] <= 12 && SaveScript.manaAmount > 0.1)
                        {
                            UISlot[i].sprite = emptyIcon;
                        }
                    }
                }
            }
        }
        manaBar.fillAmount = SaveScript.manaAmount;

        if(SaveScript.staminaAmount != staminaBar.fillAmount)
        {
            staminaBar.fillAmount = Mathf.Lerp(staminaBar.fillAmount, SaveScript.staminaAmount, 2 * Time.deltaTime);
        }

        if(playerInfo.IsTag("magic"))
        {
            changeWeight = true;
        }

        if(changeWeight == true)
        {
            weightAmount -= 0.3f * Time.deltaTime;
            playerAnimation.SetLayerWeight(1, weightAmount);
            if(weightAmount <= 0)
            {
                changeWeight = false;
            }
        }
        if(bread == 0)
        {
            RemoveIcon(14);
        }
        if (cheese == 0)
        {
            RemoveIcon(15);
        }
        if (meat == 0)
        {
            RemoveIcon(16);
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

    public void UpdateMessages(string _message)
    {
        for(int i = 0; i < maxFour; i++)
        {
            if (messages[i].text == "empty")
            {
                maxFour = i;
                messages[i].text = _message;
            }
        }
        maxFour = messages.Length;
    }

    public void OpenOptions()
    {
        if(optionsOpen == false)
        {
            optionsScreen.SetActive(true);
            audioSource.clip = selectSound;
            audioSource.Play();
            Time.timeScale = 0;
            optionsOpen = true;
        }
        else if (optionsOpen == true)
        {
            optionsScreen.SetActive(false);
            audioSource.clip = selectSound; 
            audioSource.Play();
            Time.timeScale = 1;
            optionsOpen = false;
        }
    }

    public void OpenMenu()
    {
        messageBox.SetActive(false);
        inventoryMenu.SetActive(true);
        openBook.SetActive(true);
        closedBook.SetActive(false);
        audioSource.clip = bookOpenSound;
        audioSource.Play();
        SaveScript.enemyTarget = null;
        OpenInventoryScreen();
        miniMapView.SetActive(false);
        miniMapCompass.SetActive(false);
        Time.timeScale = 0;
    }

    public void CloseMenu()
    {
        inventoryMenu.SetActive(false);
        openBook.SetActive(false);
        closedBook.SetActive(true);
        audioSource.clip = bookOpenSound;
        audioSource.Play();
        characterDisplay.SetActive(false);
        mapScreen.SetActive(false);
        mapCamera.SetActive(false);
        miniMapView.SetActive(true);
        miniMapCompass.SetActive(true);
        Time.timeScale = 1;
    }

    public void OpenInventoryScreen()
    {
        deedsScreen.SetActive(false);
        statsScreen.SetActive(false);
        characterDisplay.SetActive(false);
        mapScreen.SetActive(false);
        mapCamera.SetActive(false);
        inventoryScreen.SetActive(true);
    }

    public void OpenStatsScreen()
    {
        deedsScreen.SetActive(false);
        inventoryScreen.SetActive(false);
        mapScreen.SetActive(false);
        mapCamera.SetActive(false);
        statsScreen.SetActive(true);
        characterDisplay.SetActive(true);
        characterDisplay.GetComponent<CharacterDisplay>().ChangeArmourDisplay();
        statsScreen.GetComponent<UpdateStats>().updateWeapons = true;
    }
    public void OpenDeedsScreen()
    {
        inventoryScreen.SetActive(false);
        statsScreen.SetActive(false);
        characterDisplay.SetActive(false);
        mapScreen.SetActive(false);
        mapCamera.SetActive(false);
        deedsScreen.SetActive(true);
        deedsScreen.GetComponent<Deeds>().canUpdate = true;
    }

    public void OpenMapsScreen()
    {
        inventoryScreen.SetActive(false);
        statsScreen.SetActive(false);
        characterDisplay.SetActive(false);
        deedsScreen.SetActive(false);
        mapScreen.SetActive(true);
        mapCamera.SetActive(true);
    }

    public void OpenPotionBook()
    {
        potionBook.SetActive(true);
        canvas.GetComponent<CreatePotion>().value = 0;
        canvas.GetComponent<CreatePotion>().thisValue = 0;
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
