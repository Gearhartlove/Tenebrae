using System;
using UnityEngine;
namespace Enemy
{
    public interface EnemyActions
    {
        //upon reaching 0 hp: stop action, trigger
        //death animation, spawn loot? (for later)
        void Death();

        //Attack the player
        void Attack();

        //Follow the player 
        void Chase();

        //void SpawnLoot();


    }
}