using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniMap : MonoBehaviour
{
    private GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(FindPlayer());
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (player != null)
        {
            Vector3 position = player.transform.position;
            position.y = transform.position.y;
            transform.position = position;
        }
    }

    IEnumerator FindPlayer()
    {
        yield return new WaitForSeconds(1);
        player = GameObject.FindGameObjectWithTag("Player");
    }    
}
