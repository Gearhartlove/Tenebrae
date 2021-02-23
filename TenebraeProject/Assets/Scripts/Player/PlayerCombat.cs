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
    GameObject TargetedEnemy;

    private void Update()
    {
        if (Target)
        {
            if (InRange) { PerformAttack(TargetedEnemy); }
            else { MovePlayer(); }
        }
    }

    public void Attack(GameObject Enemy)
    {
        TargetedEnemy = Enemy;
        Target = true;
        DetermineDistance(Enemy.transform.position);
    }

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
}
