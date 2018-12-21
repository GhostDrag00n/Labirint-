using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Base_FSM : StateMachineBehaviour
{
    public GameObject Enemy;
    public GameObject player;
    public Enemy_AI AI;

    public float height;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Enemy = animator.gameObject.transform.GetComponentInParent<Enemy_AI>().gameObject;
        player = Enemy.GetComponent<Enemy_AI>().GetPlayer();
        AI = Enemy.GetComponent<Enemy_AI>();
        OnStateUpdate(animator, stateInfo, layerIndex);
    }

    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex, UnityEngine.Animations.AnimatorControllerPlayable controller)
    {
        player = AI.GetPlayer();
        if (player == null)
        {
            return;
        }
    }
}
