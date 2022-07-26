using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleMover : MonoBehaviour
{
    public GameObject target;
    public GameObject obj;
    public float speed = 4f;
    public float lifetime = 2f;
    public bool enemySeeker = false;
    public bool notMoving = false;
    public bool followPlayer = false;
    private GameObject playerObject;
    private GameObject saveTarget;
    public float manaDecreaseRate = 0.07f;
    public bool invisibility = false;
    public bool invulnerability = false;
    public bool healing = false;
    public bool strength = false;
    public int damageAmount = 30;
    public GameObject lastObject;

    // Start is called before the first frame update
    private void Start()
    {
        saveTarget = SaveScript.enemyTarget;
        playerObject = GameObject.FindGameObjectWithTag("Player");
        if(invisibility == true)
        {
            SaveScript.invisible = true;
        }
        if (invulnerability == true)
        {
            SaveScript.invulnerable = true;
        }
        if (strength == true)
        {
            SaveScript.strengthIncrease = 100;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(target != null)
        {
            transform.position = Vector3.LerpUnclamped(transform.position, target.transform.position, speed * Time.deltaTime);
        }
        if(enemySeeker == true)
        {
            if(saveTarget != null)
            {
                transform.position = Vector3.LerpUnclamped(transform.position, saveTarget.transform.position, speed * Time.deltaTime);
            }
            else
            {
                transform.Translate(Vector3.forward * speed * Time.deltaTime);
            }
        }
        if(notMoving == true)
        {
            if(saveTarget != null)
            {
                transform.position = saveTarget.transform.position;
            }
            else
            {
                Destroy(obj);
            }
        }
        if(followPlayer == true)
        {
            transform.position = playerObject.transform.position;
            lifetime = 100;
            if(SaveScript.manaAmount <= 0.01)
            {
                Destroy(obj);
            }
        }
        SaveScript.manaAmount -= manaDecreaseRate * Time.deltaTime;
        Destroy(obj, lifetime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy") || other.CompareTag("Spider") && other.transform.gameObject != lastObject)
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
