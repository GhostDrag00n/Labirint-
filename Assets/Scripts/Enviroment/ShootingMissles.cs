using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingMissles : MonoBehaviour {

    public GameObject player;
    public GameObject projectile;
    public GameObject ShootFrom;
    public float projectileSpeed;
    public float AttackRadius;
    public float attackRate;
    public int damage;

    float timer;
	
	void Start () {
        player = GameObject.FindWithTag("Player");
	}
	
	void Update () {
        timer += Time.deltaTime;

        if (timer >= attackRate)
        {
            timer = 0f;
            if (Vector3.Distance(transform.position, player.transform.position) < AttackRadius)
            {
                GameObject go = Instantiate(projectile, ShootFrom.transform.position, Quaternion.identity);
                Missile mi = go.GetComponent<Missile>();
                mi.player = player;
                mi.ProjectileSpeed = projectileSpeed;
                mi.damage = damage;
            }
        }
	}

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, AttackRadius);
    }
}
