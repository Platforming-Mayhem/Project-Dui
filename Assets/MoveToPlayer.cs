using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToPlayer : StateMachineBehaviour
{
    NewPlayerScript newPlayer;
    Rigidbody rb;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        newPlayer = FindObjectOfType<NewPlayerScript>();
        rb = animator.GetComponent<Rigidbody>();
        rb.useGravity = true;
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Vector3 dir = Vector3.Scale(animator.transform.position - newPlayer.transform.position, Vector3.one - Vector3.up).normalized;
        animator.transform.up = dir;
        animator.transform.position = Vector3.Scale(Vector3.Lerp(animator.transform.position, newPlayer.transform.position, Time.deltaTime), Vector3.one - Vector3.up) + Vector3.up * animator.transform.position.y;
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
