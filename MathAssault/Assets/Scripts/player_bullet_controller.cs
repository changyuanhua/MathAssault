using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_bullet_controller : bullet
{
    protected override void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Environment"))
        {
            is_moving = false;
            render.enabled = false;
            Destroy(gameObject, destroy_time);
        }
        else if (other.CompareTag("Enemy"))
        {
            is_moving = false;
            render.enabled = false;
            Destroy(gameObject, destroy_time);
        }
    }
}
