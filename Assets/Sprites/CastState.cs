using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CastState : StateMachineBehaviour
{
    

    public override void OnStateEnter(Animator animator, AnimatorStateInfo animatorStateInfo, int layerIndex) {
        animator.transform.GetComponent<AudioSource>().Play();
    }

    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
        animator.transform.GetComponent<AudioSource>().Stop();
    }
}
