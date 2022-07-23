using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdateStats : MonoBehaviour
{
    public Text nameText;
    public Text currencyText;
    public Text killAmountText;
    public Image strengthBar;
    public Image manaBar;
    public Image staminaBar;
    public GameObject[] weaponButtons;
    public GameObject inventoryObject;
    public bool updateWeapons = true;
    public GameObject[] items;

    // Start is called before the first frame update
    void Start()
    {
        nameText.text = SaveScript.pName;
        if(SaveScript.pCharacter == 1 || SaveScript.pCharacter == 3 || SaveScript.pCharacter == 5)
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
