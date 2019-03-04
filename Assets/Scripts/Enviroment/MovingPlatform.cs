using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour {

    public List<GameObject> positions = new List<GameObject>();
    int PositionCount;

    public float MovingSpeed;
    public float slowingSpeed;
    public float slowingDistance;
    public float stoppingDistance;
    public float WaitingTime;
    Vector3 dir;
    float speed;
    bool waiting = false;

    private void Start()
    {
        PositionCount = 0;
        speed = MovingSpeed;
    }

    private void FixedUpdate()
    {
        float distance = Vector3.Distance(this.transform.position, positions[PositionCount].transform.position);
        //dir = positions[PositionCount].transform.position - transform.position;


        if (!waiting)
            transform.Translate(dir * speed * Time.deltaTime);

        if (distance < stoppingDistance)
        {
            waiting = true;
            StartCoroutine(NextPoint(WaitingTime));
            PositionCount++;
            if (PositionCount == positions.Count)
            {
                PositionCount = 0;
            }
            dir = positions[PositionCount].transform.position - transform.position;
        }
        else
        {
            speed = distance < slowingDistance ? slowingSpeed : MovingSpeed;

        }

    }

    IEnumerator NextPoint(float time)
    {
        yield return new WaitForSeconds(time);
        waiting = false;


    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(positions[PositionCount].transform.position, .3f);
        Gizmos.DrawRay(transform.position, transform.position * speed);
    }


}
