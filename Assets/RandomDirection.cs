using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomDirection : Base_FSM {

    public Vector3 desiredPostiton;

	override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
        base.OnStateEnter(animator, stateInfo, layerIndex);
        desiredPostiton = Enemy.transform.position;
	}

	override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
        if (Vector3.Distance(desiredPostiton, Enemy.transform.position) < 1.3f)
        {
            desiredPostiton.x += Random.Range(-10, 10);
            desiredPostiton.y += Random.Range(-10, 10);
        }
        desiredPostiton.z = animator.transform.position.z;
        Enemy.GetComponent<Enemy_AI>().MoveTo(desiredPostiton);
        GameObject.CreatePrimitive(PrimitiveType.Sphere).transform.position = desiredPostiton;
	}

	override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
	
	}
}
