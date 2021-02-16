using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Enemy;

public class PlayerControls : PlayerMovement
{
    //Fields
    //Scroll-Wheel
    [SerializeField] private CameraScroll cameraScroll;
    //Inventory
    [SerializeField] private PrototypeInventory2 protoInventory2;
    //Keyboard: s
    private void OnStopMoving()
    {
        agent.SetDestination(transform.position);
    }

    //Mouse: Right-Click
    private void OnMove()
    {
        RaycastHit hit;

        //If raycast hits a baked navmesh material
        if (Physics.Raycast(Camera.main.ScreenPointToRay(Mouse.current.position.ReadValue()), out hit, Mathf.Infinity))
        {
            //Item Pick-up 
            //
            //Enemy Targeting
            if (hit.collider.gameObject.GetComponent<Targetable>() != null)
            {
                Debug.Log("Whack");
            }
            //Player Move
            else
            {
                //Move player to raycast position
                agent.SetDestination(hit.point);
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
    private void OnTab()
    {
        protoInventory2.PressingTab();
    }
}
