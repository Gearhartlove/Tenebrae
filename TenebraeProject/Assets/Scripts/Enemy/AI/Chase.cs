using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Player;
using Enemy;
using UnityEngine.AI;

public class Chase : StateMachineBehaviour
{
    BasicEnemyAI eAI;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        eAI = animator.gameObject.GetComponent<BasicEnemyAI>();
    }

    //OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        eAI.Chase();
    }
}
