using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathScreen : MonoBehaviour
{
    public Animator animator;
    private GameObject saveObject;

    // Update is called once per frame
    void Update()
    {
        if(SaveScript.playerHealth <= 0)
        {
            animator.SetTrigger("death");
            StartCoroutine(WaitToReload());
        }
    }

    IEnumerator WaitToReload()
    {
        yield return new WaitForSeconds(2f);
        SaveScript.playerHealth = 1.0f;
        SaveScript.instance = 0;
        saveObject = GameObject.Find("SaveObject");
        Destroy(saveObject);
        SceneManager.LoadScene(0);
    }
}
