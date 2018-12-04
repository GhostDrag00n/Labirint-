using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Base_FSM : StateMachineBehaviour
{
    public GameObject Enemy;
    public GameObject player;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Enemy = animator.gameObject.transform.GetChild(0).gameObject;
        player = Enemy.GetComponent<Enemy_AI>().GetPlayer();
    }
}
