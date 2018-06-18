using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera_controller : MonoBehaviour
{
    private void Start()
    {
        following_offset = transform.position - following_object.position;
    }

    private void LateUpdate()
    {
        transform.position = following_object.position + following_offset;
    }

    public Transform following_object;

    private Vector3 following_offset;
}
