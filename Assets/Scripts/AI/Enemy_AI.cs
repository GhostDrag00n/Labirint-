﻿using UnityEngine;
using UnityEngine.AI;
using UnityStandardAssets.Characters.ThirdPerson;

public class Enemy_AI : MonoBehaviour {

    public Animator anim;
    public GameObject Player;
    public GameObject Home;
    public int NumberOfPoints;
    public float LookingRadius;

    public GameObject cyl;

    [HideInInspector]
    public float height;

    public NavMeshAgent agent;

    public ThirdPersonCharacter character;

    private void Start()
    {
        agent.updateRotation = false;
    }

    public GameObject GetPlayer()
    {
        return Player;
    }

    private void Update()
    {
        anim.SetFloat("Distance", Vector3.Distance(this.transform.position, Player.transform.position));


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

    public bool RandomPoint(Vector3 center, float range, out Vector3 result)
    {
        for (int i = 0; i < 30; i++)
        {
            Vector3 randomPoint = center + Random.insideUnitSphere * range;
            NavMeshHit hit;
            if (NavMesh.SamplePosition(randomPoint, out hit, 1.0f, NavMesh.AllAreas))
            {
                result = hit.position;
                cyl.transform.position = hit.position;
                return true;
            }
        }
        result = Vector3.zero;
        return false;
    }

    public Vector3 RandomNavSphere(Vector3 origin, float distance, int layermask)
    {
        Vector3 randomDirection = Random.insideUnitSphere * distance;

        randomDirection += origin;

        NavMeshHit navHit;

        NavMesh.SamplePosition(randomDirection, out navHit, distance, layermask);

        return navHit.position;
    }
}
