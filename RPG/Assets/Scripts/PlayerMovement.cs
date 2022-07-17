using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerMovement : MonoBehaviour
{
    private NavMeshAgent agent;
    private Animator animator;
    private Ray ray;
    private RaycastHit hit;

    private float x;
    private float z;
    private float velocitySpeed;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //calculate velocity speed
        x = agent.velocity.x;
        z = agent.velocity.z;
        velocitySpeed = x + z;

        if(Input.GetMouseButtonDown(0))
        {
            //changes 2D position of the mouse to effective 3D posiiton for the character
            ray = Camera.main.ScreenPointToRay(Input.mousePosition); 
            
            if(Physics.Raycast(ray, out hit))
            {
                agent.destination = hit.point;
            }
        }

        if(velocitySpeed != 0)
        {
            animator.SetBool("sprinting", true);
        }
        if (velocitySpeed == 0)
        {
            animator.SetBool("sprinting", false);
        }
    }
}
