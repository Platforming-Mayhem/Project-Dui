using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovingScript : StateMachineBehaviour
{
    AudioSource source;
    AudioSource source1;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (stateInfo.IsName("Move"))
        {
            try
            {
                source1 = GameObject.Find("FootstepsDarker").GetComponent<AudioSource>();
                if (!source1.isPlaying)
                {
                    source1.Play();
                    source1.UnPause();
                }
            }
            catch
            {

            }
            try
            {
                source = GameObject.Find("Footsteps").GetComponent<AudioSource>();
                if (!source.isPlaying)
                {
                    source.Play();
                    source.UnPause();
                }
            }
            catch
            {

            }
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        try
        {
            source.Pause();
        }
        catch
        {

        }
        try
        {
            source1.Pause();
        }
        catch
        {

        }
    }

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
