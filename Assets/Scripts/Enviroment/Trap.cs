using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : MonoBehaviour {

    public bool isSafe;
    public int damage;
    public float TimeBetweenAttacks;
    public Animator animator;

    float timer;

    private void OnTriggerEnter(Collider hit)
    {
        if (animator.GetBool("isActive") == false)
        {
            animator.SetBool("isActive", true);
            Attack(hit, damage);
        }
        if (animator.GetBool("isActive") == true)
        {
            animator.SetBool("isActive", false);
            animator.SetBool("isActive", true);
            Attack(hit, damage);
        }
    }

    private void OnTriggerStay(Collider hit)
    {
        if (timer >= TimeBetweenAttacks)
        {
            timer = 0f;
            Attack(hit, damage);
        }
        timer += Time.deltaTime;
    }

    void Attack(Collider hit, int damage)
    {
        HealthManager HM = hit.GetComponent<HealthManager>();
        if (HM != null)
        {
            HM.TakeDamage(damage);
        }
    }
}