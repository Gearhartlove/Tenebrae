using System;
using UnityEngine;

public class Loot : MonoBehaviour
{
    private static bool Looting = false;
    private GameObject Interactable;
    private GameObject Player;
    float distance;

    private void Awake()
    {
        Interactable = new GameObject();
        Player = GameObject.FindGameObjectWithTag("Player");
    }
    public void LootItem(GameObject player, GameObject interactable)
    {
        Interactable = interactable;
        if (!Looting) Looting = true; //problem when switching between looting multiple items . . . 
        else { Looting = false; }
    }

    private void Update()
    {
        if (Looting)
        {
            Debug.Log("looting");
            distance = Vector3.Distance(Interactable.transform.position, Player.transform.position);
            if (distance < 5.0f)
            {
                Interactable.SetActive(false);
                if (Interactable.activeInHierarchy == false) { Looting = false; } //avoiding weird updating calling methods and setting params not in sinc. 
                                                                                  //might need to change later
            }
        }
    }
}