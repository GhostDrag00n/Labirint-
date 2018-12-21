using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chasing : Base_FSM
{

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateEnter(animator, stateInfo, layerIndex);

    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) 
    {

        if (animator.GetFloat("Distance") < AI.AttackingRadius)
        {
            animator.SetBool("Attacking", true);
        }
        if (animator.GetFloat("Distance") > AI.LookingRadius)
        {
            animator.SetBool("PlayerFound", false);
        }

        if (player == null)
        {
            return;
        }
        else
        {
            Enemy.GetComponent<Enemy_AI>().MoveTo(player.transform.position);
        }
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) 
    {
        
    }
}
