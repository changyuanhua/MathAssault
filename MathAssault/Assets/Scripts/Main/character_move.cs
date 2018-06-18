using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class character_move : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {
        cam.transform.localPosition = new Vector3(1, 12, 4);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            transform.localPosition += moving_speed * Time.deltaTime * Vector3.forward;
            Vector3 targetDir = new Vector3(0, 0, 1);
            Vector3 newDir = Vector3.RotateTowards(transform.forward, targetDir, moving_speed * Time.deltaTime * 10, 0.0F);
            transform.rotation = Quaternion.LookRotation(newDir);
            if (transform.localPosition.z >= 4 || transform.localPosition.z <= -24 || transform.localPosition.x <= 1 || transform.localPosition.x >= 29)
            {
                if (transform.localPosition.x <= 1)
                {
                    cam.transform.localPosition = new Vector3(1, cam.transform.localPosition.y, transform.localPosition.z);
                }
                if (transform.localPosition.x >= 29)
                {
                    cam.transform.localPosition = new Vector3(29, cam.transform.localPosition.y, transform.localPosition.z);
                }
                if (transform.localPosition.z >= 4)
                {
                    cam.transform.localPosition = new Vector3(cam.transform.localPosition.x, cam.transform.localPosition.y, 4);
                }
                if (transform.localPosition.z <= -24)
                {
                    cam.transform.localPosition = new Vector3(cam.transform.localPosition.x, cam.transform.localPosition.y, -24);
                }
            }
            else
            {
                cam.transform.localPosition = new Vector3(transform.localPosition.x, 12, transform.localPosition.z);
            }
        }
        else if (Input.GetKey(KeyCode.S))
        {
            transform.localPosition += moving_speed * Time.deltaTime * Vector3.back;
            Vector3 targetDir = new Vector3(0, 0, -1);
            Vector3 newDir = Vector3.RotateTowards(transform.forward, targetDir, moving_speed * Time.deltaTime * 10, 0.0F);
            transform.rotation = Quaternion.LookRotation(newDir);
            if (transform.localPosition.z >= 4 || transform.localPosition.z <= -24 || transform.localPosition.x <= 1 || transform.localPosition.x >= 29)
            {
                if (transform.localPosition.x <= 1)
                {
                    cam.transform.localPosition = new Vector3(1, cam.transform.localPosition.y, transform.localPosition.z);
                }
                if (transform.localPosition.x >= 29)
                {
                    cam.transform.localPosition = new Vector3(29, cam.transform.localPosition.y, transform.localPosition.z);
                }
                if (transform.localPosition.z >= 4)
                {
                    cam.transform.localPosition = new Vector3(cam.transform.localPosition.x, cam.transform.localPosition.y, 4);
                }
                if (transform.localPosition.z <= -24)
                {
                    cam.transform.localPosition = new Vector3(cam.transform.localPosition.x, cam.transform.localPosition.y, -24);
                }
            }
            else
            {
                cam.transform.localPosition = new Vector3(transform.localPosition.x, 12, transform.localPosition.z);
            }
        }
        else if (Input.GetKey(KeyCode.A))
        {
            transform.localPosition += moving_speed * Time.deltaTime * Vector3.left;
            Vector3 targetDir = new Vector3(-1, 0, 0);
            Vector3 newDir = Vector3.RotateTowards(transform.forward, targetDir, moving_speed * Time.deltaTime * 10, 0.0F);
            transform.rotation = Quaternion.LookRotation(newDir);
            if (transform.localPosition.z >= 4 || transform.localPosition.z <= -24 || transform.localPosition.x <= 1 || transform.localPosition.x >= 29)
            {
                if (transform.localPosition.z >= 4)
                {
                    cam.transform.localPosition = new Vector3(transform.localPosition.x, cam.transform.localPosition.y, 4);
                }
                if (transform.localPosition.z <= -24)
                {
                    cam.transform.localPosition = new Vector3(transform.localPosition.x, cam.transform.localPosition.y, -24);
                }
                if (transform.localPosition.x <= 1)
                {
                    cam.transform.localPosition = new Vector3(1, cam.transform.localPosition.y, cam.transform.localPosition.z);
                }
                if (transform.localPosition.x >= 29)
                {
                    cam.transform.localPosition = new Vector3(29, cam.transform.localPosition.y, cam.transform.localPosition.z);
                }
            }
            else
            {
                cam.transform.localPosition = new Vector3(transform.localPosition.x, 12, transform.localPosition.z);
            }
        }
        else if (Input.GetKey(KeyCode.D))
        {
            transform.localPosition += moving_speed * Time.deltaTime * Vector3.right;
            Vector3 targetDir = new Vector3(1, 0, 0);
            Vector3 newDir = Vector3.RotateTowards(transform.forward, targetDir, moving_speed * Time.deltaTime * 10, 0.0F);
            transform.rotation = Quaternion.LookRotation(newDir);
            if (transform.localPosition.z >= 4 || transform.localPosition.z <= -24 || transform.localPosition.x <= 1 || transform.localPosition.x >= 29)
            {
                if (transform.localPosition.z >= 4)
                {
                    cam.transform.localPosition = new Vector3(transform.localPosition.x, cam.transform.localPosition.y, 4);
                }
                if (transform.localPosition.z <= -24)
                {
                    cam.transform.localPosition = new Vector3(transform.localPosition.x, cam.transform.localPosition.y, -24);
                }
                if (transform.localPosition.x <= 1)
                {
                    cam.transform.localPosition = new Vector3(1, cam.transform.localPosition.y, cam.transform.localPosition.z);
                }
                if (transform.localPosition.x >= 29)
                {
                    cam.transform.localPosition = new Vector3(29, cam.transform.localPosition.y, cam.transform.localPosition.z);
                }
            }
            else
            {
                cam.transform.localPosition = new Vector3(transform.localPosition.x, 12, transform.localPosition.z);
            }
        }
    }
    private float moving_speed = 10f;
    public Camera cam;
}
