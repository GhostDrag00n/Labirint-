﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookingForPlayer : Base_FSM
{
    Vector3[] points;
    Vector3 currentPoint;
    int numberofpoints;
    int currentWP;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateEnter(animator, stateInfo, layerIndex);
        currentWP = 0;
        numberofpoints = AI.NumberOfPoints;
        currentPoint = Enemy.transform.position;
        AI.MoveTo(currentPoint);
    }


    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (currentWP != numberofpoints)
        {
            if (Vector3.Distance(Enemy.transform.position, currentPoint) < AI.agent.stoppingDistance)
            {
                currentWP++;
                //AI.RandomPoint(Enemy.transform.position, AI.LookingRadius, out currentPoint);
                //currentPoint = AI.RandomNavSphere(Enemy.transform.position, AI.LookingRadius);
                currentPoint = AI.RandomPosition(Enemy.transform.position, AI.LookingRadius);
                AI.MoveTo(currentPoint);
            }
            if (currentWP == numberofpoints)
            {
                animator.SetBool("PlayerFound", false);
            }
        }
        currentPoint = AI.RandomPosition(Enemy.transform.position, AI.LookingRadius);
        currentPoint.y = Enemy.transform.position.y;
        AI.MoveTo(currentPoint);
        if (animator.GetFloat("Distance") < 2.5)
        {
            animator.SetBool("PlayerFound", true);
        }

    }


    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

    }

}
