using UnityEngine;
using UnityEngine.AI;
using UnityStandardAssets.Characters.ThirdPerson;

public class Enemy_AI : MonoBehaviour {

    public Enemy_SO enemyStats;

    public Animator anim;
    public GameObject Player;
    public GameObject Home;
    public AttackCube AC;

    [HideInInspector]
    public float PatrollinRadius, LookingRadius, AttackingRadius, attackRate;

    [HideInInspector]
    public int Enemy_AT, Enemy_HP;

    public GameObject cyl;

    public NavMeshAgent agent;

    public ThirdPersonCharacter character;

    public HealthManager HM;



    float timer; 

    private void Start()
    {
        PatrollinRadius = enemyStats.PatrollingRadius;
        LookingRadius = enemyStats.LookingRadius;
        AttackingRadius = enemyStats.AttackingRadius;
        attackRate = enemyStats.AttackRate;
        Enemy_AT = enemyStats.Enemy_AT;
        Enemy_HP = enemyStats.Enemy_HP;

        agent.updateRotation = false;
    }

    public GameObject GetPlayer()
    {
        return Player;
    }

    private void Update()
    {
        if (Player == null)
        {
            anim.SetFloat("Distance", 1000f);
        }
        else
        {
            anim.SetFloat("Distance", Vector3.Distance(this.transform.position, Player.transform.position));
        }
        if (HM.Health <= 0)
        {
            Die();
            return;
        }

        //MoveTo(cyl.transform.position);

        //if (Input.GetMouseButtonDown(0))
        //{
        //    Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        //    RaycastHit hit;

        //    if (Physics.Raycast(ray, out hit))
        //    {
        //        //agent.SetDestination(hit.point);
        //        MoveTo(hit.point);
        //    }
        //}

        timer += Time.deltaTime;


        if (agent.remainingDistance > agent.stoppingDistance)
        {
            character.Move(agent.desiredVelocity, false, false);
        }
        else
        {
            character.Move(Vector3.zero, false, false);
            MoveTo(this.transform.position);

        }
    }

    public void MoveTo(Vector3 position)
    {
        agent.SetDestination(position);
        cyl.transform.position = position;
    }

    public void Attack()
    {
        //Play attack animation
        if (timer > attackRate)
        {
            timer = 0f;
            if (AC.CanAttack)
            {
                Player.GetComponent<HealthManager>().TakeDamage(Enemy_AT);
            }
        }
        //Debug.Log("Attacked");
    }

    void OnDrawGizmosSelected()
    {
        // Draw a yellow sphere at the transform's position
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, LookingRadius);
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, AttackingRadius);
    }

    void Die()
    {
        GetComponent<Animator>().SetBool("DeathTrigger", true);
        Debug.Log("AI dead");
        //Play death particle
        Destroy(this.gameObject);
    }
}
