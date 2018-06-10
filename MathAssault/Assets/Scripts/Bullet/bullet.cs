using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
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

    protected virtual void OnTriggerEnter(Collider other) { }

    public int damage = 1;
    public float speed = 20.0f;
    public float destroy_time = 1.5f;
    protected Vector3 movingVector;
    protected bool is_moving = true;
    protected Renderer render;
}
