using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Enemy;

public class PlayerCombat : MonoBehaviour
{
    //public enum HeroAttackType { Melee, Ranged };
    //public HeroAttackType heroAttackType;

    //public GameObject targetedEnemy;
    //public float attackRange;
    //public float rotateSpeedForAttack;

    //private PlayerMovement moveScript;

    //public bool basicAtkIdle = false;
    //public bool isHeroAlive;
    //public bool performMeleeAttack = true;
    

    private void Start()
    {
        //moveScript = GetComponent<PlayerMovement>();
    }

    private void Update()
    {
        //if (targetedEnemy != null)
        //{
        //    if(Vector3.Distance(gameObject.transform.position, targetedEnemy.transform.position) > attackRange)
        //    {
        //        //moveScript.agent.SetDestionation(targetedEnemy.transform.position);
        //        Debug.Log("Out of Range");
        //    }
        //    else { Debug.Log("In range"); }
        //}
    }

    public void Attack()
    {
        Debug.Log("Whack!");
    }

}
