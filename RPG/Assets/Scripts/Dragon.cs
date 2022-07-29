using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class Dragon : MonoBehaviour
{
    public GameObject thisEnemy;
    private bool outlineOn = false;
    private NavMeshAgent agent;
    private Animator animator;
    private AnimatorStateInfo enemyInfo;
    public GameObject player;
    private float distance;
    private bool isAttacking = false;
    public float closeRange = 7.0f;
    public float farRange = 21f;
    private float runRange = 49.0f;
    public int enemyHealth = 100;
    private int currentHealth;
    private bool isAlive = true;
    private AudioSource audioSource;
    public Image healthBar;
    private float fillHealth;
    public GameObject mainCamera;
    public float rotateSpeed = 50.0f;
    public GameObject coins;
    public GameObject hitEffect;
    private WaitForSeconds hitOff = new WaitForSeconds(0.5f);
    private AudioClip audioClip;
    public GameObject fireball;
    public Transform fireSpawnPoint;
    private bool canBreathFire = true;
    private WaitForSeconds firePause = new WaitForSeconds(2);


    // Start is called before the first frame update
    void Start()
    {
        thisEnemy.GetComponent<Outline>().enabled = false;
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        agent.avoidancePriority = 1;
        currentHealth = enemyHealth;
        audioSource = GetComponent<AudioSource>();
        healthBar.enabled = false;
        hitEffect.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(mainCamera == null)
        {
            mainCamera = GameObject.Find("Main Camera");
        }

        healthBar.transform.LookAt(mainCamera.transform.position);

        if(isAlive == true)
        {
            if (outlineOn == false)
            {
                outlineOn = true;
                if (SaveScript.enemyTarget == thisEnemy)
                {
                    thisEnemy.GetComponent<Outline>().enabled = true;
                    healthBar.enabled = true;
                }
            }
            if (outlineOn == true)
            {
                if (SaveScript.enemyTarget != thisEnemy)
                {
                    thisEnemy.GetComponent<Outline>().enabled = false;
                    outlineOn = false;
                    healthBar.enabled = false;
                }
            }
            if (player == null)
            {
                player = GameObject.FindGameObjectWithTag("Player");
            }

            enemyInfo = animator.GetCurrentAnimatorStateInfo(0);
            distance = Vector3.Distance(transform.position, player.transform.position);

            if (distance < farRange || distance > runRange)
            {
                agent.isStopped = true;

                if (distance < closeRange && enemyInfo.IsTag("nonAttack") && !animator.IsInTransition(0))
                {
                    if (isAttacking == false)
                    {
                        isAttacking = true;
                        animator.SetTrigger("tailAttack");
                        Vector3 Position = (player.transform.position - transform.position).normalized;
                        Quaternion PositionRoation = Quaternion.LookRotation(new Vector3(Position.x, 0, Position.z));
                        transform.rotation = Quaternion.Slerp(transform.rotation, PositionRoation, rotateSpeed * Time.deltaTime);
                    }
                }
                if (distance < farRange && distance > closeRange && enemyInfo.IsTag("nonAttack") && !animator.IsInTransition(0))
                {
                    if (isAttacking == false && canBreathFire == true)
                    {
                        isAttacking = true;
                        canBreathFire = false;
                        animator.SetTrigger("fireAttack");
                        Vector3 Position = (player.transform.position - transform.position).normalized;
                        Quaternion PositionRoation = Quaternion.LookRotation(new Vector3(Position.x, 0, Position.z));
                        transform.rotation = Quaternion.Slerp(transform.rotation, PositionRoation, rotateSpeed * Time.deltaTime);
                        StartCoroutine(ResetFire());
                    }
                }
                if (distance < farRange && enemyInfo.IsTag("attack"))
                {
                    if (isAttacking == true)
                    {
                        isAttacking = false;
                    }
                }
            }
            if(currentHealth > enemyHealth)
            {
                hitEffect.SetActive(true);
                animator.SetTrigger("hit");
                currentHealth = enemyHealth;
                StartCoroutine(HitEffectOff());
                currentHealth = enemyHealth;
                audioSource.Play();
                fillHealth = enemyHealth;
                fillHealth /= 100.0f;
                healthBar.fillAmount = fillHealth;
            }
        }
        if(enemyHealth <= 1 && isAlive == true)
        {
            isAlive = false;
            agent.isStopped = true;
            animator.SetTrigger("death");
            SaveScript.enemiesOnScreen--;
            thisEnemy.GetComponent<Outline>().enabled = false;
            outlineOn = false;
            healthBar.enabled = false;
            agent.avoidancePriority = 1;
            StartCoroutine(IsDead());
        }
    }

    public void ShootFireball()
    {
        fireSpawnPoint.transform.LookAt(player.transform.position);
        Instantiate(fireball, fireSpawnPoint.position, fireSpawnPoint.rotation);
    }

    IEnumerator IsDead()
    {
        yield return new WaitForSeconds(1);
        Instantiate(coins, transform.position, transform.rotation);
        SaveScript.killAmount++;
        Destroy(gameObject, 0.2f);
    }

    IEnumerator HitEffectOff()
    {
        yield return hitOff;
        hitEffect.SetActive(false);
    }

    IEnumerator ResetFire()
    {
        yield return firePause;
        canBreathFire = true;
    }
}
