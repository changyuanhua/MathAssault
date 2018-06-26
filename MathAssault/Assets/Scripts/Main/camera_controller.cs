using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera_controller : MonoBehaviour
{
    private void Start()
    {
        if (math_assault_controller.view == viewer.First)
        {
            transform.position = following_object.transform.position + 1.45f * Vector3.up;
            transform.LookAt(following_object.transform.position);
            following_offset = transform.position - following_object.position;
        }
        else if (math_assault_controller.view == viewer.Third)
        {
            following_offset = transform.position - following_object.position;
        }
    }

    private void LateUpdate()
    {
        if (math_assault_controller.view == viewer.First)
        {
            if (!game_controller.askquestion_show)
            {
                transform.position = following_object.position + following_offset;
                transform.rotation = following_object.rotation;
            }
        }
        else if(math_assault_controller.view == viewer.Third)
        {
            transform.position = following_object.position + following_offset;
        }
    }

    public Transform following_object;

    private Vector3 following_offset;
}
