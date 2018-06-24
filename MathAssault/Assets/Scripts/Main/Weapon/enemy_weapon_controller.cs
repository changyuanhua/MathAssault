using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class enemy_weapon_controller : MonoBehaviour, weapon
{
    private void Start()
    {
        shot_cool_down_time = fire_delta;
    }

    private void Update()
    {
        ShotCoolDown();
    }

    public void AmmunitionReload() { }

    public void ShootFire()
    {
        if (is_ready_to_fire)
        {
            Instantiate(shot, shot_spawn.position, shot_spawn.rotation);
            shot_cool_down_time = 0.0f;
            shoot_sound.Play();
        }
    }

    public void ShotCoolDown()
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

    public Transform shot;
    public Transform shot_spawn;
    public float fire_delta = 0.25f;
    private float shot_cool_down_time = 0.0f;
    private bool is_ready_to_fire = true;

    public AudioSource shoot_sound;
}
