using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Chest : MonoBehaviour
{
    public GameObject particleEffect;
    public GameObject particlesPoint;
    public GameObject textCanvas;
    public GameObject imageCanvas;
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
        animator = GetComponent<Animator>();
        textCanvas.SetActive(false);
        imageCanvas.SetActive(false);
        goldAmount = Random.Range(100, 500);
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

    private void OnTriggerEnter(Collider other)
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
            if (Inventory.key == false)
            {
                imageCanvas.SetActive(true);
                StartCoroutine(Deactivate());
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (Inventory.key == true)
            {
                animator.SetTrigger("close");
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
        textCanvas.SetActive(true);
    }

    IEnumerator Deactivate()
    {
        yield return new WaitForSeconds(3);
        imageCanvas.SetActive(false);
    }
}
