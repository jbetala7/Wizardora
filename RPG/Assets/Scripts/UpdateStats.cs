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

    // Start is called before the first frame update
    void Start()
    {
        nameText.text = SaveScript.pName;
    }

    // Update is called once per frame
    void Update()
    {
        currencyText.text = Inventory.gold.ToString();
        killAmountText.text = SaveScript.killAmount.ToString();
        strengthBar.fillAmount = SaveScript.strengthPowerAmount;
        manaBar.fillAmount = SaveScript.manaPowerAmount;
        staminaBar.fillAmount = SaveScript.staminaPowerAmount;
    }
}
