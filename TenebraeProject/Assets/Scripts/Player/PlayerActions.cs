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
        
        //On Start
        private void Start()
        {
            PlayerGameObject = Player.PlayerVariables.PlayerGameObject;
            playerCombat = Player.PlayerVariables.PlayerCombatObject;
            cameraScroll = Player.PlayerVariables.CameraScrollObject;
            playerMovement = Player.PlayerVariables.PlayerMovementObject;

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
                switch (objectTag)
                {
                    case "Player":
                        break;
                    case "Enemy":
                        playerCombat.Attack(gameObject, hit.collider.gameObject);
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
        private void OnLeftClick()
        {
            Debug.Log("Left Click");
        }

        //Mouse: Scroll-Wheel
        private void OnScrollWheel(InputValue value)
        {
            //reading input value from scroll wheel controls
            cameraScroll.scrollValue += value.Get<float>() / 1000;
            cameraScroll.scrollValue = Mathf.Clamp(cameraScroll.scrollValue, cameraScroll.scrollMin, cameraScroll.scrollMax);
            cameraScroll.AdjustFOV(cameraScroll.scrollValue);

        }

        //Main Abilities
        //Keyboard: q
        private void OnQAbility() => Debug.Log("q");
        //Keyboard: w
        private void OnWAbility() => Debug.Log("w");
        //Keyboard: e
        private void OnEAbility() => Debug.Log("e");
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