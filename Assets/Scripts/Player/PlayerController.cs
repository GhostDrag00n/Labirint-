using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{

#region
    public float AttackRate;
    public int Damage;
#endregion

    public List<int> PickedUpItems;

    public HealthManager HM;

    public Button AttackButton;
    public Button CrouchButton;

    public bool HoldToCrouch;

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
            //HM.TakeDamage(-200);
            HM.Health += 100;
            HM.HealthImage.fillAmount += 100f/HM.StartHealth;
            HM.HealthSlider.fillAmount += 100f/HM.StartHealth;
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Attack();
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
        Destroy(this.gameObject);

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

    public void Crouch()
    {
        
    }
}
