using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class random_powerup_controller : MonoBehaviour
{
    public enum powerups { AddScore, AddLife, AddBullet }

    private void Start()
    {
        controller = game_controller.GetComponent<game_controller>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            powerups item = RandomEnumValue<powerups>();
            Debug.Log(item);

            switch (item)
            {
                case powerups.AddScore:
                    controller.score += UnityEngine.Random.Range(1, 5);
                    break;
                case powerups.AddLife:
                    other.GetComponent<player_controller>().current_life += 1;
                    break;
                case powerups.AddBullet:
                    for (int i = 0; i < 360; i += 15)
                    {
                        Transform clone
                            = Instantiate(shot,
                                          transform.position,
                                          Quaternion.identity);
                        clone.transform.Rotate(Vector3.up * i);
                        clone.GetComponent<player_bullet_controller>().controller
                            = controller;
                    }
                    break;
            }

            Destroy(gameObject);
        }
    }

    static T RandomEnumValue<T>()
    {
        var value = Enum.GetValues(typeof(T));
        return (T)value.GetValue(new System.Random().Next(value.Length));
    }
    public Transform game_controller;
    private game_controller controller;
    public Transform shot;
}
