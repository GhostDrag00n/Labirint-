using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{

    public static PlayerController instance;

#region
    public float AttackRate;
    public int Damage;
#endregion

    public List<int> PickedUpItems;

    public HealthManager HM;

    public Button AttackButton;

    public AttackCube AC;

    float timer;

    private void Start()
    {
        PickedUpItems = new List<int>();
    }

    private void Update()
    {
        timer += Time.deltaTime; 

        if (Input.GetKeyDown(KeyCode.H))
        {
            Debug.Log(HM.Health);
        }
        if (HM.Health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        GetComponent<Animator>().SetBool("DeathTrigger", true);
        Debug.Log("Player dead");
    }

    public void Attack()
    {
        //Play attacking animation
        if (timer >= AttackRate)
        {
            timer = 0f;
            if (AC.CanAttack)
            {
                AC.HM.TakeDamage(Damage);
            }
        }
    }
}
