using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Enemy;

public class EnemyUI : MonoBehaviour
{
    [Range (-10f, 10f)] [SerializeField] float distanceAbove = 1.48f;
    [Range(-10f, 10f)] [SerializeField] float xPosition = -0.07f;
    GameObject enemy;

    private void Start()
    {
        enemy = transform.parent.gameObject;
    }
    // Update is called once per frame
    void LateUpdate()
    {
        Vector3 enemyPosition = enemy.transform.position;
        enemyPosition.y += distanceAbove;
        //enemyPosition.y = distanceAbove;
        enemyPosition.x += xPosition;
        transform.position = enemyPosition;
        //transform.LookAt(Camera.main.transform);
        //transform.rotation = fixedRotation;
        //transform.Rotate(0f, 180f, RotateValuez);
        //change the y position
        //playerPosition.y = 6.52f;
        //transform.position = playerPosition;
        transform.LookAt(Camera.main.transform);
        //transform.rotation = fixedRotation;
        transform.Rotate(0f, 180f, 0);
        //change the y position
    }
}
