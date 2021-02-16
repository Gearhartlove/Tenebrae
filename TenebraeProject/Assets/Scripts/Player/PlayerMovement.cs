using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerMovement : MonoBehaviour
{ 
    public NavMeshAgent agent;
    [SerializeField] float RotationSpeed = 20f;
    [SerializeField] Camera mainCamera;

    // Start is called before the first frame update
    void Start()
    {
        agent = gameObject.GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
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
            transform.rotation = Quaternion.Lerp(oldRotation,newRotation,step); //smooth rotation between old and new rotation}
        }
    }
}
