using System;
using UnityEngine;
using UnityEngine.AI;
public class NPC : MonoBehaviour, IInteractable
{

    private GameObject Interactable;
    private GameObject Player;
    private GameObject p_hui;
    private GameObject npc_dui; //npc dialogue ui

    private string Name;
    private bool isInteracting = false;
    private bool oneTime = false;
    private float talking_distance = 6f;
    //Q: how do I assign this / when? Story beat manager? > hook it up myself
    [SerializeField]
    private string dialogueFile; //each NPC will have their own dialogue

    private void Awake()
    {
        Interactable = gameObject;
        Name = "Placeholder Name";
        Player = GameObject.FindGameObjectWithTag("Player");
        p_hui = Player.GetComponentInChildren<PlayerHealthUI>().gameObject;
        npc_dui = gameObject.transform.Find("Dialogue Canvas").gameObject;

    }

    //interface
    public void Interact(GameObject player, GameObject interactable)
    {
        //dialgoue talking
        oneTime = true;
    }

    public void RunTo(Vector3 point, NavMeshAgent player)
    {
        //go to npc 
        player.SetDestination(point);
    }

    public float Calculate_Distance()
    {
        
        return Vector3.Distance(Interactable.transform.position, Player.transform.position);
    }

    private void Update()
    {
        //In range
        if (Calculate_Distance() <= talking_distance)
        {
            p_hui.SetActive(false);
            npc_dui.SetActive(true);
            oneTime = true;
            if (oneTime) { StartTalking(); oneTime = false; }
        }

        //Out of range
        if (Calculate_Distance() >= talking_distance)
        {
            p_hui.SetActive(true);
            npc_dui.SetActive(false);
        }
    }

    //Custom methods 
    private void StartTalking()
    {
        //text on screen = array spot one 
    }

    private void StopTalking()
    {

    }
}