using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class random_powerup_controller : MonoBehaviour
{
    public enum powerups { AddScore, AddLife, AddBullet }

    private void Start()
    {
        pick_up = GetComponent<AudioSource>();
        controller = game_controller_object.GetComponent<game_controller>();
        is_active = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!is_active)
        {
            if (other.CompareTag("Player"))
            {
                is_active = true;
                powerups item = RandomEnumValue<powerups>();
                Debug.Log(controller);

                switch (item)
                {
                    case powerups.AddScore:
                        controller.GetScore(UnityEngine.Random.Range(1, 5));
                        break;
                    case powerups.AddLife:
                        other.GetComponent<player_controller>().GetLife(1);
                        break;
                    case powerups.AddBullet:
                        for (int i = 0; i < 360; i += 15)
                        {
                            Transform clone
                                = Instantiate(shot,
                                              transform.position,
                                              Quaternion.identity);
                            clone.transform.Rotate(Vector3.up * i);
                            clone.GetComponent<player_bullet_controller>()
                            .controller = controller;
                        }
                        break;
                }

                pick_up.Play();
                GetComponent<Renderer>().enabled = false;

                Destroy(gameObject, 2.0f);
            }
        }

    }

    static T RandomEnumValue<T>()
    {
        var value = Enum.GetValues(typeof(T));
        return (T)value.GetValue(new System.Random().Next(value.Length));
    }

    private bool is_active = false;
    private AudioSource pick_up;
    public Transform game_controller_object;
    private game_controller controller;
    public Transform shot;
}
