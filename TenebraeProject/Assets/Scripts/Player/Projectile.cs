using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Player;
using Enemy;

public class Projectile : MonoBehaviour
{
    public float speed;
    private PlayerCombat playerCombat;
    private GameObject Target;
    float damage = 1;
    EnemyActions enemyActions;

    //public GameObject destroyEffect;
    private void Awake()
    {
        playerCombat = PlayerVariables.PlayerGameObject.GetComponentInChildren<PlayerCombat>();
    }

    private void Start()
    {
        //Invoke("DestroyProjectile", lifetime);
    }

    private void Update()
    {

        Target = playerCombat.TargetedEnemy;
        Vector3 TargetDestination = Target.transform.position;
        transform.Translate(-TargetDestination * speed * Time.deltaTime);
    }

    private void DestroyProjectile()
    {
        //Instantiate(destroyEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("hitting");
        GameObject target = other.gameObject; //might collide with not original target
        if (other.gameObject.tag == "Enemy")
        {
            //Changing HP
            enemyActions = target.GetComponent<EnemyActions>();
            DefaultEnemyStats stats = target.GetComponentInChildren<DefaultEnemyStats>();
            EnemyUI eUI = target.GetComponentInChildren<EnemyUI>();

            stats.CurrentHPValue -= damage; //damage component
            Debug.Log("HP: " + stats.CurrentHPValue);

            //kill enemy
            if (stats.CurrentHPValue <= 0)
            {
                enemyActions.Death(playerCombat);
            }
        }

        DestroyProjectile();

    }
}
