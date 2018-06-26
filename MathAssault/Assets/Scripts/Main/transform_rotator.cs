using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class transform_rotator : MonoBehaviour
{
    private void Update()
    {
        this.transform.Rotate(new Vector3(15, 30, 45) * Time.deltaTime);
    }
}
