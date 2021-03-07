using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Player;
using UnityEngine.InputSystem;
using Enemy;

public class PlayerCombat : MonoBehaviour
{
    public float Distance = -1f;
    public float AttackRange = 10f;
    public bool Target = false;
    public bool InRange = false;
    private bool InCombat = false;
    public bool Attacking = true;
    public GameObject TargetedEnemy;
    public float turnSpeed = 90f;

    //projectile variables
    public GameObject projectile;
    public Transform shotPoint;
    public float AttackCooldown = 0; //rename later 
    public float AttackInterval = 3; //rename later

    private void Update()
    {
        //(directly below) lets player move the enemy after it has been selected, so that they 
        //can move elswhere
        if (InCombat)
        {
            DetermineDistance(TargetedEnemy.transform.position); //Is the player in range?
            if (PlayerVariables.PlayerFocus == "Enemy")
            {
                if (InRange) { PerformAttack(); }
                else if (!InRange) { MovePlayer(); }
            }
            else { Attacking = false; }

            if (Target) { AttackCooldown -= Time.deltaTime; }
        }
    }

    //Set targeted enemy, determine the distance between player and enemy
    public void Attack(GameObject Enemy)
    {
        if (!Target)
        {
            InCombat = true;
            TargetedEnemy = Enemy;
            Target = true;
            //DetermineDistance(Enemy.transform.position);
        }
    }

    //Determine distance between player and enemy
    private void DetermineDistance(Vector3 enemyPosition)
    {
        Distance = Vector3.Distance(enemyPosition,
            Player.PlayerVariables.PlayerGameObject.transform.position);
        if (Distance > AttackRange) { InRange = false; }
        else { InRange = true; }
    }

    //Moves Player to get in attack range
    private void MovePlayer()
    {
        Player.PlayerVariables.Agent.SetDestination(TargetedEnemy.transform.position);
        DetermineDistance(TargetedEnemy.transform.position);      
    }

    //Perform the attack 
    private void PerformAttack()
    {
        
        //Stop player from moving 
        PlayerVariables.Agent.SetDestination(PlayerVariables.PlayerGameObject.transform.position);

        //rotate towards target
        //Attack
        if (AttackCooldown <= 0)
        {
            //fire projectile
            RotateTowards(TargetedEnemy.transform.position);
            Instantiate(projectile, shotPoint.position, transform.rotation);
            AttackCooldown = AttackInterval;
        }
    }

    private void RotateTowards(Vector3 to)
    {
        Quaternion _lookRotation =
    Quaternion.LookRotation((to - transform.position).normalized);

        PlayerVariables.PlayerGameObject.transform.rotation = _lookRotation;
    }
}
  