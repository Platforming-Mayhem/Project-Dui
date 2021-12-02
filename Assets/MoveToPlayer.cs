using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToPlayer : StateMachineBehaviour
{
    NewPlayerScript newPlayer;
    Boss01Script boss;
    Rigidbody rb;
    float time = 0f;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        newPlayer = FindObjectOfType<NewPlayerScript>();
        rb = animator.GetComponentInParent<Rigidbody>();
        boss = FindObjectOfType<Boss01Script>();
        rb.useGravity = true;
        time = Random.Range(1f, 5f);
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Vector3 dir = (animator.transform.position - newPlayer.transform.position).normalized;
        animator.transform.parent.eulerAngles = new Vector3(-90f, Mathf.Atan2(dir.x, dir.z) * Mathf.Rad2Deg + 180f, 0f);
        boss.dir = -animator.transform.up;
        if(time > 0f)
        {
            time -= Time.deltaTime;
        }
        else
        {
            animator.SetTrigger("Attack");
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
