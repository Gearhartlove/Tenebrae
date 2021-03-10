using System;
using UnityEngine;
using Enemy;

public class Bar : MonoBehaviour, EnemyActions
{
    //fields
    public string type = "Bear";
    //reference
    BarStats bar = new BarStats();

    //value
    string name = "Grizzly Bar";

    private void Awake()
    {

    }

    public void Death()
    {

    }

    public void Attack()
    {

    }

    public void Chase()
    {

    }
}
