using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIController : MonoBehaviour
{
    [Header("Patrol")]
    [SerializeField] private Transform waypoints;
    private int currentWayPoint;

    [Header("Components")]
    NavMeshAgent agent;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        if (agent.remainingDistance <= 0.2f) 
        {
            currentWayPoint++;
            if (currentWayPoint >= waypoints.childCount)
            {
                currentWayPoint = 0;
            }
            agent.SetDestination(waypoints.GetChild(currentWayPoint).position);
        }
    }

}



