using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : MonoBehaviour {

	[HideInInspector]
	public bool isTrapActive;

    public bool isSimple;
    public float time;

    public bool isSafe;
    public int damage;
    public Animator animator;
    public float TimeBetweenAttacks;

    float timer;

    private void Update()
    {
        timer += Time.deltaTime;
    }

    private void OnTriggerEnter(Collider hit)
    {
        if ((!isTrapActive || !isSafe) && (hit.tag == "Player" || hit.tag == "AI"))
        {
            Attack(hit, damage);
            timer = 0;
        }
    }

    private void OnTriggerStay(Collider hit)
    {
        if (timer >= TimeBetweenAttacks)
        {
            if ((!isTrapActive || !isSafe) && (hit.tag == "Player" || hit.tag == "AI"))
            {
                Attack(hit, damage);
                timer = 0;
                print("Timer reset");
            }
        }
    }

    private void OnTriggerExit(Collider hit)
    {
        
    }

    void Attack(Collider hit, int damage)
    {
        HealthManager HM = hit.GetComponent<HealthManager>();
        if (HM != null)
        {
            HM.TakeDamage(damage);
        }
        else
        {
            print("HM is null");
        }
    }
}