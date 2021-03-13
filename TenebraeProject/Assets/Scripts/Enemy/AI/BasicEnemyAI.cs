using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public delegate void Calc(GameObject x);

public class BasicEnemyAI : MonoBehaviour
{
    //General state machine variables
    private GameObject player;
    private Animator animator;
    private RaycastHit hit;
    private float maxDistanceToCheck = 6.0f;
    private float currentDistance;
    private Vector3 checkDirection;
    private float distanceTillAgro = 10f;

    //Patrol state variables
    //float xMax = 3f;
    //float yMax = 3f;
    public Vector3 UpperRightZone;
    public Vector3 BottomLeftZone;
    public Vector3 NewPoint;
    public float Z_Point;
    public float X_Point;
    public NavMeshAgent navMeshAgent;
    public bool EnterCombat = false;

    private int currentTarget;
    private float distanceFromTarget;

    private void Awake()
    {
        Calc c = CalcZoneBotLeft; c += CalcZoneUpRight;
        c(gameObject); //creates Idle Square Zone
        player = GameObject.FindWithTag("Player");
        animator = gameObject.GetComponent<Animator>();
        navMeshAgent = gameObject.GetComponent<NavMeshAgent>();
        NewPoint = new Vector3();
        SetNextPoint();
    }

    private void FixedUpdate()
    {
        //First we check distance from the player
        currentDistance = Vector3.Distance(player.transform.position, transform.position);
        animator.SetFloat("distanceFromPlayer", currentDistance);
        if (currentDistance < distanceTillAgro && !EnterCombat)
        {
            animator.SetBool("IsIdle", false);
            EnterCombat = true;
            Invoke("StartCombat", 0.1f);
        }

        //Then check for visability
        checkDirection = player.transform.position - transform.position;
        Ray ray = new Ray(transform.position, checkDirection);
        if (Physics.Raycast(ray, out hit, maxDistanceToCheck))
        {
            if (hit.collider.gameObject == player)
            {
                animator.SetBool("isPlayerVisible", true);
            }
            else
            {
                animator.SetBool("isPlayerVisible", false);
            }
        }

        //Lastly get distance to next waypoint target
        distanceFromTarget = Vector3.Distance(NewPoint, transform.position);
        animator.SetFloat("distanceFromPoint", distanceFromTarget);
    }

    public void SetNextPoint()
    {
        Z_Point = Random.Range(BottomLeftZone.z, UpperRightZone.z);
        X_Point = Random.Range(BottomLeftZone.x, UpperRightZone.x);
        NewPoint.y = gameObject.transform.position.y;
        NewPoint.z = Z_Point;
        NewPoint.x = X_Point;
        navMeshAgent.SetDestination(NewPoint);
    }
    
    //making a 'square', wherever the enemy spawns
    public void CalcZoneUpRight (GameObject x)
    {
        Vector3 temp = x.transform.position;
        temp.x += 3;
        temp.z += 3;
        UpperRightZone = temp; //assign
    }
    public void CalcZoneBotLeft (GameObject x)
    {
        Vector3 temp = x.transform.position;
        temp.x -= 3;
        temp.z -= 3;
        BottomLeftZone = temp; //asign
    }

    private void StartCombat()
    {
        animator.SetBool("IsIdle", true);
    }

    public void Chase()
    {
        navMeshAgent.SetDestination(player.transform.position);
    }
}
