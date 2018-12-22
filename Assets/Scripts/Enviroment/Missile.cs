using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missile : MonoBehaviour {

    public float ProjectileSpeed;
    public float turningSpeed = 90f;
    public int damage;
    public GameObject player;
    Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        Destroy(this.gameObject, 10f);
    }
    private void FixedUpdate()
    {
        var direction = (player.transform.position - transform.position).normalized;
        var lookRotation = Quaternion.LookRotation(direction);
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * turningSpeed);


        transform.Translate(Vector3.forward * Time.deltaTime * ProjectileSpeed, Space.Self);
    }

    private void OnTriggerEnter(Collider hit)
    {
        if (hit.tag == "PlayerActivation")
        {
            hit.GetComponentInParent<HealthManager>().TakeDamage(damage);
            Destroy(this.gameObject);
        }
    }
}   
