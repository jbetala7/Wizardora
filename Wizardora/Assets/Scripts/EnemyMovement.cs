using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class EnemyMovement : MonoBehaviour
{
    public GameObject thisEnemy;
    public GameObject player;
    public GameObject mainCamera;
    public GameObject coins;
    public GameObject hitEffect;
    private Animator animator;
    private AnimatorStateInfo enemyInfo;
    private AudioSource audioSource;
    private AudioClip audioClip;
    public Image healthBar;
    public float attackRange = 3.0f;
    public int enemyHealth = 100;
    public float rotateSpeed = 50.0f;
    public bool isPlayerDead;
    private NavMeshAgent agent;
    private bool outlineOn = false;
    private float runRange = 70.0f;
    private float x;
    private float z;
    private float velocitySpeed;
    private float distance;
    private bool isAttacking = false;
    private int currentHealth;
    private bool isAlive = true;
    private float fillHealth;
    private WaitForSeconds hitOff = new WaitForSeconds(0.5f);


    // Start is called before the first frame update
    void Start()
    {
        thisEnemy.GetComponent<Outline>().enabled = false;
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        if(agent.CompareTag("Spider"))
        {
            agent.avoidancePriority = 1;
        }
        else
        {
            agent.avoidancePriority = Random.Range(5, 75);
        }
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

        healthBar.transform.LookAt(mainCamera.transform);

        if(isAlive == true && SaveScript.internalHouse == false)
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
            //calculate velocity speed
            x = agent.velocity.x;
            z = agent.velocity.z;
            velocitySpeed = x + z;

            if (velocitySpeed == 0)
            {
                animator.SetBool("running", false);
            }
            else
            {
                animator.SetBool("running", true);
                isAttacking = false;
            }

            enemyInfo = animator.GetCurrentAnimatorStateInfo(0);
            distance = Vector3.Distance(transform.position, player.transform.position);

            if(SaveScript.playerHealth <= 0)
            {
                isPlayerDead = true;
            }

            if (distance < attackRange || distance > runRange)
            {
                agent.isStopped = true;

                if(distance > runRange)
                {
                    SaveScript.enemiesOnScreen--;
                    Destroy(gameObject);
                }

                if (distance < attackRange && enemyInfo.IsTag("nonAttack") && !animator.IsInTransition(0))
                {
                    if(isPlayerDead)
                    {
                        return; 
                    }
                    if (isAttacking == false)
                    {
                        isAttacking = true;
                        animator.SetTrigger("attack");
                        Vector3 Position = (player.transform.position - transform.position).normalized;
                        Quaternion PositionRoation = Quaternion.LookRotation(new Vector3(Position.x, 0, Position.z));
                        transform.rotation = Quaternion.Slerp(transform.rotation, PositionRoation, rotateSpeed * Time.deltaTime);
                    }
                }
                if (distance < attackRange && enemyInfo.IsTag("attack"))
                {
                    if (isAttacking == true)
                    {
                        isAttacking = false;
                    }
                }
            }
            else if (distance > attackRange && enemyInfo.IsTag("nonAttack") && !animator.IsInTransition(0))
            {
                if(SaveScript.invisible == false)
                {
                    agent.isStopped = false;
                    agent.destination = player.transform.position;
                }
            }
            if(currentHealth > enemyHealth)
            {
                hitEffect.SetActive(true);
                currentHealth = enemyHealth;
                StartCoroutine(HitEffectOff());
                animator.SetTrigger("hit");
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

        if(SaveScript.internalHouse == true)
        {
            agent.isStopped = true;
            animator.SetBool("running", false);
            isAttacking = false;
        }
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
}
