using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookingForPlayer : Base_FSM
{
    Vector3[] points;
    Vector3 currentPoint;
    int NumberOfPoints;
    int currentWP;
    Enemy_AI AI;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateEnter(animator, stateInfo, layerIndex);
        currentWP = 0;
        points = AI.LookForPlayer();
        AI = Enemy.GetComponent<Enemy_AI>();
    }


    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (currentWP != NumberOfPoints)
        {
            if (Vector3.Distance(currentPoint, Enemy.transform.position) < .5f)
            {
                currentWP++;
                AI.RandomPoint(Enemy.transform.position, AI.LookingRadius,out currentPoint);
            }
        }

        if (animator.GetFloat("Distance") < 2.5)
        {
            animator.SetBool("PlayerFound", true);
        }
        //Vector3 dirToPlayer = Enemy.transform.position - player.transform.position;
        //points[currentWP] += dirToPlayer;
        //Enemy.GetComponent<Enemy_AI>().MoveTo(points[currentWP]);

    }


    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

    }

}
