using UnityEngine;
using UnityEngine.AI;

public class Astronot_AI : MonoBehaviour
{
    NavMeshAgent Agent;
    GameObject[] Goals;
 
    void Start()
    {
        Agent = (NavMeshAgent)GetComponent("NavMeshAgent");
        Goals = GameObject.FindGameObjectsWithTag("goal");
        Agent.SetDestination(Goals[Random.Range(0, Goals.Length)].transform.position);
        
    }
   
    void Update()
    {
        Wander();
    }

    void Wander()
    {
        if(Agent.remainingDistance<1)
            Agent.SetDestination(Goals[Random.Range(0, Goals.Length)].transform.position);

    }
  

}
