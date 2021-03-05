using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Player;
using UnityEngine.InputSystem;
using Enemy;

public class PlayerCombat : MonoBehaviour
{
    private float RotationSpeed = 500f;
    public float Distance = -1f;
    public float AttackRange = 10f;
    public bool Target = false;
    public bool InRange = false;
    private bool AttentionReset = true;
    GameObject TargetedEnemy;

    private void Update()
    {
        //(directly below) lets player move the enemy after it has been selected, so that they 
        //can move elswhere
        if (Target)
        {
            DetermineDistance(TargetedEnemy.transform.position); //Is the player in range?

            if (Player.PlayerVariables.PlayerFocus == "Enemy") //only care about attacking / moving when focus is the enemy
            {
                if (InRange) { PerformAttack(TargetedEnemy); } //determine distance and attack
                else { MovePlayer(); }  //move player
            }
        }
    }

    //Rotating the player when in range of the target (close combat) 
    private void LateUpdate()
    {
        if (Target)
        {
            if (InRange)
            {
                DeterminePlayerRotation(TargetedEnemy);
                AttentionReset = false;
            }
            else if (AttentionReset == false)
            {
                ResetAttention(); //rotates the player normally
                AttentionReset = true;
            }
        }
    }

    //Set targeted enemy, determine the distance between player and enemy
    public void Attack(GameObject Enemy)
    {
        TargetedEnemy = Enemy;
        Target = true;
        DetermineDistance(Enemy.transform.position);
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
    private void PerformAttack(GameObject Enemy)
    {
        //Stop player from moving
        if (Player.PlayerVariables.PlayerFocus == "Enemy")
        {
            //Stop player from moving 
            Player.PlayerVariables.Agent.SetDestination(Player.PlayerVariables.PlayerGameObject.transform.position);
            //Attack
            Debug.Log("Whacked!!!");
        }
    }

    private void DeterminePlayerRotation(GameObject Enemy)
    {
        ////Rotating agent around objects smoothly when agent is moving
        //if (Player.PlayerVariables.Agent.velocity.sqrMagnitude > Mathf.Epsilon)
        //{
        //    //Step size is equal to speed times frame time (needed for RotateTowarwds paramter below)
        //    var step = RotationSpeed * Time.deltaTime;
        //    if (InRange)
        //    {
        //        Vector3 vector = Enemy.transform.position - Player.PlayerVariables.PlayerGameObject.transform.position;
        //        Quaternion LookAtRotation = Quaternion.LookRotation(vector.normalized);
        //        transform.rotation = Quaternion.Lerp(transform.rotation, LookAtRotation, step); //smooth rotation between old and new rotation}
        //    }          
        //}
        
    }
    
    private void ResetAttention()
    {
        
        //transform.rotation.Set(transform.rotation.x, transform.rotation.y, transform.rotation.z,1);
        //Step size is equal to speed times frame time (needed for RotateTowarwds paramter below)
        //var step = 24f * Time.deltaTime;
        //Quaternion oldRotation = transform.rotation; //current rotation of the agent
        //Quaternion newRotation = Quaternion.LookRotation(Player.PlayerVariables.Agent.velocity.normalized); //direction the agent is moving
        //Player.PlayerVariables.PlayerGameObject.transform.rotation = Quaternion.Lerp(oldRotation, newRotation, step); //smooth rotation between old and new rotation}
    }
}
  