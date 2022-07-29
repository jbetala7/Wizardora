using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public float damageAmount = 0.007f;
    private WaitForSeconds delayTime = new WaitForSeconds(1);
    private bool canAttack = true;
    private AudioSource audioSource;


    // Start is called before the first frame update
    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            if(canAttack == true && SaveScript.invulnerable == false)
            {
                canAttack = false;
                SaveScript.playerHealth -= damageAmount - SaveScript.armourValue;
                audioSource.Play();
                StartCoroutine(ResetDamage());
            }
        }
    }

    IEnumerator ResetDamage()
    {
        yield return delayTime;
        canAttack = true;
    }

}
