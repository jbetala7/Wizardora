using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    public GameObject[] enemies;
    public Transform[] spawnPoints;
    [HideInInspector]
    public GameObject mainCamera;
    private bool canSpawn = true;
    public bool reSpawn = true;
    bool isEndGame;
    public List<GameObject> endGameList;
    bool areEnemiesSpawn;

    void Start()
    {
        if (gameObject.name == "SpawnObjectBlueDragon")
        {
            isEndGame = true;
        }
    }

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
                }
                mainCamera.GetComponent<AudioManager>().musicState = 1;
                mainCamera.GetComponent<AudioManager>().canPlay = true;
            }
        }
        if (endGameList.Count <= 0 && areEnemiesSpawn)
        {
            WinGame.Instance.isWinGame = true;
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
                    if (isEndGame)
                    {
                        areEnemiesSpawn = true;
                        Instantiate(enemies[i], spawnPoints[i].position, spawnPoints[i].rotation);
                        endGameList.Add(enemies[i]);
                    }
                    else
                    {
                        Instantiate(enemies[i], spawnPoints[i].position, spawnPoints[i].rotation);
                    }
                    SaveScript.enemiesOnScreen++;
                    mainCamera.GetComponent<AudioManager>().musicState = 3;
                    mainCamera.GetComponent<AudioManager>().canPlay = true;
                }
            }
        }
    }
}
