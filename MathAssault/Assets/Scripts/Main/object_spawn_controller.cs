using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class object_spawn_controller : MonoBehaviour
{
    private void Start()
    {
        for (int iter = 0; iter < spawn_number; ++iter)
        {
            Spawn();
        }
    }

    public void Spawn()
    {
        Vector3 spawn_position = new Vector3(
            Random.Range(area_boundary.x_min, area_boundary.x_max),
            0.25f,
            Random.Range(area_boundary.z_min, area_boundary.z_max));

        NavMeshHit hit;
        if (NavMesh.SamplePosition(spawn_position, out hit, 10.0f, 1))
        {
            Transform clone
                 = Instantiate(spawn_object, hit.position, Quaternion.identity);
            clone.tag = "Enemy";
            clone.GetComponent<tank_controller>().area_boundary
                 = area_boundary;
            clone.GetComponent<tank_controller>().game_controller_object
                 = transform;

            Transform clone_spawn_particle = Instantiate(spawn_particle,
                                                         hit.position,
                                                         Quaternion.identity);
            Destroy(clone_spawn_particle.gameObject, 0.5f);
        }
        else
        {
            Debug.Log("Clone failed");
        }
    }

    public Transform spawn_object;
    public int spawn_number = 9;

    // Spawn Area Range
    public boundary area_boundary;
    public Transform spawn_particle;
}
