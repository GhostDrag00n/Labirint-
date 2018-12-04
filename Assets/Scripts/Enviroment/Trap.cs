using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : MonoBehaviour {

    public bool isSafe;
    public Animator animator;

    private void OnTriggerEnter(Collider hit)
    {
        if (hit.tag == "PlayerBody" && animator.GetBool("isActive") == false && isSafe == false)
        {
            animator.SetBool("isActive", true);
            Destroy(hit.gameObject);
        }
    }
}