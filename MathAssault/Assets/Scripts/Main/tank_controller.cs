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

    public void Destroy()
    {
        float random = Random.Range(0.0f, 1.0f);
        if (powerup_drop_rate > random)
        {
            Transform ups
                = Instantiate(powerup, transform.position + Vector3.up,
                              transform.rotation);
            ups.GetComponent<random_powerup_controller>().game_controller_object
                = game_controller_object;
        }

        Transform clone_boom
            = Instantiate(boom, transform.position, transform.rotation);
        Destroy(clone_boom.gameObject, 3.0f);
        Destroy(gameObject);
    }

    public Transform game_controller_object;
    private enemy_weapon_controller weapon;

    private const float area_search_range = 10.0f;
    private const float point_reach_allowance_range = 1.0f;
    public float powerup_drop_rate;

    private NavMeshAgent nav_mesh_agent;

    public boundary area_boundary;
    public Transform boom;
    public Transform powerup;
}
