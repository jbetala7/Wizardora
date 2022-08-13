using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonParticle : MonoBehaviour
{
    public float speed = 1.0f;
    public float damageAmount = 0.1f;
    public GameObject parentObject;

    // Start is called before the first frame update
    void Start()
    {
        Invoke("DestroyParticle", 4);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<Animator>().SetTrigger("hurt");
            other.GetComponent<PlayerMovement>().agent.isStopped = true;
            SaveScript.playerHealth -= damageAmount;
            Destroy(parentObject.gameObject);
        }
    }

    void DestroyParticle()
    {
        Destroy(parentObject.gameObject);
    }
}
