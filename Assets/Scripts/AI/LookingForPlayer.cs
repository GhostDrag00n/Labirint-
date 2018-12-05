﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookingForPlayer : Base_FSM
{
    Vector3[] points;
    int currentWP;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateEnter(animator, stateInfo, layerIndex);
        currentWP = 0;
        points = Enemy.GetComponent<Enemy_AI>().LookForPlayer();
    }


    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (points != null)
        {
            if (Vector3.Distance(points[currentWP], Enemy.transform.position) < .5f)
            {
                currentWP++;
                if (currentWP >= points.Length)
                {
                    animator.SetBool("PlayerFound", false);
                    return;
                }
            }
        }

        if (animator.GetFloat("Distance") < 2.5)
        {
            animator.SetBool("PlayerFound", true);
        }
        Vector3 dirToPlayer = Enemy.transform.position - player.transform.position;
        points[currentWP] += dirToPlayer;
        Enemy.GetComponent<Enemy_AI>().MoveTo(points[currentWP]);
    }


    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

    }

}