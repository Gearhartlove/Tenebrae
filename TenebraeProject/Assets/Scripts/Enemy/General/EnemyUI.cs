using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Enemy;

public class EnemyUI : MonoBehaviour
{
    [Range(-10f, 10f)] [SerializeField] float distanceAbove = 1.48f;
    [Range(-10f, 10f)] [SerializeField] float xPosition = -0.07f;
    GameObject enemy;

    //HP UI elements
    Slider sliderHP;
    float MaxValueHP;

    //Enemy Stats
    DefaultEnemyStats stats;

    //canvas values


    private void Start()
    {
        //DefaultEnemyStats stats = new DefaultEnemyStats();
        stats = GetComponentInParent<DefaultEnemyStats>();
        sliderHP = transform.GetComponentInChildren<Slider>();

        //max hp
        sliderHP.maxValue = stats.MaxHP;
        MaxValueHP = sliderHP.maxValue;
        //current hp
        sliderHP.value = stats.CurrentHPValue;

        //enemy 
        enemy = transform.parent.gameObject;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        sliderHP.value = stats.CurrentHPValue;
        //positioning
        Vector3 enemyPosition = enemy.transform.position;
        enemyPosition.y += distanceAbove;
        enemyPosition.x += xPosition;
        transform.position = enemyPosition;
        //transform.LookAt(Camera.main.transform);
        //transform.Rotate(0f, 180f, 0);
    }
}
