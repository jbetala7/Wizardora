using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectBook : MonoBehaviour
{
    public GameObject magicUI;
    public GameObject spellsUI;
    private bool magicCollected = false;
    private bool spellsCollected = false;
    public bool magicBook = false;
    public bool spellsBook = false;

    // Start is called before the first frame update
    void Start()
    {
        if(magicBook == true)
        {
            magicUI.SetActive(false);
        }
        if (spellsBook == true)
        {
            spellsUI.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            if(magicBook == true)
            {
                if (magicCollected == false)
                {
                    magicUI.SetActive(true);
                    magicCollected = true;
                    Destroy(gameObject);

                }
            }
            if (spellsBook == true)
            {
                if (spellsCollected == false)
                {
                    spellsUI.SetActive(true);
                    spellsCollected = true;
                    Destroy(gameObject);

                }
            }
        }
    }
}
