using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControls : PlayerMovement
{

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
            //Move player to raycast position
            agent.SetDestination(hit.point);
        }
    }

    //Mouse: Left-Click
    private void OnLeftClick()
    {
        Debug.Log("Left Click");
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
}
