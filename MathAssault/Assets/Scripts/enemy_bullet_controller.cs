using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_bullet_controller : bullet
{
    protected override void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Environment"))
        {
            is_moving = false;
            render.enabled = false;
            Destroy(gameObject, destroy_time);
        }
        else if (other.CompareTag("Player"))
        {
            is_moving = false;
            render.enabled = false;
            Destroy(gameObject, destroy_time);
            other.GetComponent<player_controller>().TakingDamage(damage);
        }
    }
}
