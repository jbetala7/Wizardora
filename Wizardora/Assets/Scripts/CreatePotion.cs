using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreatePotion : MonoBehaviour
{
    public int[] values;
    private int max;
    private int maxTwo;
    public GameObject inventoryObject;
    public Image[] emptySlots;
    public Sprite[] icons;
    public Sprite emptyIcon;

    [HideInInspector]
    public int expectedValue;
    [HideInInspector]
    public int value;
    [HideInInspector]
    public int itemID = 0;
    [HideInInspector]
    public int thisValue;
    [HideInInspector]
    public AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        expectedValue = values[0];
        max = emptySlots.Length;
        maxTwo = emptySlots.Length;
        audioSource = inventoryObject.GetComponent<AudioSource>();
        Create();
    }

    public void Create()
    {
        if(expectedValue == value)
        {
            for (int i = 0; i < max; i++)
            {
                if (emptySlots[i].sprite == emptyIcon)
                {
                    max = i;
                    emptySlots[i].sprite = icons[itemID];
                    emptySlots[i].transform.gameObject.GetComponent<HintMessage>().objectType = itemID + 20;
                    audioSource.clip = inventoryObject.GetComponent<Inventory>().createPotionSound;
                    audioSource.Play();
                    value = 0;
                    thisValue = 0;
                }
            }
            max = emptySlots.Length;
        }
    }

    public void Remove(int _index)
    {
        for(int i = 0; i < maxTwo; i++)
        {
            if (emptySlots[i].sprite == icons[_index])
            {
                maxTwo = i;
                emptySlots[i].sprite = emptyIcon;
                emptySlots[i].transform.gameObject.GetComponent<HintMessage>().objectType = 0;
            }
        }
        maxTwo = emptySlots.Length;
    }

    public void UpdateValues()
    {
        value += thisValue;
        expectedValue = values[itemID];
    }
}
