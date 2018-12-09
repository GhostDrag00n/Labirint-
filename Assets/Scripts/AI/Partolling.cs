using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Partolling : Base_FSM
{

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateEnter(animator, stateInfo, layerIndex);
        animator.SetBool("PlayerFound", false);

    }


    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        AI.MoveTo(AI.Home.transform.position);
        //Patrolling


        if (animator.GetFloat("Distance") < 5)
        {
            animator.SetBool("PlayerFound", true);       
        }
    }


    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
    }

}