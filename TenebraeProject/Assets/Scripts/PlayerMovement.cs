using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerMovement : MonoBehaviour
{ 

    NavMeshAgent agent;

    public float rotateSpeedMovement = 0.075f;
    float rotateVelocity;
    int LeftMouseButton = 1;

    // Start is called before the first frame update
    void Start()
    {
        agent = gameObject.GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        //When pressing the left mouse button
        if (Input.GetMouseButtonDown(LeftMouseButton))
        {
            RaycastHit hit;

            //Checking if the raycast shot hits something that uses the navmesh system
            if(Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, Mathf.Infinity))
            {
                //Movement
                //Have the player move to the raycast point.
                agent.SetDestination(hit.point);

                //Rotation
                Quaternion rotationToLookAt = Quaternion.LookRotation(hit.point - transform.position);
                float rotationY = Mathf.SmoothDampAngle(transform.eulerAngles.y,
                    rotationToLookAt.eulerAngles.y,
                    ref rotateVelocity,
                    rotateSpeedMovement * (Time.deltaTime * 5));

                transform.eulerAngles = new Vector3(0, rotationY, 0);
            }


        }
            
    }
}
