using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Cinemachine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    public GameObject[] playerObjects;
    public GameObject[] weapons;
    public GameObject[] armourTorso;
    public GameObject[] armourLegs;
    public GameObject firePoint;
    public NavMeshAgent agent;
    public GameObject staticCamera;
    public GameObject freeCamera;
    public GameObject hitEffect;
    private Animator animator;
    public AudioSource audioSource;
    public AudioClip[] weaponSounds;
    private Ray ray;
    private RaycastHit hit;
    private float x;
    private float z;
    private float velocitySpeed;
    private bool freeCameraActive = false;
    private AnimatorStateInfo playerInfo;
    private GameObject trailObject;
    private float currentHealth = 1.0f;
    private WaitForSeconds approachEnemy = new WaitForSeconds(0.3f);
    private WaitForSeconds trailTimeOff = new WaitForSeconds(0.1f);
    private WaitForSeconds hitOff = new WaitForSeconds(0.5f);
    CinemachineTransposer transposer;
    CinemachineOrbitalTransposer transposer1;
    private Vector3 position;
    private Vector3 currentPosition;
    private string axisNamed = "Mouse X";
    public float[] staminaCost;
    public static bool canMove = true;
    public static bool isMoving = false;
    public LayerMask moveLayer;
    public string[] attacks;

    // Start is called before the first frame update
    void Start()
    {
        canMove = true;
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
        hitEffect.SetActive(false);

        agent.enabled = false;
        Invoke("EnableNavMesh", 0.1f);
    }

    // Update is called once per frame
    void Update()
    {
        //listent to the animator
        playerInfo = animator.GetCurrentAnimatorStateInfo(0);

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
            StartCoroutine(TurnOffTrail());
        }

        if(Input.GetKeyDown(KeyCode.Z))
        {
            if (SaveScript.carryingWeapon == true && SaveScript.staminaAmount > 0.2)
            {
                animator.SetTrigger(attacks[SaveScript.weaponChoice]);
                audioSource.clip = weaponSounds[SaveScript.weaponChoice];
                SaveScript.staminaAmount -= staminaCost[SaveScript.weaponChoice];
            }
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            if (SaveScript.carryingWeapon == true)
            {
                SaveScript.carryingWeapon = false;
                weapons[SaveScript.weaponChoice].SetActive(false);
            }
        }

        if (Input.GetMouseButtonDown(0) && playerInfo.IsTag("nonAttack") && !animator.IsInTransition(0))
        {
            if(canMove == true)
            {
                //changes 2D position of the mouse to effective 3D posiiton for the character
                ray = Camera.main.ScreenPointToRay(Input.mousePosition);

                if (Physics.Raycast(ray, out hit, 500, moveLayer))
                {
                    if(hit.transform.gameObject.CompareTag("Enemy") || hit.transform.gameObject.CompareTag("SmallSkeletons") || 
                        hit.transform.gameObject.CompareTag("OrcPigs") || hit.transform.gameObject.CompareTag("Skeletons") || 
                        hit.transform.gameObject.CompareTag("WolfRiders") || hit.transform.gameObject.CompareTag("Spider") || hit.transform.gameObject.CompareTag("Dragon"))
                    {
                        agent.isStopped = false;
                        SaveScript.enemyTarget = hit.transform.gameObject;
                        agent.destination = hit.point;
                        transform.LookAt(SaveScript.enemyTarget.transform);
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
            if(SaveScript.carryingWeapon == false)
            {
                animator.SetBool("sprinting", true);
                animator.SetBool("carryingWeapon", false);
            }
            if (SaveScript.carryingWeapon == true)
            {
                animator.SetBool("sprinting", true);
                animator.SetBool("carryingWeapon", true);
            }
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
                currentPosition = position / 100;
            }
        }

        if(Input.GetMouseButtonUp(1))
        {
            transposer1.m_XAxis.m_InputAxisName = null;
            transposer1.m_XAxis.m_InputAxisValue = 0;
        }

        if(Input.GetKeyDown(KeyCode.C))
        {
            if(freeCameraActive == false)
            {
                freeCamera.SetActive(true);
                staticCamera.SetActive(false);
                freeCameraActive = true;
            }
            else if (freeCameraActive == true)
            {
                freeCamera.SetActive(false);
                staticCamera.SetActive(true);
                freeCameraActive = false;
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
                if(SaveScript.carryingWeapon == true)
                {
                    weapons[SaveScript.weaponChoice].SetActive(false);
                }
            }
        }
        if (SaveScript.manaAmount <= 0.1)
        {
            if (SaveScript.invisible == false)
            {
                for (int i = 0; i < playerObjects.Length; i++)
                {
                    playerObjects[i].SetActive(true);
                    SaveScript.changeArmour = true;
                }
                if (SaveScript.carryingWeapon == true)
                {
                    weapons[SaveScript.weaponChoice].SetActive(true);
                }
            }
        }
        if(SaveScript.changeArmour == true)
        {
            for (int i = 0; i < armourTorso.Length; i++)
            {
                armourTorso[i].SetActive(false);
            }
            armourTorso[SaveScript.armour].SetActive(true);
            for (int i = 0; i < armourLegs.Length; i++)
            {
                armourLegs[i].SetActive(false);
            }
            armourLegs[SaveScript.armour].SetActive(true);
            SaveScript.changeArmour = false;
        }

        if(currentHealth > SaveScript.playerHealth)
        {
            hitEffect.SetActive(true);
            currentHealth = SaveScript.playerHealth;
            StartCoroutine(HitEffectOff());
        }
    }

    void EnableNavMesh()
    {
        agent.enabled = true;
    }

    public void PlayWeaponSound()
    {
        audioSource.Play();
    }

    public void TrailOn()
    {
        trailObject.GetComponent<Renderer>().enabled = true;
    }
    public void TrailOff()
    {
        trailObject.GetComponent<Renderer>().enabled = false;
    }

    IEnumerator MoveTo()
    {
        yield return approachEnemy;
        agent.isStopped = true;
    }

    IEnumerator TurnOffTrail()
    {
        yield return trailTimeOff;
        trailObject = GameObject.Find("Trail");
        trailObject.GetComponent<Renderer>().enabled = false;

    }

    IEnumerator HitEffectOff()
    {
        yield return hitOff;
        hitEffect.SetActive(false);
    }
}
