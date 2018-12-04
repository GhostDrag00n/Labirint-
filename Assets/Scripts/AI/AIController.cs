using UnityEngine;
using UnityEngine.AI;
using System.Collections;
using UnityStandardAssets.Characters.ThirdPerson;

public class AIController : MonoBehaviour {

    public GameObject player;

    public GameObject AIHome;

    public float AgroRadius;

    public float FindingRadius;

    public int NumberOfPoints;

    public NavMeshAgent agent;

    public ThirdPersonCharacter character;

    private bool lookingforplayer;

    void Start()
    {
        lookingforplayer = false;
        agent.updateRotation = false;
    }
	
	void Update () 
    {
        if (player == null)
            return;
        if (Vector3.Distance(transform.position, player.transform.position) <= AgroRadius)
        {
            Move(player.transform.position);
        }
        else
        {
            Move(Vector3.zero, false);
            if(!lookingforplayer)
                LookForPlayer();
        }
	}

    public void Chase()
    {
        if (Vector3.Distance(transform.position, player.transform.position) <= AgroRadius)
        {
            Move(player.transform.position);
        }
        else
        {
            Move(Vector3.zero, false);
            LookForPlayer();
        }
    }

    bool Move(Vector3 trans, bool move = true)
    {
        agent.SetDestination(trans);
        float distance = agent.remainingDistance - agent.stoppingDistance;
        if (distance >= 0 && move)
        {
            character.Move(agent.desiredVelocity, false, false);
        }
        else
        {
            character.Move(Vector3.zero, false, false);

        }
        return true;
    }

    public void LookForPlayer()
    {
        lookingforplayer = false;
        Vector3[] points = new Vector3[NumberOfPoints];
        points = MakeRandomPoints(transform.position, NumberOfPoints);
        foreach (Vector3 point in points)
        {
            Move(point);
        }
        lookingforplayer = true;
    }

    public Vector3[] MakeRandomPoints(Vector3 startPos, int numberofpoint )
    {
        Vector3[] points = new Vector3[numberofpoint];
        for (int i = 0; i < NumberOfPoints; i++)
        {
            points[i] = Random.insideUnitSphere * FindingRadius + startPos;
        }

        return points;
    }

    private void OnDrawGizmos()
    {
        
    }
}
