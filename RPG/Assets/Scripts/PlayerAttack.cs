using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private GameObject objectToDestory;
    public int damageAmount;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Crate"))
        {
            other.transform.gameObject.GetComponentInParent<Chest>().GoldAmount();
            objectToDestory = other.transform.parent.gameObject;
            Destroy(other.transform.gameObject);
            StartCoroutine(WaitForDestory());
        }
    }

    IEnumerator WaitForDestory()
    {
        yield return new WaitForSeconds(3);
        Destroy(objectToDestory);
    }
}
