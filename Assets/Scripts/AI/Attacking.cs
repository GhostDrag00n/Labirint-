using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacking : Base_FSM {

    float timer = 0;
    float attackRate = 0;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateEnter(animator, stateInfo, layerIndex);
        attackRate = AI.attackRate;
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

        if (animator.GetFloat("Distance") > AI.AttackingRadius)
        {
            animator.SetBool("Attacking", false);
        }

        if (player == null)
        {
            return;
        }

        if (timer <= 0)
        {
            timer = attackRate;
            AI.Attack();
        }
        timer -= Time.deltaTime;
        //Debug.Log(timer);
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

    }
}
