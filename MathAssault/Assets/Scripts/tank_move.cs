using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class tank_move : MonoBehaviour
{
    private void Start()
    {
        nav_mesh_agent = GetComponent<NavMeshAgent>();
        nav_mesh_agent.autoBraking = false;

        GotoNextPoint();
    }

    private void Update()
    {
        GotoNextPoint();
    }

    private void GotoNextPoint()
    {
        NavMeshHit hit;
        if (NavMesh.SamplePosition(destination.position, out hit, 10.0f, 1))
        {
            nav_mesh_agent.SetDestination(hit.position);
        }
    }

    private NavMeshAgent nav_mesh_agent;
    public Transform destination;
}
