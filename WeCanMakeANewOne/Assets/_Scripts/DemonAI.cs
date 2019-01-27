using UnityEngine;
using UnityEngine.AI;

public class DemonAI : EnemyInfo
{
    public NavMeshAgent agent;

    Vector3 destination;
    Vector3 posFrog;
    Vector3 posSquirrel;
    float distanceFrog;
    float distanceSquirrel;

    

    void Update()
    {
        posFrog = GameObject.FindGameObjectsWithTag("Player")[0].transform.position;
        posSquirrel = GameObject.FindGameObjectsWithTag("Player")[1].transform.position;

        distanceFrog = Vector3.Distance(posFrog, transform.position);
        distanceSquirrel = Vector3.Distance(posSquirrel, transform.position);

        if (distanceFrog <= aggroDistance || distanceSquirrel <= aggroDistance)
        {
            if (distanceFrog <= distanceSquirrel)
            {
                destination = posFrog;
            }
            else
            {
                destination = posSquirrel;
            }
        }
        else
        {
            destination = GameObject.FindGameObjectWithTag("TheTree").transform.position;
        }


        agent.SetDestination(destination);
    }
}
