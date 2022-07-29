using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleTarget : MonoBehaviour
{
    public float speed = 1.0f;
    public bool rotator = false;
    public bool particleTarget = true;
    public int damageAmount = 30;
    public GameObject lastObject; 

    // Update is called once per frame
    void Update()
    {
        if(rotator == true)
        {
            transform.Rotate(0, speed * Time.deltaTime, 0);
        }
        if(particleTarget == true)
        {
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Enemy") || other.CompareTag("Spider") && other.transform.gameObject != lastObject)
        {
            other.transform.gameObject.GetComponent<EnemyMovement>().enemyHealth -= damageAmount;
            lastObject = other.transform.gameObject;
        }
        if (other.CompareTag("Enemy") || other.CompareTag("Dragon") && other.transform.gameObject != lastObject)
        {
            other.transform.gameObject.GetComponent<Dragon>().enemyHealth -= damageAmount;
            lastObject = other.transform.gameObject;
        }
    }
}
