using System.Collections;
using UnityEngine;

public class NewTrap : MonoBehaviour {

    //public bool isSimple;
    private bool active = false;
    private bool dealDamage = false;

    public int damage;
    public Animator animator;
    public float offset = 0;
    public float TimeBetweenAttacks;
    public float TimeBetweenTakingDamage;
    

    float timer;
    float secondTimer;

    private void Start()
    {
     
    }

    private void Update()
    {
        if (offset >= 0)
        {
            timer = 0f;
            offset -= Time.deltaTime;
        }
		timer += Time.deltaTime;
        secondTimer += Time.deltaTime;

        if (timer >= TimeBetweenAttacks)
        {
            timer = 0f;
            MoveSpikes();
            active = !active;
        }

    }

    void MoveSpikes()
    {
        GetComponent<Animator>().SetBool("isActive", !active);
    }

    private void OnTriggerEnter(Collider hit)
    {
        if (hit.GetComponent<HealthManager>() != null)
        {
            Debug.Log(hit.GetComponent<HealthManager>().GetInstanceID());
			dealDamage = true;
            if (active)
            {
                hit.GetComponent<HealthManager>().TakeDamage(damage);
                Debug.Log("Dealing damage on enter");
                secondTimer = 0;
            }
        }
    }

    private void OnTriggerStay(Collider hit)
    {
        if (hit.GetComponent<HealthManager>() != null)
        {
            if (secondTimer >= TimeBetweenTakingDamage && active && dealDamage)
            {
                hit.GetComponent<HealthManager>().TakeDamage(damage);
                Debug.Log("Dealing damage on staying");
                secondTimer = 0;
            }
		}
    }

    private void OnTriggerExit(Collider hit)
    {
        if (hit.GetComponent<HealthManager>() != null)
        {
            dealDamage = false;
        }
    }
}
