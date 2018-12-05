using UnityEngine;
using UnityEngine.AI;
using UnityStandardAssets.Characters.ThirdPerson;

public class Enemy_AI : MonoBehaviour {

    public Animator anim;
    public GameObject player;
    public GameObject Home;
    public int NumberOfPoints;
    public float LookingRadius;

    [HideInInspector]
    public float height;

    public NavMeshAgent agent;

    public ThirdPersonCharacter character;


    public GameObject GetPlayer()
    {
        agent.updateRotation = false;
        return player;
    }

    private void Update()
    {
        anim.SetFloat("Distance", Vector3.Distance(this.transform.position, player.transform.position));
    }

    public void MoveTo(Vector3 position)
    {
        agent.SetDestination(position);
        if (agent.remainingDistance > agent.stoppingDistance)
        {
            character.Move(agent.desiredVelocity, false, false);
            //GameObject gm = GameObject.CreatePrimitive(PrimitiveType.Cube);
            //gm.GetComponent<BoxCollider>().isTrigger = true;
            //Instantiate(gm, position, Quaternion.identity);
        }
        else
        {
            character.Move(Vector3.zero, false, false);

        }
    }

    public void MoveToHome()
    {
        agent.SetDestination(Home.transform.position);
        if (agent.remainingDistance > agent.stoppingDistance)
        {
            character.Move(agent.desiredVelocity, false, false);
        }
        else
        {
            character.Move(Vector3.zero, false, false);

        }
    }

    public Vector3[] LookForPlayer()
    {
        Vector3[] points = new Vector3[NumberOfPoints];
        for (int i = 0; i < NumberOfPoints; i++)
        {
            points[i].x = this.transform.position.x + Random.Range(-LookingRadius, LookingRadius);
            points[i].y = this.transform.position.y + Random.Range(-LookingRadius, LookingRadius);
        }
        return points;
    }

    public float GetHeight()
    {
        return anim.gameObject.transform.position.z;
    }

}
