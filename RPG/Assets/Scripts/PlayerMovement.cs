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
    CinemachineOrbitalTransposer transposer1;
    private Vector3 position;
    private Vector3 currentPosition;
    private string axisNamed = "Mouse X";

    public static bool canMove = true;
    public static bool isMoving = false;
    public LayerMask moveLayer;

    public GameObject staticCamera;
    public GameObject freeCamera;
    private bool freeCameraActive = true;

    public GameObject firePoint;
    private WaitForSeconds approachEnemy = new WaitForSeconds(0.3f);
    public GameObject[] playerObjects;
    public GameObject[] weapons;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        transposer = freeCamera.gameObject.GetComponent<CinemachineVirtualCamera>().GetCinemachineComponent<CinemachineTransposer>();
        transposer1 = staticCamera.gameObject.GetComponent<CinemachineVirtualCamera>().GetCinemachineComponent<CinemachineOrbitalTransposer>();
        currentPosition = transposer.m_FollowOffset;
        freeCamera.SetActive(false);
        staticCamera.SetActive(true);
        SaveScript.firePoint = firePoint;
        for(int i = 0; i < weapons.Length; i++)
        {
            weapons[i].SetActive(false);
        }
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

        //load correct weapon
        if(SaveScript.changeWeapon == true)
        {
            SaveScript.changeWeapon = false;
            for (int i = 0; i < weapons.Length; i++)
            {
                weapons[i].SetActive(false);
            }
            weapons[SaveScript.weaponChoice].SetActive(true);
        }

        if(Input.GetMouseButtonDown(0))
        {
            if(canMove == true)
            {
                //changes 2D position of the mouse to effective 3D posiiton for the character
                ray = Camera.main.ScreenPointToRay(Input.mousePosition);

                if (Physics.Raycast(ray, out hit, 300, moveLayer))
                {
                    if(hit.transform.gameObject.CompareTag("Enemy"))
                    {
                        agent.isStopped = false;
                        SaveScript.enemyTarget = hit.transform.gameObject;
                        agent.destination = hit.point;
                        StartCoroutine(MoveTo());
                    }
                    else
                    {
                        SaveScript.enemyTarget = null;
                        agent.destination = hit.point;
                        agent.isStopped = false;
                    }
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
            transposer1.m_XAxis.m_InputAxisName = axisNamed;
            if(position.x != 0 || position.y != 0)
            {
                currentPosition = position / 70;
            }
        }

        if(Input.GetMouseButtonUp(1))
        {
            transposer1.m_XAxis.m_InputAxisName = null;
            transposer1.m_XAxis.m_InputAxisValue = 0;
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
        if (playerObjects[0].activeSelf == true)
        {
            if(SaveScript.invisible == true)
            {
                for(int i = 0; i < playerObjects.Length; i++)
                {
                    playerObjects[i].SetActive(false);
                }
            }
        }
        if (playerObjects[0].activeSelf == false)
        {
            if (SaveScript.invisible == false)
            {
                for (int i = 0; i < playerObjects.Length; i++)
                {
                    playerObjects[i].SetActive(true);
                }
            }
        }
    }

    IEnumerator MoveTo()
    {
        yield return approachEnemy;
        agent.isStopped = true;
    }
}
