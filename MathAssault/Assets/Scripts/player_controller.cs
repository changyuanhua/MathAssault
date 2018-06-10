using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_controller : MonoBehaviour
{
    private void Start()
    {
        _current_life = maximum_life;
        _life_regain_time = life_regain_delta;
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

    private void HealthRegain()
    {
        if (!HasFullHealth())
        {
            if (_life_regain_time >= life_regain_delta)
            {
                ++_current_life;
                _life_regain_time = (HasFullHealth() ? life_regain_delta : 0.0f);
            }
            else
            {
                _life_regain_time += Time.deltaTime;
            }
        }
    }

    public void TakingDamage(int damage)
    {
        if (_current_life > 0)
        {
            _current_life -= damage;
            _life_regain_time = 0.0f;
        }

        if (HasNoLife())
        {

        }
    }

    public bool HasNoLife()
    {
        return (_current_life <= 0);
    }

    public bool HasFullHealth()
    {
        return (_current_life >= maximum_life);
    }

    private const float hold_still = 0.0f;

    public float moving_speed = 10.0f;
    public int maximum_life = 5;
    private int _current_life;
    public float life_regain_delta = 5.0f;
    private float _life_regain_time;

    public int current_life { get { return _current_life; } }
    public float life_regain_time { get { return _life_regain_time; } }
}
