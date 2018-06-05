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
    }

    private void Update()
    {
        if (!IsPathPending() && IsDestinationReached())
        {
            GotoNextPoint();
        }

        ShotCoolDown();
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

    public void Shoot()
    {
        if (is_ready_to_fire)
        {
            Instantiate(shot, shot_spawn.position, shot_spawn.rotation);
            shot_cool_down_time = 0.0f;
        }
    }
    private void ShotCoolDown()
    {
        if (shot_cool_down_time >= fire_delta)
        {
            is_ready_to_fire = true;

        }
        else
        {
            is_ready_to_fire = false;
            shot_cool_down_time += Time.deltaTime;
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

    private const float area_search_range = 10.0f;
    private const float point_reach_allowance_range = 1.0f;

    private NavMeshAgent nav_mesh_agent;

    public boundary area_boundary;

    public Transform shot;
    public Transform shot_spawn;
    public float fire_delta = 0.25f;
    private float shot_cool_down_time = 0.0f;
    private bool is_ready_to_fire = true;
}
