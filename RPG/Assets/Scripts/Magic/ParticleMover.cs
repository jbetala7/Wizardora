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
    

    // Start is called before the first frame update
    private void Start()
    {
        saveTarget = SaveScript.enemyTarget;
        playerObject = GameObject.FindGameObjectWithTag("Player");
        if(invisibility == true)
        {
            SaveScript.invisible = true;
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
}
