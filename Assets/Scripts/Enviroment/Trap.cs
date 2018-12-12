using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : MonoBehaviour {

    public bool isSafe;
    public Animator animator;
    public GameObject Trigger;
    public GameObject player;

    private void Start()
    {
        player = GameObject.FindWithTag("PlayerBody");
    }

    private void OnTriggerEnter(Collider hit)
    {
        if (hit.tag == "PlayerBody" && (animator.GetBool("isActive") || false && isSafe == false))
        {
            animator.SetBool("isActive", true);
            Destroy(hit.gameObject);
        }
    }
}