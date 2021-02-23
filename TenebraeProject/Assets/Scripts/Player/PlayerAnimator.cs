using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Player;

public class PlayerAnimator : MonoBehaviour
{
    NavMeshAgent agent;
    public Animator anim;

    float motionSmoothTIme = .1f;
    
    // Start is called before the first frame update 
    void Start()
    {
        agent = Player.PlayerVariables.Agent;
    }

    // Update is called once per frame
    void Update()
    {
        float speed = agent.velocity.magnitude / agent.speed;
        anim.SetFloat("Speed", speed, motionSmoothTIme, Time.deltaTime);
    }
}
