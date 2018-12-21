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

    private void Start()
    {
        PositionCount = 0;
        speed = MovingSpeed;
    }

    private void Update()
    {
        float distance = Vector3.Distance(this.transform.position, positions[PositionCount].transform.position);
        //dir = positions[PositionCount].transform.position - transform.position;
        bool waiting = false;

        if (!waiting)
            transform.Translate(dir * speed * Time.deltaTime);

        if (distance < stoppingDistance)
        {
            //waiting = true
            StartCoroutine(NextPoint(WaitingTime));
        }

        if (distance < slowingDistance)
        {
            speed = slowingSpeed;
        }

        if (distance > slowingDistance)
        {
            speed = MovingSpeed;
        }

    }

    IEnumerator NextPoint(float time)
    {
        yield return new WaitForSeconds(time);
        PositionCount++;
        if (PositionCount == positions.Count)
        {
            PositionCount = 0;
        }
        dir = positions[PositionCount].transform.position - transform.position;

    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(positions[PositionCount].transform.position, .3f);
        Gizmos.DrawRay(transform.position, transform.position * speed);
    }


}
