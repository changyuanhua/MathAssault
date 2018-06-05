using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class player_lookable_controller : MonoBehaviour
{
    private void Start()
    {
        controller = itself.GetComponent<tank_controller>();
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Vector3 look_vector
                = new Vector3(other.transform.position.x - transform.position.x,
                              transform.position.y,
                              other.transform.position.z - transform.position.z);
            Lookable(look_vector);
        }
    }
    private void Lookable(Vector3 look_direction)
    {
        Ray ray = new Ray(eyes.position, look_direction);
        RaycastHit rayCastHit;

        if (Physics.Raycast(ray, out rayCastHit))
        {
            if (rayCastHit.transform.CompareTag("Player"))
            {
                controller.SetDestination(rayCastHit.point);
                controller.Shoot();
            }
        }
    }

    private tank_controller controller;
    public Transform itself;
    public Transform eyes;
}
