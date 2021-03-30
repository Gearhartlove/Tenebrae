using System;
using UnityEngine;
using UnityEngine.AI;

public class Loot : MonoBehaviour, IInteractable
{
    private static bool Looting = false;
    private GameObject Interactable;
    private GameObject Player;
    private float looting_distance = 5f;

    private void Awake()
    {
        Interactable = new GameObject();
        Player = GameObject.FindGameObjectWithTag("Player");
    }
    public void Interact(GameObject player, GameObject interactable)
    {
        Interactable = interactable;
        if (!Looting) Looting = true; //problem when switching between looting multiple items . . . 
        else { Looting = false; }
    }

    public float Calculate_Distance()
    {
        return Vector3.Distance(Interactable.transform.position, Player.transform.position);
    }

    public void RunTo(Vector3 point, NavMeshAgent player)
    {
        player.SetDestination(point);
    }


    private void Update()
    {
        if (Looting)
        {
            if (Calculate_Distance() < looting_distance)
            {
                Interactable.SetActive(false);
                if (Interactable.activeInHierarchy == false) { Looting = false; } //avoiding weird updating calling methods and setting params not in sinc. 
                                                                                 //might need to change later
            }
        }
    }


}