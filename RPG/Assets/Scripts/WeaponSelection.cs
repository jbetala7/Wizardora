using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSelection : MonoBehaviour
{
    public int weaponNumber;
    public AudioSource audioSource;
    public AudioClip weaponSelectionClip;

    public void ChooseWeapon()
    {
        SaveScript.weaponChoice = weaponNumber;
        SaveScript.changeWeapon = true;
        SaveScript.carryingWeapon = true;
        audioSource.clip = weaponSelectionClip;
        audioSource.Play();
    }
}
