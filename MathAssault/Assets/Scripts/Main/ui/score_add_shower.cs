﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class score_add_shower : MonoBehaviour
{
    private void Start()
    {
        current_time = 0.0f;
        canvas_renderer = GetComponent<CanvasRenderer>();
    }
    private void FixedUpdate()
    {
        transform.Translate(Vector3.up * speed * Time.deltaTime);

        current_time += Time.deltaTime;

        canvas_renderer.SetAlpha(1.0f - (current_time / destroy_time));
    }

    private CanvasRenderer canvas_renderer;

    public float speed;
    public float destroy_time;
    private float current_time;
}