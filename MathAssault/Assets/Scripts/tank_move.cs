using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tank_move : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	// Update is called once per frame
	void Update () {
        tank.transform.localPosition += moving_speed * Time.deltaTime * Vector3.forward;
        Vector3 targetDir = new Vector3(0, 0, 1);
        Vector3 newDir = Vector3.RotateTowards(tank.transform.forward, targetDir, moving_speed * Time.deltaTime * 10, 0.0F);
        tank.transform.rotation = Quaternion.LookRotation(newDir);
    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Cube_U (8)")
        {
            tank.transform.localPosition += moving_speed * Time.deltaTime * Vector3.back;
            Vector3 targetDir = new Vector3(0, 0, -1);
            Vector3 newDir = Vector3.RotateTowards(tank.transform.forward, targetDir, moving_speed * Time.deltaTime * 10, 0.0F);
            tank.transform.rotation = Quaternion.LookRotation(newDir);
        }
    }
    private float moving_speed = 10f;
    public GameObject tank;
}
