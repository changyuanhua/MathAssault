using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class player_weapon_controller : MonoBehaviour, weapon
{
    private void Start()
    {
        _current_ammunition = maximum_ammunition;
        _shot_reload_time = reload_delta;
        shot_cool_down_time = fire_delta;
    }

    private void Update()
    {
        AmmunitionReload();
        ShotCoolDown();

        if (IsShooting())
        {
            ShootFire();
        }
    }

    public void AmmunitionReload()
    {
        if (!HasFullAmmunition())
        {
            if (_shot_reload_time >= reload_delta)
            {
                ++_current_ammunition;
                _shot_reload_time = (HasFullAmmunition() ? reload_delta : 0.0f);
            }
            else
            {
                _shot_reload_time += Time.deltaTime;
            }
        }
    }

    public void ShootFire()
    {
        if (is_ready_to_fire && HasAmmunition())
        {
            if (HasFullAmmunition())
            {
                _shot_reload_time = 0.0f;
            }

            Instantiate(shot, shot_spawn.position, shot_spawn.rotation);
            shot_cool_down_time = 0.0f;
            --_current_ammunition;
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

    private bool HasAmmunition()
    {
        return (_current_ammunition > 0);
    }

    private bool HasFullAmmunition()
    {
        return (_current_ammunition >= maximum_ammunition);
    }

    private bool IsShooting()
    {
        return (Input.GetButton("Fire1"));
    }

    public Transform shot;
    public Transform shot_spawn;
    public int maximum_ammunition = 3;
    private int _current_ammunition;
    public float fire_delta = 0.25f;
    private float shot_cool_down_time = 0.0f;
    private bool is_ready_to_fire = true;
    public float reload_delta = 1.0f;
    private float _shot_reload_time;

    public int current_ammunition { get { return _current_ammunition; } }
    public float shot_reload_time { get { return _shot_reload_time; } }
}
