using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private GameObject objectToDestory;
    public int damageAmount;
    private bool canDamage = true;
    private WaitForSeconds damagePause = new WaitForSeconds(0.5f);

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
        if(other.CompareTag("Enemy") && canDamage == true)
        {
            canDamage = false;
            other.transform.gameObject.GetComponent<EnemyMovement>().enemyHealth -= damageAmount 
                + SaveScript.weaponIncrease + SaveScript.strengthIncrease;
            StartCoroutine(ResetDamage());
        }
        if (other.CompareTag("Spider") && canDamage == true)
        {
            canDamage = false;
            other.transform.gameObject.GetComponent<EnemyMovement>().enemyHealth -= (damageAmount / 8)
                + SaveScript.weaponIncrease + SaveScript.strengthIncrease;
            StartCoroutine(ResetDamage());
        }
        if (other.CompareTag("Dragon") && canDamage == true)
        {
            canDamage = false;
            other.transform.gameObject.GetComponent<Dragon>().enemyHealth -= (damageAmount / 8)
                + SaveScript.weaponIncrease + SaveScript.strengthIncrease;
            StartCoroutine(ResetDamage());
        }
    }

    IEnumerator WaitForDestory()
    {
        yield return new WaitForSeconds(3);
        Destroy(objectToDestory);
    }

    IEnumerator ResetDamage()
    {
        yield return damagePause;
        canDamage = true;
    }
}
