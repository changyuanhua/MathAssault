using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class tank_controller : MonoBehaviour
{
    private void Start()
    {
        nav_mesh_agent = GetComponent<NavMeshAgent>();
        nav_mesh_agent.autoBraking = false;

        GotoNextPoint();

        weapon = GetComponent<enemy_weapon_controller>();
    }

    private void Update()
    {
        if (!IsPathPending() && IsDestinationReached())
        {
            GotoNextPoint();
        }
    }

    private void GotoNextPoint()
    {
        Vector3 new_destination = new Vector3(
            Random.Range(area_boundary.x_min, area_boundary.x_max),
            0.25f,
            Random.Range(area_boundary.z_min, area_boundary.z_max));
        SetDestination(new_destination);
    }

    public void SetDestination(Vector3 destination)
    {
        NavMeshHit hit;
        if (NavMesh.SamplePosition(destination, out hit, area_search_range, 1))
        {
            nav_mesh_agent.SetDestination(hit.position);
        }
    }

    private bool IsPathPending()
    {
        return nav_mesh_agent.pathPending;
    }

    private bool IsDestinationReached()
    {
        return (nav_mesh_agent.remainingDistance < point_reach_allowance_range);
    }

    public void Shoot()
    {
        weapon.ShootFire();
    }

    private enemy_weapon_controller weapon;

    private const float area_search_range = 10.0f;
    private const float point_reach_allowance_range = 1.0f;

    private NavMeshAgent nav_mesh_agent;

    public boundary area_boundary;
}
