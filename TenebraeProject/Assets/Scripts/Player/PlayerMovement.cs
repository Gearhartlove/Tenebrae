using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Player;

public class PlayerMovement : MonoBehaviour
{
    private float RotationSpeed = 24f;
    NavMeshAgent agent;
    GameObject playerObject;

    // Start is called before the first frame update
    void Start()
    {
        agent = Player.PlayerVariables.Agent;
        playerObject = Player.PlayerVariables.PlayerGameObject;
        agent.updateRotation = false;
    }

    public void StopMoving()
    {
        agent.SetDestination(playerObject.transform.position);
    }
    private void LateUpdate()
    {
        //Rotating agent around objects smoothly when agent is moving
        if (agent.velocity.sqrMagnitude > Mathf.Epsilon)
        {
            //Step size is equal to speed times frame time (needed for RotateTowarwds paramter below)
            var step = RotationSpeed * Time.deltaTime;
            Quaternion oldRotation = transform.rotation; //current rotation of the agent
            Quaternion newRotation = Quaternion.LookRotation(agent.velocity.normalized); //direction the agent is moving
            playerObject.transform.rotation = Quaternion.Lerp(oldRotation,newRotation,step); //smooth rotation between old and new rotation}

        }
    }
}
