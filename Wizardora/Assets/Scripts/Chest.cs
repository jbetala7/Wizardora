using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Chest : MonoBehaviour
{
    private Animator animator;
    private int goldAmount;
    public GameObject particleEffect;
    public GameObject particlesPoint;
    public GameObject canvas;
    public Text goldAmountText;
    public float speed = 1.0f;
    public GameObject mainCamera;
    private int goldDisplay;
    public GameObject inventoryObject;
    public AudioClip openChestClip;
    public bool crate = false;

    // Start is called before the first frame update
    void Start()
    {
        inventoryObject = GameObject.Find("InventoryCanvas");

        if (mainCamera == null)
        {
            mainCamera = GameObject.Find("Main Camera");
        }

        if (crate == false)
        {
            animator = GetComponent<Animator>();
        }
        canvas.SetActive(false);
        if (crate == true)
        {
            goldAmount = Random.Range(20, 100);
        }
        else
        {
            goldAmount = Random.Range(100, 500);
        }
        goldDisplay = goldAmount;
    }

    // Update is called once per frame
    private void Update()
    {
        if (canvas.activeSelf == true)
        {
            canvas.transform.Translate(Vector3.up * speed * Time.deltaTime);
            goldAmountText.text = goldDisplay.ToString();
            canvas.transform.LookAt(mainCamera.transform, Vector3.up);
            canvas.transform.Rotate(Vector3.up * 180);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (crate == false)
        {
            if (other.CompareTag("Player"))
            {
                if (Inventory.key == true)
                {
                    animator.SetTrigger("open");
                    Inventory.gold += goldAmount;
                    goldAmount = 0;
                    inventoryObject.GetComponent<AudioSource>().clip = openChestClip;
                    inventoryObject.GetComponent<AudioSource>().Play();
                }
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (crate == false)
        {
            if (other.CompareTag("Player"))
            {
                if (Inventory.key == true)
                {
                    animator.SetTrigger("close");
                }
            }
        }
    }

    public void DestoryGold()
    {
        Destroy(gameObject);
    }

    public void GoldAmount()
    {
        Instantiate(particleEffect, particlesPoint.transform.position, particlesPoint.transform.rotation);
        canvas.SetActive(true);
        if (crate == true)
        {
            Inventory.gold += goldAmount;
            goldAmount = 0;
            inventoryObject.GetComponent<AudioSource>().clip = openChestClip;
            inventoryObject.GetComponent<AudioSource>().Play();
        }
    }
}
