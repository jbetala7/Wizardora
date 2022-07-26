using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    public static float playerHealth = 0.1f;
    public static int strengthIncrease = 0;
    public static float armourValue = 0;
    public static int enemiesOnScreen;

    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this);
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
    }
}
