using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class player_controller : MonoBehaviour
{
    private void Start()
    {
        current_life = maximum_life;
        life_regain_time = life_regain_delta;
    }

    private void Update()
    {
        HealthRegain();
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

        if (math_assault_controller.view == viewer.First)
        {
            transform.Translate(new Vector3(move_horizontal, 0, move_vertical));
        }
        else if (math_assault_controller.view == viewer.Third)
        {
            Vector3 new_position
                = new Vector3(transform.position.x + move_horizontal,
                              transform.position.y,
                              transform.position.z + move_vertical);

            transform.localPosition = new_position;
        }
    }

    private void LookAt()
    {
        if (math_assault_controller.view == viewer.First)
        {
            transform.Rotate(hold_still,
                             sensitivity_x * Input.GetAxis("Mouse X"),
                             hold_still);
        }
        else if (math_assault_controller.view == viewer.Third)
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
    }

    private void HealthRegain()
    {
        if (!HasFullHealth())
        {
            if (life_regain_time >= life_regain_delta)
            {
                GetLife(1);
                life_regain_time = (HasFullHealth() ? life_regain_delta : 0.0f);
            }
            else
            {
                life_regain_time += Time.deltaTime;
            }
        }
        else
        {
            life_regain_time = life_regain_delta;
        }
    }

    public void GetLife(int life)
    {
        life_canvas.GetComponent<ui_player_health_shower>().AddLife(life);
        current_life += life;
        regain_health.Play();
    }

    public void TakingDamage(int damage)
    {
        if (current_life > 0)
        {
            current_life -= damage;
            life_regain_time = 0.0f;
        }

        if (HasNoLife())
        {
            game_controller.GameOver();
        }
    }

    public bool HasNoLife()
    {
        return (current_life <= 0);
    }

    public bool HasFullHealth()
    {
        return (current_life >= maximum_life);
    }

    public game_controller game_controller;

    private const float hold_still = 0.0f;

    public float sensitivity_x = 15.0f;

    public float moving_speed = 10.0f;
    public int maximum_life = 5;
    public int current_life;

    public float life_regain_delta = 10.0f;
    public AudioSource regain_health;
    private float _life_regain_time;
    public float life_regain_time
    {
        get { return _life_regain_time; }
        protected set { _life_regain_time = value; }
    }

    public Transform life_canvas;
}
