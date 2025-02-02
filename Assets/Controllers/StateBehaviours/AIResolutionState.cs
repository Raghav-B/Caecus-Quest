﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIResolutionState : StateMachineBehaviour
{
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
        EnemyController.Instance.ResolveAIAll();
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
        if (EnemyController.Instance.PollAIResolved()) {
            //Debug.Log("Controller reports resolved");

            if (!EnemyController.Instance.UpdateEnemyList()) {
                GameController.GameStateMachine.SetTrigger("PlayerWon");
            }

            else if (Player.Instance.getHealth() <= Mathf.Epsilon) {
                animator.SetTrigger("PlayerDied");
            }
            
            else {
                animator.SetTrigger("AiResolved");
            }
            
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    //override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
    //}

    // OnStateMove is called right after Animator.OnAnimatorMove()
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that processes and affects root motion
    //}

    // OnStateIK is called right after Animator.OnAnimatorIK()
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that sets up animation IK (inverse kinematics)
    //}
}
