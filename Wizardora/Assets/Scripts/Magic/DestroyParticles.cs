using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyParticles : MonoBehaviour
{
    public float lifetime = 2.0f;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, lifetime);
    }
}
