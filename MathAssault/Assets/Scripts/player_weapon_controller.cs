using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class player_weapon_controller : MonoBehaviour, weapon
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

    private void LateUpdate()
    {
        AmmunitionShow();
    }


    public void AmmunitionReload()
    {
        if (!HasFullAmmunition())
        {
            if (shot_reload_time >= reload_delta)
            {
                ++current_ammunition;
                shot_reload_time = (HasFullAmmunition() ? reload_delta : 0.0f);
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

            Instantiate(shot, shot_spawn.position, shot_spawn.rotation);
            shot_cool_down_time = 0.0f;
            --current_ammunition;
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

    private void AmmunitionShow()
    {
        canvas_ammunition_text.text = current_ammunition.ToString();
        canvas_ammunition_reload_image.fillAmount
            = 1.0f - (shot_reload_time / reload_delta);
    }

    public Transform shot;
    public Transform shot_spawn;
    public int maximum_ammunition = 3;
    private int current_ammunition;
    public float fire_delta = 0.25f;
    private float shot_cool_down_time = 0.0f;
    private bool is_ready_to_fire = true;
    public float reload_delta = 1.0f;
    private float shot_reload_time;
    public Text canvas_ammunition_text;
    public Image canvas_ammunition_reload_image;
}
