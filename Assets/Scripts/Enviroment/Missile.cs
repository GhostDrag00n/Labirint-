using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missile : MonoBehaviour {

    public float ProjectileSpeed;
    public float turningSpeed = 90f;
    public int damage;
    public GameObject player;
    public GameObject particle;
    Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        Destroy(this.gameObject, 10f);
    }
    private void FixedUpdate()
    {
        var direction = ((player.transform.position + Vector3.up) - transform.position).normalized;
        var lookRotation = Quaternion.LookRotation(direction);
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * turningSpeed);


        transform.Translate(Vector3.forward * Time.deltaTime * ProjectileSpeed, Space.Self);
    }

    private void OnTriggerEnter(Collider hit)
    {
        if (hit.tag == "Player")
        {
            hit.GetComponentInParent<HealthManager>().TakeDamage(damage);
            var partic = Instantiate(particle, transform.position, Quaternion.identity);
            Destroy(partic, 2);
            Destroy(this.gameObject);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawRay(transform.position, (player.transform.position - transform.position).normalized);
        Gizmos.color = Color.blue;
        Gizmos.DrawRay(player.transform.position, transform.position);
        Gizmos.DrawWireSphere(player.transform.position + Vector3.up, .5f);
    }
}   
