using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Player;

public class Projectile : MonoBehaviour
{
    public float speed;
    public float lifetime;
    private PlayerCombat playerCombat;
    public GameObject Target;

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

    private void OnColliderEnter(Collider other)
    {
        Debug.Log(other.name);
        DestroyProjectile();
    }
}
