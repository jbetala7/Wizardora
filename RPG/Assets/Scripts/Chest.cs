using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Chest : MonoBehaviour
{
    private Animator animator;
    public int goldAmount = 50;
    public GameObject particleEffect;
    public GameObject particlesPoint;
    public GameObject canvas;
    public Text goldAmountText;
    public float speed = 1.0f;
    public GameObject mainCamera;
    private int goldDisplay;
    public GameObject inventoryCanvas;
    public AudioClip openChestClip;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        canvas.SetActive(false);
        goldDisplay = goldAmount;
    }

    // Update is called once per frame
    private void Update()
    {
        if(canvas.activeSelf == true)
        {
            canvas.transform.Translate(Vector3.up * speed * Time.deltaTime);
            goldAmountText.text = goldDisplay.ToString();
            canvas.transform.LookAt(mainCamera.transform.position);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            if(Inventory.key == true)
            {
                animator.SetTrigger("open");
                Inventory.gold += goldAmount;
                goldAmount = 0;
                inventoryCanvas.GetComponent<AudioSource>().clip = openChestClip;
                inventoryCanvas.GetComponent<AudioSource>().Play();
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
        canvas.SetActive(true);
    }
}
