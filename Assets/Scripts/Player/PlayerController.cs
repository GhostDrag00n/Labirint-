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

    public HealthManager HM;
    public CoinManager   CM;

    public Button AttackButton;
    public Button CrouchButton;

    public bool HoldToCrouch;

    public AttackCube AC;

    float timer;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("More that one player");
        }
        else
        {
            instance = this;
        }
    }

    private void Start()
    {
        
    }

    private void Update()
    {
        timer += Time.deltaTime; 

        if (Input.GetKeyDown(KeyCode.H))
        {
            //HM.TakeDamage(-200);
            HM.Heal(100);
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
}
