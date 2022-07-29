using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayArmour : MonoBehaviour
{
    public GameObject[] armourTorso;
    public GameObject[] armourLegs;

    public void UpdateArmour()
    {
        for (int i = 0; i < armourTorso.Length; i++)
        {
            armourTorso[i].SetActive(false);
        }
        armourTorso[SaveScript.armour].SetActive(true);
        for (int i = 0; i < armourLegs.Length; i++)
        {
            armourLegs[i].SetActive(false);
        }
        armourLegs[SaveScript.armour].SetActive(true);
    }

}
