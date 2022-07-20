using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PotionBook : MonoBehaviour
{
    public Image magicIcon;
    public Text magicName;
    public Text magicDescription;

    [HideInInspector]
    public AudioSource audioSource;
    public GameObject inventoryObject;

    public Sprite[] magicSprites;
    public string[] names;
    public string[] descriptions;
    public GameObject[] iconSets;
    private int currentIcon = 0;
    public GameObject canvas;

    // Start is called before the first frame update
    void Start()
    {
        magicIcon.sprite = magicSprites[0];
        magicName.text = names[0];
        magicDescription.text = descriptions[0];
        audioSource = inventoryObject.GetComponent<AudioSource>();
        iconSets[0].SetActive(true);

    }

    public void Next()
    {
        if(currentIcon < magicSprites.Length - 1)
        {
            audioSource.clip = inventoryObject.GetComponent<Inventory>().selectSound;
            audioSource.Play();
            currentIcon++;
            magicIcon.sprite = magicSprites[currentIcon];
            magicName.text = names[currentIcon];
            magicDescription.text = descriptions[currentIcon];
            SwitchOff();
            iconSets[currentIcon].SetActive(true);
            canvas.GetComponent<CreatePotion>().itemID++;
            canvas.GetComponent<CreatePotion>().value = 0;
            canvas.GetComponent<CreatePotion>().thisValue = 0;
        }
    }

    void SwitchOff()
    {
        for(int i = 0; i < iconSets.Length; i++)
        {
            iconSets[i].SetActive(false);
        }
    }

    public void Back()
    {
        if (currentIcon > 0)
        {
            audioSource.clip = inventoryObject.GetComponent<Inventory>().selectSound;
            audioSource.Play();
            currentIcon--;
            magicIcon.sprite = magicSprites[currentIcon];
            magicName.text = names[currentIcon];
            magicDescription.text = descriptions[currentIcon];
            SwitchOff();
            iconSets[currentIcon].SetActive(true);
            canvas.GetComponent<CreatePotion>().itemID--;
            canvas.GetComponent<CreatePotion>().value = 0;
            canvas.GetComponent<CreatePotion>().thisValue = 0;
        }
    }
}
