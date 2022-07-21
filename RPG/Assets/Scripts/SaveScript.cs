using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveScript : MonoBehaviour
{
    public static int pCharacter = 0;
    public static string pName = "player";
    public static GameObject firePoint;
    public static GameObject enemyTarget;


    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this);
    }
}
