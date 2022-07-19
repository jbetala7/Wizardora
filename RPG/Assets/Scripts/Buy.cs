using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Buy : MonoBehaviour
{
    public GameObject shopUI;

    //arrays
    public int[] amount;
    public int[] cost;
    public int[] iconNumber;
    public int[] inventoryItems;
    public Text[] itemAmountText;
    public Text currencyText;
    private Text compare;
    public bool tavern = false;
    private int max = 0;

    // Start is called before the first frame update
    void Start()
    {
        max = itemAmountText.Length;
        currencyText.text = Inventory.gold.ToString();
    }

    public void CloseShop()
    {
        shopUI.SetActive(false);
    }

    public void BuyButton()
    {

    }
}
