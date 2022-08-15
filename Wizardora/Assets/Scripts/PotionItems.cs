using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PotionItems : MonoBehaviour
{
    public GameObject canvas;
    public GameObject inventory;
    public int objectID;
    [HideInInspector]
    public Image thisImage;
    [HideInInspector]
    public Color32 initialColour = new Color32(255, 255, 255, 120);
    [HideInInspector]
    public Color32 endColour = new Color32(255, 255, 255, 255);
    private bool check = true;

    // Start is called before the first frame update
    void Start()
    {
        thisImage = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        if(canvas.GetComponent<CreatePotion>().thisValue == objectID)
        {
            thisImage.color = endColour;
            if(check == true)
            {
                check = false;
                inventory.GetComponent<Inventory>().currentID = objectID;
                inventory.GetComponent<Inventory>().CheckStats();
            }
        }
        if (canvas.GetComponent<CreatePotion>().thisValue == 0)
        {
            check = true;
            thisImage.color = initialColour;
        }
    }
}
