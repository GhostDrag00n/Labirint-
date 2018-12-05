﻿using System.Collections;
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
        Enemy.GetComponent<Enemy_AI>().MoveTo(player.transform.position);

        if (animator.GetFloat("Distance") > 5)
        {
            
        }
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) 
    {
        
    }
}