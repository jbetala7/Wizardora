using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterDisplay : MonoBehaviour
{
    public GameObject[] charactersDisplay;


    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < charactersDisplay.Length; i++)
        {
            charactersDisplay[i].SetActive(false);
        }
        charactersDisplay[SaveScript.pCharacter].SetActive(true);
    }

    public void ChangeArmourDisplay()
    {
        charactersDisplay[SaveScript.pCharacter].GetComponent<DisplayArmour>().UpdateArmour();    
    }

}
