using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.AI;

namespace Player
{
    public class PlayerActions : MonoBehaviour
    {
        //FIELDS ---
        //Useful to every script
        private GameObject PlayerGameObject;
        //Scroll-Wheel
        private CameraScroll cameraScroll;
        //Combat
        private PlayerCombat playerCombat;
        //Movement
        private PlayerMovement playerMovement;
        private NavMeshAgent agent;
        private float distanceFromTarget;
        //UI
        private PlayerAbilityManager abilityManager;

        //On Start
        private void Start()
        {
            PlayerGameObject = Player.PlayerVariables.PlayerGameObject;
            playerCombat = Player.PlayerVariables.PlayerCombatObject;
            cameraScroll = Player.PlayerVariables.CameraScrollObject;
            playerMovement = Player.PlayerVariables.PlayerMovementObject;
            abilityManager = Player.PlayerVariables.AbilityManager;

            //Movement
            agent = Player.PlayerVariables.Agent;
            
        }

        //METHODS ---

        //Keyboard: s
        private void OnStopMoving()
        {
            playerMovement.StopMoving();
        }

        //Mouse: Right-Click
        private void OnMove()
        {
            RaycastHit hit;

            //Player Character Action depending on target right clicked
            if (Physics.Raycast(Camera.main.ScreenPointToRay(Mouse.current.position.ReadValue()), out hit, Mathf.Infinity))
            {
                var objectTag = hit.collider.gameObject.tag;
                Player.PlayerVariables.PlayerFocus = objectTag;
                switch (objectTag)
                {
                    case "Player":
                        break;
                    case "Enemy":
                        playerCombat.Attack(hit.collider.gameObject);
                        break;
                    case "Interactable":
                        break;
                    default:
                        agent.SetDestination(hit.point);

                        break;
                }
            }
        }

        //Mouse: Left-Click
        //TODO working on this :) , implementing interface for streamline logic /
        private void OnLeftClick()
        {
            RaycastHit hit;
            if (Physics.Raycast(Camera.main.ScreenPointToRay(Mouse.current.position.ReadValue()), out hit, Mathf.Infinity))
            {
                //Loot
                if (hit.collider.gameObject.tag == "Loot")
                {
                    Loot loot = hit.collider.gameObject.GetComponent<Loot>();
                    GameObject interactable = hit.collider.gameObject;
                    loot.RunTo(hit.point,agent);
                    loot.Interact(gameObject, interactable);
                }

                //NPC
                if (hit.collider.gameObject.tag == "NPC")
                {
                    NPC npc = hit.collider.gameObject.GetComponent<NPC>();
                    GameObject interactable = hit.collider.gameObject;
                    npc.RunTo(hit.point, agent);
                    npc.Interact(gameObject, interactable);;
                }
            }
        }

        //Mouse: Scroll-Wheel
        private void OnScrollWheel(InputValue value)
        {
            //reading input value from scroll wheel controls
            cameraScroll.scrollValue += value.Get<float>() / 1000;
            cameraScroll.scrollValue = Mathf.Clamp(cameraScroll.scrollValue, cameraScroll.scrollMin, cameraScroll.scrollMax);
            cameraScroll.AdjustFOV(cameraScroll.scrollValue);

        }

        public void Death()
        {
            Time.timeScale = 0f;
            //spawn death UI
        }

        //Main Abilities
        //Keyboard: q
        //hold strong attack
        private void OnQAbility()
        {
            abilityManager.PressQ();   
        }

        //Keyboard: w
        //push back ability
        private void OnWAbility()
        {
            abilityManager.PressW();
        }
        //Keyboard: e
        //roll ability
        private void OnEAbility()
        {
            abilityManager.PressE();
        }
        //Keyboard: r
        private void OnRAbility() => Debug.Log("r");
        //Keyboard: d
        private void OnDAbility() => Debug.Log("d");
        //Keyboard: f
        private void OnFAbility() => Debug.Log("f");

        //Inventory 
        //Keyboard: Tab
        //private void OnTab()
        //{
        //    protoInventory2.PressingTab();
        //}
    }
}