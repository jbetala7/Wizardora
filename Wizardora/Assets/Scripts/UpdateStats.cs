using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdateStats : MonoBehaviour
{
    public GameObject[] items;
    public GameObject[] weaponButtons;
    public GameObject inventoryObject;
    public Text nameText;
    public Text currencyText;
    public Text killAmountText;
    public Image strengthBar;
    public Image manaBar;
    public Image staminaBar;
    public bool updateWeapons = true;
    

    // Start is called before the first frame update
    void Start()
    {
        nameText.text = SaveScript.pName;
        if(SaveScript.pCharacter == 0 || SaveScript.pCharacter == 2 || SaveScript.pCharacter == 4)
        {
            items[0].SetActive(true);
        }
        else
        {
            items[1].SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        currencyText.text = Inventory.gold.ToString();
        killAmountText.text = SaveScript.killAmount.ToString();
        strengthBar.fillAmount = SaveScript.strengthPowerAmount;
        manaBar.fillAmount = SaveScript.manaPowerAmount;
        staminaBar.fillAmount = SaveScript.staminaPowerAmount;

        if(updateWeapons == true)
        {
            for(int i = 0; i < weaponButtons.Length; i++)
            {
                if (inventoryObject.GetComponent<Inventory>().weapons[i] == true)
                {
                    weaponButtons[i].SetActive(true);
                }
            }
        }
        if(this.isActiveAndEnabled)
        {
            updateWeapons = false;
        }
    }
}
