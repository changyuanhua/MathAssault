using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_bullet_controller : MonoBehaviour {
    private void Start()
    {
        render = GetComponent<Renderer>();
        movingVector = Vector3.Normalize(Vector3.forward);
    }
    private void FixedUpdate()
    {
        if (is_moving)
        {
            transform.Translate(movingVector * speed * Time.deltaTime);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Environment"))
        {
            is_moving = false;
            render.enabled = false;
            Destroy(gameObject, destroy_time);
        }
        else if (other.CompareTag("Player"))
        {
            is_moving = false;
            render.enabled = false;
            Destroy(gameObject, destroy_time);
        }
    }
    public float speed = 20.0f;
    public float destroy_time = 1.0f;
    private Vector3 movingVector;
    private bool is_moving = true;
    private Renderer render;
}
