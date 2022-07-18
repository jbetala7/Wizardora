using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour
{
    private Animator animator;
    public int goldAmount = 50;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            if(Inventory.key == true)
            {
                animator.SetTrigger("open");
                Inventory.gold += goldAmount;
                goldAmount = 0;
                Debug.Log("Gold amount =" + Inventory.gold);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (Inventory.key == true)
            {
                animator.SetTrigger("close");
            }
        }
    }

    public void DestoryGold()
    {
        Destroy(gameObject);
    }
}
