using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.SceneManagement;

public class SaveScript : MonoBehaviour
{
    public static int pCharacter = 0;
    public static string pName = "player";
    public static GameObject firePoint;
    public static GameObject enemyTarget;
    public static float manaAmount = 1.0f;
    public static float staminaAmount = 1.0f;
    public static float strengthPowerAmount = 0.1f;
    public static float manaPowerAmount = 0.1f;
    public static float staminaPowerAmount = 0.1f;
    public static float playerLevel = 0.1f;
    public static int killAmount = 0;
    public static int weaponChoice = 0;
    public static bool changeWeapon = false;
    public static bool carryingWeapon = false;
    public static int armour = 0;
    public static bool changeArmour = false;
    public static bool invisible = false;
    public static bool invulnerable = false;
    private int checkAmount = 7;
    public static int weaponIncrease;
    public static float playerHealth = 1.0f;
    public static int strengthIncrease = 0;
    public static float armourValue = 0;
    public static int enemiesOnScreen;
    public static bool internalHouse = false;

    public static bool saving = false;
    public static bool continueData = false;
    private bool checkForLoad = false;
    private GameObject inventoryObject;

    //public save data
    public int pCharacterS;
    public string pNameS;
    public float manaPowerAmountS;
    public float staminaPowerAmountS;
    public float strengthPowerAmountS;
    public int killAmountS;
    public int weaponChoiceS;
    public bool carryingWeaponS;
    public int armourS;
    public float playerLevelS;
    public int weaponIncreaseS;
    public float playerHealthS;
    public int strengthIncreaseS;
    public float armourValueS;
    public int goldS;
    public bool keyS;
    public int redMushroomsS;
    public int purpleMushroomsS;
    public int brownMushroomsS;
    public int bluePlantsS;
    public int redFlowersS;
    public int rootsS;
    public int leafDewS;
    public int dragonEggS;
    public int redPotionS;
    public int bluePotionS;
    public int greenPotionS;
    public int purplePotionS;
    public int breadS;
    public int cheeseS;
    public int meatS;
    public bool magicCollectedS;
    public bool spellsCollectedS;
    public bool[] weaponS;
    public int[] objectTypeS;
    public static bool newGame = false;
    public static int instance = 0;

    public static bool notSavedYet = true;

    private void Awake()
    {
        instance++;
    }

    // Start is called before the first frame update
    void Start()
    {
        if(instance > 1)
        {
            Destroy(gameObject);
        }
        else
        { 
            DontDestroyOnLoad(this);
        }

        DontDestroyOnLoad(this);

        if(newGame == true)
        {
            pName = "player";
            manaAmount = 1.0f;
            staminaAmount = 1.0f;
            strengthPowerAmount = 0.1f;
            manaPowerAmount = 0.1f;
            staminaPowerAmount = 0.1f;
            invisible = false;
            invulnerable = false;
            killAmount = 0;
            weaponChoice = 0;
            changeWeapon = false;
            carryingWeapon = false;
            armour = 0;
            changeArmour = false;
            playerLevel = 0.1f;
            weaponIncrease = 0;
            playerHealth = 1.0f;
            strengthIncrease = 0;
            armourValue = 0;
            enemiesOnScreen = 0;
            CollectBook.magicCollected = false;
            CollectBook.spellsCollected = false;
            newGame = false;
        }

        if(continueData == true)
        {
            string fileLocation = Application.persistentDataPath + "/save.dat";
            StreamReader reader = new StreamReader(fileLocation);
            string saveData = reader.ReadToEnd();
            reader.Close();
            JsonUtility.FromJsonOverwrite(saveData, this);

            pCharacter = pCharacterS;
            continueData = false;
            checkForLoad = true;
        }
    }

    // Update is called once per frame
    private void Update()
    {
        if(manaAmount < 1.0)
        {
            manaAmount += (manaPowerAmount / 10 + 0.05f) * Time.deltaTime;
        }
        if (manaAmount <= 0)
        {
            manaAmount = 0;
        }
        if(manaAmount < 0.02)
        {
            invisible = false;
            invulnerable = false;
            strengthIncrease = 0;
        }
        if (staminaAmount < 1.0)
        {
            staminaAmount += (staminaPowerAmount / 10 + 0.05f) * Time.deltaTime;
        }
        if (staminaAmount <= 0)
        {
            staminaAmount = 0;
        }
        if(killAmount == checkAmount)
        {
            playerLevel += 0.1f;
            checkAmount = killAmount + 7;
            strengthPowerAmount = playerLevel;
            staminaPowerAmount = playerLevel;
            manaPowerAmount = playerLevel;
            weaponIncrease = System.Convert.ToInt32(strengthPowerAmount * 90);
        }

        if(armour == 1)
        {
            armourValue = 0.002f;
        }
        if (armour == 2)
        {
            armourValue = 0.004f;
        }

        if(saving == true)
        {
            saving = false;
            notSavedYet = false;
            if(inventoryObject == null)
            {
;                inventoryObject = GameObject.Find("InventoryCanvas");
            }
            pCharacterS = pCharacter;
            pNameS = pName;
            manaPowerAmountS = manaPowerAmount;
            staminaPowerAmountS = staminaPowerAmount;
            strengthPowerAmountS = strengthPowerAmount;
            killAmountS = killAmount;
            weaponChoiceS = weaponChoice;
            carryingWeaponS = carryingWeapon;
            armourS = armour;
            playerLevelS = playerLevel;
            weaponIncreaseS = weaponIncrease;
            playerHealthS = playerHealth;
            strengthIncreaseS = strengthIncrease;
            armourValueS = armourValue;
            goldS = Inventory.gold;
            keyS = Inventory.key;
            redMushroomsS = Inventory.redMushrooms;
            purpleMushroomsS = Inventory.purpleMushrooms;
            brownMushroomsS = Inventory.brownMushrooms;
            bluePlantsS = Inventory.bluePlants;
            redFlowersS = Inventory.redFlowers;
            rootsS = Inventory.roots;
            leafDewS = Inventory.leafDew;
            dragonEggS = Inventory.dragonEgg;
            redPotionS = Inventory.redPotion;
            bluePotionS = Inventory.bluePotion;
            greenPotionS = Inventory.greenPotion;
            purplePotionS = Inventory.purplePotion;
            breadS = Inventory.bread;
            cheeseS = Inventory.cheese;
            meatS = Inventory.meat;
            magicCollectedS = CollectBook.magicCollected;
            spellsCollectedS = CollectBook.spellsCollected;
            weaponS = inventoryObject.GetComponent<Inventory>().weapons;

            for(int i = 0; i < 16; i++)
            {
                objectTypeS[i] = inventoryObject.GetComponent<Inventory>().emptySlots[i].transform.gameObject.GetComponent<HintMessage>().objectType;
            }

            string saveData = JsonUtility.ToJson(this);
            string fileLocation = Application.persistentDataPath + "/save.dat";
            StreamWriter writer = new StreamWriter(fileLocation);
            writer.WriteLine(saveData);
            writer.Close();
        }
        if(checkForLoad == true)
        {
            int sceneNumber = SceneManager.GetActiveScene().buildIndex;
            if(sceneNumber == 2)
            {
                if(inventoryObject == null)
                {
                    inventoryObject = GameObject.Find("InventoryCanvas");
                }
                if(inventoryObject != null)
                {
                    PlayerMovement.canMove = true;
                    pName = pNameS;
                    strengthPowerAmount = strengthPowerAmountS;
                    manaPowerAmount = manaPowerAmountS;
                    staminaPowerAmount = staminaPowerAmountS;
                    killAmount = killAmountS;
                    weaponChoice = weaponChoiceS;
                    carryingWeapon = carryingWeaponS;
                    armour = armourS;
                    playerLevel = playerLevelS;
                    weaponIncrease = weaponIncreaseS;
                    playerHealth = playerHealthS;
                    strengthIncrease = strengthIncreaseS;
                    armourValue = armourValueS;
                    Inventory.gold = goldS;
                    Inventory.key = keyS;
                    Inventory.redMushrooms = redMushroomsS;
                    Inventory.purpleMushrooms = purpleMushroomsS;
                    Inventory.brownMushrooms = brownMushroomsS;
                    Inventory.bluePlants = bluePlantsS;
                    Inventory.redFlowers = redFlowersS;
                    Inventory.roots = rootsS;
                    Inventory.leafDew = leafDewS;
                    Inventory.dragonEgg = dragonEggS;
                    Inventory.redPotion = redPotionS;
                    Inventory.bluePotion = bluePotionS;
                    Inventory.greenPotion = greenPotionS;
                    Inventory.purplePotion = purplePotionS;
                    Inventory.bread = breadS;
                    Inventory.cheese = cheeseS;
                    Inventory.meat = meatS;
                    CollectBook.magicCollected = magicCollectedS;
                    CollectBook.spellsCollected = spellsCollectedS;
                    if(magicCollectedS == true)
                    {
                        inventoryObject.GetComponent<Inventory>().magicUI.SetActive(true);
                    }
                    if (spellsCollectedS == true)
                    {
                        inventoryObject.GetComponent<Inventory>().spellsUI.SetActive(true);
                    }
                    inventoryObject.GetComponent<Inventory>().weapons = weaponS;
                    if(carryingWeapon == true)
                    {
                        changeWeapon = true;
                    }
                    if (armour > 0)
                    {
                        changeArmour = true;
                    }
                    for (int i = 0; i < 16; i++)
                    {
                        inventoryObject.GetComponent<Inventory>().emptySlots[i].sprite = inventoryObject.GetComponent<Inventory>().icons[objectTypeS[i]];
                        inventoryObject.GetComponent<Inventory>().emptySlots[i].transform.gameObject.GetComponent<HintMessage>().objectType = objectTypeS[i];
                    }
                    checkForLoad = false;
                }
            }
        }
    }
}
