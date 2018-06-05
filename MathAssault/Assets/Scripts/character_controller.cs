using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class character_controller : MonoBehaviour
{
    private void Start()
    {
        current_ammunition = maximum_ammunition;
        shot_reload_time = reload_delta;
        shot_cool_down_time = fire_delta;
    }
    private void Update()
    {
        Shoot();
    }
    private void LateUpdate()
    {
        AmmunitionShow();
    }
    private void FixedUpdate()
    {
        Move();
        LookAt();
    }

    private void Move()
    {
        float move_horizontal
            = Input.GetAxis("Horizontal") * moving_speed * Time.deltaTime;
        float move_vertical
            = Input.GetAxis("Vertical") * moving_speed * Time.deltaTime;

        Vector3 new_position
            = new Vector3(transform.position.x + move_horizontal,
                          transform.position.y,
                          transform.position.z + move_vertical);

        transform.localPosition = new_position;
    }

    private void LookAt()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        RaycastHit ray_cast_hit;

        if (Physics.Raycast(ray, out ray_cast_hit, 50.0f))
        {
            Vector3 look_direction
                = new Vector3(ray_cast_hit.point.x,
                              transform.position.y,
                              ray_cast_hit.point.z);
            transform.LookAt(look_direction);
        }
    }

    private void Shoot()
    {
        ShotCoolDown();
        AmmunitionReloadTime();
        ShotFire();
    }

    private void ShotCoolDown()
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

    private void AmmunitionReloadTime()
    {
        if (!hasFullAmmunition())
        {
            if (shot_reload_time >= reload_delta)
            {
                ++current_ammunition;
                shot_reload_time = (hasFullAmmunition() ? reload_delta : 0.0f);
            }
            else
            {
                shot_reload_time += Time.deltaTime;
            }
        }
    }

    private void ShotFire()
    {
        if (Input.GetButton("Fire1") && is_ready_to_fire && hasAmmunition())
        {
            if (hasFullAmmunition())
            {
                shot_reload_time = 0.0f;
            }

            Instantiate(shot, shot_spawn.position, shot_spawn.rotation);
            shot_cool_down_time = 0.0f;
            --current_ammunition;
        }
    }

    private void AmmunitionShow()
    {
        canvas_ammunition_count.text = current_ammunition.ToString();
        canvas_ammunition_reload.fillAmount
            = 1.0f - (shot_reload_time / reload_delta);
    }

    private bool hasAmmunition()
    {
        return (current_ammunition > 0);
    }

    private bool hasFullAmmunition()
    {
        return (current_ammunition >= maximum_ammunition);
    }

    private const float hold_still = 0.0f;

    public float moving_speed = 10.0f;

    public Transform shot;
    public Transform shot_spawn;
    public int maximum_ammunition = 3;
    private int current_ammunition;
    public float fire_delta = 0.25f;
    private float shot_cool_down_time = 0.0f;
    private bool is_ready_to_fire = true;
    public float reload_delta = 1.0f;
    private float shot_reload_time;

    public Text canvas_ammunition_count;
    public Image canvas_ammunition_reload;
}
