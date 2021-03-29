using System;
using UnityEngine;
using UnityEngine.AI;

public interface IInteractable
{
    //run to the object
    void RunTo(Vector3 point, NavMeshAgent player);

    //interact with the object
    void Interact(GameObject player, GameObject interactable);

    //calculate distance between player and interactable
    float Calculate_Distance();
}
    