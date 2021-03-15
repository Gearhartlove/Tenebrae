using System;
using UnityEngine;
using UnityEngine.AI;
namespace Enemy 
{
    public class EnemyActions : MonoBehaviour
    {
        //fields
        //DEATH
        EnemyUI eUI;
        Rigidbody eRB;
        DefaultEnemyStats eStats;
        CapsuleCollider eCollider;
        Animator eAnimator;
        [SerializeField] GameObject loot;
        float despawnTime = 4f;
        NavMeshAgent eNMA;

        //instantiation
        private void Start()
        {
            eUI = GetComponentInChildren<EnemyUI>();
            eStats = GetComponentInChildren<DefaultEnemyStats>();
            eCollider = GetComponentInChildren<CapsuleCollider>();
            eAnimator = GetComponent<Animator>();
            eNMA = GetComponent<NavMeshAgent>();
        }
        
        public void Death(PlayerCombat playerCombat)
        {
            eNMA.SetDestination(transform.position);
            eStats.IsDead = true;
            //UI dissapear
            Disappear_UI();
            //dereference target from combat script
            DeReference(playerCombat);
            //trigger death animation
            eAnimator.SetBool("IsDead", true);
            eAnimator.Play("Death");
            //Invoke("DeathAnimation", 1f); //isdead false to aviod spam calls
            //Spawn Loot
            SpawnLoot();
            //despawn corpse after X seconds
            Invoke("DespawnCorpse", despawnTime);
        }

        //Attack the player
        public void Attack()
        {

        }

        //Follow the player 
        public void Chase()
        {

        }

        //-----------------------------------------------------
        //nitty gritty methods
        //DEATH
        private void Disappear_UI() => eUI.gameObject.SetActive(false);
        private void DeReference(PlayerCombat pc)
        {
            pc.Target = false;
            pc.InCombat = false;
            eCollider.enabled = false;
        }
        private void DeathAnimation() => eAnimator.SetBool("IsDead", false);

        private void SpawnLoot()
        {
            Vector3 ePosition = gameObject.transform.position;
            ePosition.y = 4;
            Instantiate(loot, ePosition, transform.rotation);
        }
        private void DespawnCorpse() => gameObject.SetActive(false);

        //ATTACK

    }
}