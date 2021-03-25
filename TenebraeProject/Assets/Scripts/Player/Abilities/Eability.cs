using System;
using UnityEngine;
using Player;
using UnityEngine.InputSystem;

public class Eability : MonoBehaviour
{
    //Fields
    public static float thrust = 0;
    //Methods
    public static void Roll()
    {
        RaycastHit hit;
        if (Physics.Raycast(Camera.main.ScreenPointToRay(Mouse.current.position.ReadValue()), out hit, Mathf.Infinity))
        {
            //TODO need to clear the NavMeshAgent.SetDestination to where I roll too?
            Debug.Log("Rolling");
            Debug.Log(hit.point);
            //idea > face player towards mouse, then add force forward
            Eability.RotateTowards(hit.point);
            PlayerVariables.PlayerRigidBody.AddForce(PlayerVariables.PlayerGameObject.transform.forward * thrust, ForceMode.Impulse);
            //PlayerVariables.PlayerRigidBody.AddForce(hit.point * thrust, ForceMode.Impulse);
            PlayerVariables.Agent.ResetPath();
        }  
    }

    //copy code from PlayerCombat script
    private static void RotateTowards(Vector3 to)
    {
        Vector3 from = Player.PlayerVariables.PlayerGameObject.transform.position;
        Quaternion tt = Quaternion.LookRotation((to - from).normalized);
        Quaternion tt2 = Quaternion.Euler(0, tt.eulerAngles.y, 0);
        PlayerVariables.PlayerGameObject.transform.rotation = tt2;
    }
}
