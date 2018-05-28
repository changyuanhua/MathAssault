using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class object_spawn : MonoBehaviour
{
    void Start()
    {
        for (int iter = 0; iter < spawn_number; ++iter)
        {
            Vector3 spawn_position = new Vector3(
                Random.Range(range_x.x, range_x.y),
                0.25f,
                Random.Range(range_z.x, range_z.y));

            NavMeshHit hit;
            if (NavMesh.SamplePosition(spawn_position, out hit, 10.0f, 1))
            {
                GameObject clone = Instantiate(spawn_object, hit.position, Quaternion.identity);
                clone.tag = "Enemy";
                clone.GetComponent<tank_move>().destination = destination;
            }
            else
            {
                Debug.Log("Clone failed");
            }
        }
    }

    public GameObject spawn_object;
    public int spawn_number = 9;

    // Spawn Area Range
    public Vector2 range_x;
    public Vector2 range_z;

    public Transform destination;
}
