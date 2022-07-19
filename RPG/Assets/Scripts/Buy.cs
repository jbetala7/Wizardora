using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Buy : MonoBehaviour
{
    public GameObject shopUI;

    //Arrays
    public int[] amount;
    public int[] cost;
    public int[] iconNumber;
    public int[] inventoryItems;
    public Text[] itemAmountText;


    public Text currencyText;
    private Text compare;
    public bool tavern = false; 
    private int max = 0;
    private bool canClick = true;

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
        if (canClick == true)
        {
            for (int i = 0; i < max; i++)
            {
                if (itemAmountText[i] == compare)
                {
                    max = i;
                    if (amount[i] > 0)
                    {
                        if (tavern == true)
                        {
                            UpdateTavernAmount();
                        }
                        else
                        {
                            UpdateWizardAmount();
                        }
                        if (Inventory.gold >= cost[i])
                        {
                            if (inventoryItems[i] == 0)
                            {
                                Inventory.newIcon = iconNumber[i];
                                Inventory.iconUpdate = true;
                            }
                            Inventory.gold -= cost[i];
                            if (tavern == true)
                            {
                                SetTavernAmount(i);
                            }
                            else
                            {
                                SetWizardAmount(i);
                            }
                        }
                    }
                }
            }
        }
    }

    void UpdateTavernAmount()
    {
        inventoryItems[0] = Inventory.bread;
        inventoryItems[1] = Inventory.cheese;
        inventoryItems[2] = Inventory.meat;
    }

    void UpdateWizardAmount()
    {
        inventoryItems[0] = Inventory.redPotion;
        inventoryItems[1] = Inventory.purplePotion;
        inventoryItems[2] = Inventory.bluePotion;
        inventoryItems[3] = Inventory.greenPotion;
        inventoryItems[4] = Inventory.dragonEgg;
        inventoryItems[5] = Inventory.roots;
        inventoryItems[6] = Inventory.leafDew;
    }

    public void UpdateGold()
    {
        currencyText.text = Inventory.gold.ToString();
    }

    void SetTavernAmount(int _item)
    {
        if(_item == 0)
        {
            Inventory.bread++;
        }
        if (_item == 1)
        {
            Inventory.cheese++;
        }
        if (_item == 2)
        {
            Inventory.meat++;
        }
        amount[_item]--;
        itemAmountText[_item].text = amount[_item].ToString();
        currencyText.text = Inventory.gold.ToString();
        max = itemAmountText.Length;
    }

    void SetWizardAmount(int _item)
    {
        if (_item == 0)
        {
            Inventory.redPotion++;
        }
        if (_item == 1)
        {
            Inventory.purplePotion++;
        }
        if (_item == 2)
        {
            Inventory.bluePotion++;
        }
        if (_item == 3)
        {
            Inventory.greenPotion++;
        }
        if (_item == 4)
        {
            Inventory.dragonEgg++;
        }
        if (_item == 5)
        {
            Inventory.roots++;
        }
        if (_item == 6)
        {
            Inventory.leafDew++;
        }
        amount[_item]--;
        itemAmountText[_item].text = amount[_item].ToString();
        currencyText.text = Inventory.gold.ToString();
        max = itemAmountText.Length;
    }

    public void Bread()
    {
        compare = itemAmountText[0];
        Check(0);
    }

    public void Cheese()
    {
        compare = itemAmountText[1];
        Check(1);
    }

    public void Meat()
    {
        compare = itemAmountText[2];
        Check(2);
    }

    public void RedPotion()
    {
        compare = itemAmountText[0];
        Check2(0);
    }

    public void PurplePotion()
    {
        compare = itemAmountText[1];
        Check2(1);
    }

    public void BluePotion()
    {
        compare = itemAmountText[2];
        Check2(2);
    }

    public void GreenPotion()
    {
        compare = itemAmountText[3];
        Check2(3);
    }

    public void DragonEgg()
    {
        compare = itemAmountText[4];
        Check2(4);
    }

    public void Roots()
    {
        compare = itemAmountText[5];
        Check2(5);
    }

    public void LeafDew()
    {
        compare = itemAmountText[6];
        Check2(6);
    }

    void Check(int _a)
    {
        if(amount[_a] > 0)
        { 
            canClick = true;
        }
        else
        {
            canClick = false;
        }
    }
    void Check2(int _b)
    {
        if (amount[_b] > 0)
        {
            canClick = true;
        }
        else
        {
            canClick = false;
        }
    }

}
