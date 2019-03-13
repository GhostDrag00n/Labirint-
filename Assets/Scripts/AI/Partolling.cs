using UnityEngine;
using UnityEngine.AI;

public class Partolling : Base_FSM
{
    public bool isWaiting = false;
    public float t = .0f;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateEnter(animator, stateInfo, layerIndex);
        AI.MoveTo(AI.Waypoints[AI.currentWaypoint].position);
    }


    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

        if (animator.GetFloat("Distance") < AI.LookingRadius)
        {
            animator.SetBool("PlayerFound", true);
        }

        //Debug.Log("Partoling");

        //Vector3 wp = GetRandomLocation();

        //AI.MoveTo(AI.Home.transform.position);
        if (Vector3.Distance(AI.transform.position, AI.Waypoints[AI.currentWaypoint].position) < 1)
        {
            isWaiting = true;
            WaitFor(3f);
            Debug.Log("Waiting");
            if (!isWaiting)
            {
                if (AI.currentWaypoint + 1 < AI.Waypoints.Length)
                {
                    AI.currentWaypoint += 1;
                    AI.MoveTo(AI.Waypoints[AI.currentWaypoint].position);
                }
                else
                {
                    AI.currentWaypoint = 0;
                    AI.MoveTo(AI.Waypoints[AI.currentWaypoint].position);
                }
            }
        }
        //if (Vector3.Distance(AI.transform.position, wp) < 1)
        //{
        //    wp = GetRandomLocation();
        //    AI.MoveTo(wp);
        //}

        //Patrolling

    }


    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
    }

    void WaitFor(float seconds)
    {
        Debug.Log(t);
        if (t >= seconds)
        {
            isWaiting = false;
            t = 0f;
            return;
        }
        t += Time.deltaTime;

    }

    Vector3 GetRandomLocation()
    {
        NavMeshTriangulation navMeshData = NavMesh.CalculateTriangulation();

        // Pick the first indice of a random triangle in the nav mesh
        int ab = Random.Range(0, navMeshData.indices.Length - 3);

        // Select a random point on it
        Vector3 point = Vector3.Lerp(navMeshData.vertices[navMeshData.indices[ab]], navMeshData.vertices[navMeshData.indices[ab + 1]], Random.value);
        Vector3.Lerp(point, navMeshData.vertices[navMeshData.indices[ab + 2]], Random.value);

        return point;
    }

}