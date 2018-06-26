using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(AudioSource))]
public class player_weapon_controller : MonoBehaviour
{
    private void Start()
    {
        current_ammunition = maximum_ammunition;
        shot_reload_time = reload_delta;
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
            if (shot_reload_time >= reload_delta)
            {
                ++current_ammunition;
                shot_reload_time = (HasFullAmmunition() ? reload_delta : 0.0f);
                reload_sound.Play();
            }
            else
            {
                shot_reload_time += Time.deltaTime;
            }
        }
    }

    public void ShootFire()
    {
        if (is_ready_to_fire && HasAmmunition())
        {
            if (HasFullAmmunition())
            {
                shot_reload_time = 0.0f;
            }

            Transform clone = Instantiate(shot,
                                          shot_spawn.position,
                                          shot_spawn.rotation);
            clone.GetComponent<player_bullet_controller>().controller
                = controller;
            shot_cool_down_time = 0.0f;
            --current_ammunition;
            shaker.Shake();
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

    private bool HasAmmunition()
    {
        return (current_ammunition > 0);
    }

    private bool HasFullAmmunition()
    {
        return (current_ammunition >= maximum_ammunition);
    }

    private bool IsShooting()
    {
        return (Input.GetButton("Fire1"));
    }

    public game_controller controller;

    public Transform shot;
    public Transform shot_spawn;
    public int maximum_ammunition = 3;
    public float fire_delta = 0.25f;
    private float shot_cool_down_time = 0.0f;
    private bool is_ready_to_fire = true;
    public float reload_delta = 1.0f;

    private int _current_ammunition;
    public int current_ammunition
    {
        get { return _current_ammunition; }
        protected set { _current_ammunition = value; }
    }
    private float _shot_reload_time;
    public float shot_reload_time
    {
        get { return _shot_reload_time; }
        protected set { _shot_reload_time = value; }
    }

    public ui_shaker shaker;
    public AudioSource shoot_sound;
    public AudioSource reload_sound;
}
