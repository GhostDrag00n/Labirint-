using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Partolling : Base_FSM
{

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateEnter(animator, stateInfo, layerIndex);

    }


    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

        if (animator.GetFloat("Distance") < AI.LookingRadius)
        {
            animator.SetBool("PlayerFound", true);
        }

        AI.MoveTo(AI.Home.transform.position);
        //Patrolling

    }


    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
    }

}