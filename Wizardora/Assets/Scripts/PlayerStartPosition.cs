using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStartPosition : MonoBehaviour
{
    public static PlayerStartPosition instance { get; set; }
    GameObject playerToSpawn;
    public GameObject[] characters;
    public Transform spawnPoint;

    [HideInInspector]
    public float xPos;
    [HideInInspector]
    public float yPos;
    [HideInInspector]
    public float zPos;

    bool canChangePosition = true;

    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        xPos = PlayerPrefs.GetFloat("X");
        yPos = PlayerPrefs.GetFloat("Y");
        zPos = PlayerPrefs.GetFloat("Z");

        playerToSpawn = Instantiate(characters[SaveScript.pCharacter], spawnPoint.position, spawnPoint.rotation);

        if (PlayerPrefs.GetInt("IsPlayerSaved") == 1)
        {
            playerToSpawn.transform.position = new Vector3(xPos, yPos, zPos);
        }
    }

    void Update()
    {
        if (canChangePosition)
        {
            foreach (Transform child in playerToSpawn.transform)
            {
                if (child.tag == "Player")
                {
                    if (child.transform.localPosition != Vector3.zero)
                    {
                        child.transform.localPosition = Vector3.zero;

                        StartCoroutine(DisableChangePosition());
                    }
                }
            }
        }
    }

    IEnumerator DisableChangePosition()
    {
        yield return new WaitForSeconds(1.5f);

        canChangePosition = false;
    }

}
