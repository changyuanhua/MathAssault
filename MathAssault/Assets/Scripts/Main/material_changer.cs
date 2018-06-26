using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class material_changer : MonoBehaviour
{
    private void Start()
    {
        rend = GetComponent<Renderer>();
    }

    private void Update()
    {
        Color color
            = new Color(RandomNumber(rend.material.color.r, change_scale),
                        RandomNumber(rend.material.color.g, change_scale),
                        RandomNumber(rend.material.color.b, change_scale));
        rend.material.color = color;
    }

    private static float RandomNumber(float number, float scale)
    {
        float offset = Random.Range(-1, 2);
        return Mathf.Clamp(number + offset * scale * Time.deltaTime, 0.0f, 1.0f);
    }

    private Renderer rend;
    public float change_scale = 3.0f;
}
