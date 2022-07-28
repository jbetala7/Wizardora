using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStartPosition : MonoBehaviour
{
    public GameObject[] characters;
    public Transform spawnPoint;

    // Start is called before the first frame update
    void Start()
    {
        Instantiate(characters[SaveScript.pCharacter], spawnPoint.position, spawnPoint.rotation);
        PlayerMovement.canMove = true;
    }

}
