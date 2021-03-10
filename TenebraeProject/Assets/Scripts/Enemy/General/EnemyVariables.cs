using System;
using UnityEngine;
using Enemy;
public class EnemyVariables : MonoBehaviour
{
    public static GameObject EnemyGameObject;

    private void Awake()
    {
        EnemyGameObject = this.gameObject;
    }
}