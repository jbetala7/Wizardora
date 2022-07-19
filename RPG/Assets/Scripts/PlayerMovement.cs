using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Cinemachine;

public class PlayerMovement : MonoBehaviour
{
    private NavMeshAgent agent;
    private Animator animator;
    private Ray ray;
    private RaycastHit hit;

    private float x;
    private float z;
    private float velocitySpeed;

    CinemachineTransposer transposer;
    public CinemachineVirtualCamera playerCamera;
    private Vector3 position;
    private Vector3 currentPosition;

    public static bool canMove = true;
    public static bool isMoving = false;
    public LayerMask moveLayer;

    public GameObject freeCamera;
    public GameObject staticCamera;
    private bool freeCameraActive = true;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        transposer = playerCamera.GetCinemachineComponent<CinemachineTransposer>();
        currentPosition = transposer.m_FollowOffset;
        freeCamera.SetActive(true);
        staticCamera.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        //calculate velocity speed
        x = agent.velocity.x;
        z = agent.velocity.z;
        velocitySpeed = x + z;

        //get mouse position
        position = Input.mousePosition;
        transposer.m_FollowOffset = currentPosition;

        if(Input.GetMouseButtonDown(0))
        {
            if(canMove == true)
            {
                //changes 2D position of the mouse to effective 3D posiiton for the character
                ray = Camera.main.ScreenPointToRay(Input.mousePosition);

                if (Physics.Raycast(ray, out hit, 300, moveLayer))
                {
                    agent.destination = hit.point;
                }
            }
        }

        if(velocitySpeed != 0)
        {
            animator.SetBool("sprinting", true);
            isMoving = true;
        }
        if (velocitySpeed == 0)
        {
            animator.SetBool("sprinting", false);
            isMoving = false;
        }

        if(Input.GetMouseButton(1))
        {
            if(position.x != 0 || position.y != 0)
            {
                currentPosition = position / 200;
            }
        }

        if(Input.GetKeyDown(KeyCode.C))
        {
            if(freeCameraActive == true)
            {
                freeCamera.SetActive(false);
                staticCamera.SetActive(true);
                freeCameraActive = false;
            }
            else if (freeCameraActive == false)
            {
                freeCamera.SetActive(true);
                staticCamera.SetActive(false);
                freeCameraActive = true;
            }
        }
    }
}
