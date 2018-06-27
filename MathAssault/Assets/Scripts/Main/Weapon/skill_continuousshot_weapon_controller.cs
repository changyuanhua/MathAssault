using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(player_weapon_controller))]
public class skill_continuousshot_weapon_controller : MonoBehaviour, skill
{
    private void Start()
    {
        is_ready = true;
        shot_reload_time = reload_delta;
        weapon = GetComponent<player_weapon_controller>();
    }

    private void Update()
    {
        SkillReload();

        if (ISCasting())
        {
            CastSkill();
        }
    }

    public void SkillReload()
    {
        if (!is_ready)
        {
            if (shot_reload_time >= reload_delta)
            {
                shot_reload_time = reload_delta;
                is_ready = true;
                shower.Ready();
                skill_ready_sound.Play();
            }
            else
            {
                shot_reload_time += Time.deltaTime;
            }
        }
    }

    public void CastSkill()
    {
        if (is_ready && !is_casting)
        {
            StartCoroutine(Casting());
            shot_reload_time = 0.0f;
            shaker.Shake();
            cast_sound.Play();
            Debug.Log("CastSkill: Continuousshot");
        }
    }

    private IEnumerator Casting()
    {
        is_casting = true;

        float normal_reload_delta = weapon.reload_delta;
        float normal_fire_delta = weapon.fire_delta;
        weapon.reload_delta = 0.0f;
        weapon.fire_delta = fire_delta;
        yield return new WaitForSeconds(duration);

        weapon.reload_delta = normal_reload_delta;
        weapon.fire_delta = normal_fire_delta;
        is_casting = false;
        is_ready = false;
    }

    private bool ISCasting()
    {
        return (Input.GetButton("Fire3"));
    }

    private player_weapon_controller weapon;

    private bool is_ready = true;
    public float reload_delta = 8.0f;
    public float fire_delta;

    private float _shot_reload_time;
    public float shot_reload_time
    {
        get { return _shot_reload_time; }
        protected set { _shot_reload_time = value; }
    }

    public float duration = 2.0f;
    private bool _is_casting = false;
    public bool is_casting
    {
        get { return _is_casting; }
        protected set { _is_casting = value; }
    }

    public ui_shaker shaker;
    public ui_skill_continuousshot_shower shower;

    public AudioSource cast_sound;
    public AudioSource skill_ready_sound;
}
