using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerMovement : MonoBehaviour
{ 
    NavMeshAgent agent;
    [SerializeField] float RotationSpeed = 20f;
    int LeftMouseButton = 1;

    // Start is called before the first frame update
    void Start()
    {
        agent = gameObject.GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
    }

    // Update is called once per frame
    void Update()
    {
        //When pressing the left mouse button
        if (Input.GetMouseButtonDown(LeftMouseButton))
        {
            RaycastHit hit;

            //If raycast hits a baked navmesh material
            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, Mathf.Infinity))
            {
                //Move player to raycast position
                agent.SetDestination(hit.point);
            }
        }
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
            Debug.Log(agent.velocity.normalized.x);
            transform.rotation = Quaternion.Lerp(oldRotation,newRotation,step); //smooth rotation between old and new rotation}
        }
    }
}
