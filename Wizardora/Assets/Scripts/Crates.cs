using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Crates : MonoBehaviour
{
    public GameObject particleEffect;
    public GameObject particlesPoint;
    public GameObject textCanvas;
    [HideInInspector]
    public GameObject mainCamera;
    [HideInInspector]
    public GameObject inventoryObject;
    public Text goldAmountText;
    private Animator animator;
    public AudioClip openChestClip;
    private int goldAmount;
    private int goldDisplay;
    public float speed = 1.0f;


    // Start is called before the first frame update
    void Start()
    {
        inventoryObject = GameObject.Find("InventoryCanvas");

        if (mainCamera == null)
        {
            mainCamera = GameObject.Find("Main Camera");
        }
        goldAmount = Random.Range(20, 100);
        textCanvas.SetActive(false);
        goldDisplay = goldAmount;
    }

    // Update is called once per frame
    private void Update()
    {
        if (textCanvas.activeSelf == true)
        {
            textCanvas.transform.Translate(Vector3.up * speed * Time.deltaTime);
            goldAmountText.text = goldDisplay.ToString();
            textCanvas.transform.LookAt(mainCamera.transform, Vector3.up);
            textCanvas.transform.Rotate(Vector3.up * 180);
        }
    }

    public void DestoryGold()
    {
        Destroy(gameObject);
    }

    public void GoldAmount()
    {
        Instantiate(particleEffect, particlesPoint.transform.position, particlesPoint.transform.rotation);
        textCanvas.SetActive(true);
        Inventory.gold += goldAmount;
        goldAmount = 0;
        inventoryObject.GetComponent<AudioSource>().clip = openChestClip;
        inventoryObject.GetComponent<AudioSource>().Play();
    }
}
