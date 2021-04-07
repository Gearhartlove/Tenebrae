using System;
using UnityEngine;
using UnityEngine.AI;
public class NPC : MonoBehaviour, IInteractable
{

    private GameObject Interactable;
    private GameObject Player;
    private GameObject p_hui;
    private CanvasGroup npc_dui; //npc dialogue ui

    private string Name;
    private bool isInteracting = false;
    private bool oneTimef = false;
    private float talking_distance = 6f;
    //Q: how do I assign this / when? Story beat manager? > hook it up myself
    [SerializeField]
    private string dialogueFile; //each NPC will have their own dialogue
    private DialogueManager dManager;

    private void Awake()
    {
        Interactable = gameObject;
        Name = "Placeholder Name";
        Player = GameObject.FindGameObjectWithTag("Player");
        p_hui = Player.GetComponentInChildren<PlayerHealthUI>().gameObject;
        npc_dui = gameObject.GetComponentInChildren<CanvasGroup>();
        dManager = gameObject.GetComponent<DialogueManager>();

    }

    //interface
    public void Interact(GameObject player, GameObject interactable)
    {
        //dialgoue talking
        //oneTime = true;
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
            if (oneTimef) { StartTalking(); oneTimef = false; }
        }

        //Out of range
        if (Calculate_Distance() >= talking_distance)
        {
            if (!oneTimef) { StopTalking(); oneTimef = true; }
            
        }
    }

    //Custom methods 
    private void StartTalking()
    {
        p_hui.SetActive(false);
        npc_dui.alpha = 1;
        dManager.StartDialogue();
    }

    private void StopTalking()
    {
        p_hui.SetActive(true);
        npc_dui.alpha = 0;
        dManager.StopDialogue();
    }
}