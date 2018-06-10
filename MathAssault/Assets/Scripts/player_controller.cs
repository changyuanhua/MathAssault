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

    private void LateUpdate()
    {
        LifeShow();
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
            if (life_regain_time >= life_regain_delta)
            {
                ++current_life;
                life_regain_time = (HasFullHealth() ? life_regain_delta : 0.0f);
            }
            else
            {
                life_regain_time += Time.deltaTime;
            }
        }
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

        }
    }

    private void LifeShow()
    {
        canvas_life_text.text = current_life.ToString();
        canvas_life_regain_image.fillAmount
            = 1.0f - (life_regain_time / life_regain_delta);
    }

    public bool HasNoLife()
    {
        return (current_life <= 0);
    }

    public bool HasFullHealth()
    {
        return (current_life >= maximum_life);
    }

    private const float hold_still = 0.0f;

    public float moving_speed = 10.0f;
    public int maximum_life = 5;
    private int current_life;
    public float life_regain_delta = 5.0f;
    private float life_regain_time;
    public Text canvas_life_text;
    public Image canvas_life_regain_image;
}
