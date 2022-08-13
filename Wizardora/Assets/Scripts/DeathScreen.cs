using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathScreen : MonoBehaviour
{
    public Animator animator;
    private GameObject saveObject;
    public GameObject player;

    // Update is called once per frame
    void Update()
    {
        if(SaveScript.playerHealth <= 0)
        {
            if(player == null)
            {
                player = GameObject.FindWithTag("Player");
            }
            Invoke("StartDeathScreen", 2f);
            player.GetComponent<PlayerMovement>().enabled = true;
            player.GetComponent<Animator>().SetTrigger("die");
        }
    }

    void StartDeathScreen()
    {
        animator.SetTrigger("death");
        StartCoroutine(WaitToReload());
    }

    IEnumerator WaitToReload()
    {
        yield return new WaitForSeconds(2f);
        SaveScript.playerHealth = 1.0f;
        SaveScript.instance = 0;
        saveObject = GameObject.Find("SaveObject");
    }

    public void No()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void Yes()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
