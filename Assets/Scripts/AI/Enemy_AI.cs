using UnityEngine;
using UnityEngine.AI;
using UnityStandardAssets.Characters.ThirdPerson;

public class Enemy_AI : MonoBehaviour {

    public Enemy_SO enemyStats;

    public Animator anim;
    public GameObject Player;
    public GameObject Home;

    [HideInInspector]
    public float PatrollinRadius, LookingRadius, AttackingRadius, attackRate;

    [HideInInspector]
    public int Enemy_AT, Enemy_HP;

    public GameObject cyl;

    public NavMeshAgent agent;

    public ThirdPersonCharacter character;

    PlayerController PC;

    private void Start()
    {
        PatrollinRadius = enemyStats.PatrollingRadius;
        LookingRadius = enemyStats.LookingRadius;
        AttackingRadius = enemyStats.AttackingRadius;
        attackRate = enemyStats.AttackRate;
        Enemy_AT = enemyStats.Enemy_AT;
        Enemy_HP = enemyStats.Enemy_HP;

        PC = Player.GetComponent<PlayerController>();
        agent.updateRotation = false;
    }

    public GameObject GetPlayer()
    {
        return Player;
    }

    private void Update()
    {
        anim.SetFloat("Distance", Vector3.Distance(this.transform.position, Player.transform.position));

        //MoveTo(cyl.transform.position);

        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                //agent.SetDestination(hit.point);
                MoveTo(hit.point);
            }
        }

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
        PC.TakeDamage(Enemy_AT);
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
}
