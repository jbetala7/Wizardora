using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    public GameObject thisEnemy;
    private bool outlineOn = false;
    private NavMeshAgent agent;
    private Animator animator;
    private AnimatorStateInfo enemyInfo;
    private float x;
    private float z;
    private float velocitySpeed;
    public GameObject player;
    private float distance;
    private bool isAttacking = false;
    public float attackRange = 3.0f;
    public float runRange = 14.0f;

    // Start is called before the first frame update
    void Start()
    {
        thisEnemy.GetComponent<Outline>().enabled = false;
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(outlineOn == false)
        {
            outlineOn = true;
            if(SaveScript.enemyTarget == thisEnemy)
            {
                thisEnemy.GetComponent<Outline>().enabled = true;
            }
        }
        if (outlineOn == true)
        {
            if (SaveScript.enemyTarget != thisEnemy)
            {
                thisEnemy.GetComponent<Outline>().enabled = false;
                outlineOn = false;
            }
        }
        if(player == null)
        {
            player = GameObject.FindGameObjectWithTag("Player");
        }
        //calculate velocity speed
        x = agent.velocity.x;
        z = agent.velocity.z;
        velocitySpeed = x + z;

        if(velocitySpeed == 0)
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

        if(distance < attackRange || distance > runRange)
        {
            agent.isStopped = true;
            if(distance < attackRange && enemyInfo.IsTag("nonAttack"))
            {
                if(isAttacking == false)
                {
                    isAttacking = true;
                    animator.SetTrigger("attack");
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
        else
        {
            agent.isStopped = false;
            agent.destination = player.transform.position;
        }
    }
}
