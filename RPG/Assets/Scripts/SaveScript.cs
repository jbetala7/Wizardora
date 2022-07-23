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
    public static bool invisible = false;
    public static float strengthPowerAmount = 0.1f;
    public static float manaPowerAmount = 0.1f;
    public static float staminaPowerAmount = 0.1f;
    public static int killAmount = 0;
    public static int weaponChoice = 0;
    public static bool changeWeapon = true;



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
            manaAmount += 0.05f * Time.deltaTime;
        }
        if (manaAmount <= 0)
        {
            manaAmount = 0;
        }
        if(manaAmount < 0.02)
        {
            invisible = false;
        }
    }
}
