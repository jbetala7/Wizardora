using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    public GameObject[] enemies;
    public Transform[] spawnPoints;
    public GameObject mainCamera;
    private bool canSpawn = true;
    public bool reSpawn = true;

    // Update is called once per frame
    void Update()
    {
        if (mainCamera == null)
        {
            mainCamera = GameObject.Find("Main Camera");
        }

        if (SaveScript.enemiesOnScreen <= 0)
        {
            if(canSpawn == false)
            {
                if(reSpawn == true)
                {
                    canSpawn = true;
                    mainCamera.GetComponent<AudioManager>().musicState = 1;
                    mainCamera.GetComponent<AudioManager>().canPlay = true;
                }
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            if(canSpawn == true)
            {
                canSpawn = false;
                for(int i = 0; i < enemies.Length; i++)
                {
                    Instantiate(enemies[i], spawnPoints[i].position, spawnPoints[i].rotation);
                    SaveScript.enemiesOnScreen++;
                    mainCamera.GetComponent<AudioManager>().musicState = 3;
                    mainCamera.GetComponent<AudioManager>().canPlay = true;
                }
            }
        }
    }
}
