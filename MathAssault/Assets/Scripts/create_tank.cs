using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class create_tank : MonoBehaviour
{
    // Use this for initialization
    void Start()
    {
        Transform t;
        /* GameObject[] brick=new GameObject[8];
         for (int i = 0; i < 8; i++)
         {
             brick[i] = GameObject.Find("brick" + i);
         }*/
        for (int i = 0; i < 9; i++)
        {
            t = Instantiate(tank);
            t.name = "tank" + i;
            /*int num_z;
            do
            {
                num_z = Random.Range(-27, 6);
                for (int j=0;j<8; j++)
                {
                    if (num_z == brick[j].transform.localPosition.z)
                    {
                        ptr = false;
                    }
                }
            } while (!ptr);
            t.localPosition= new Vector3(t_x, 1, num_z);*/

            if (i == 2 || i == 6)
            {
                t.localPosition = new Vector3(t_x, 1, 6);
            }
            else if (i == 1 || i == 3 || i == 5 || i == 7)
            {
                t.localPosition = new Vector3(t_x, 1, Random.Range(-27, 6));
            }
            else if (i == 0 || i == 4 || i == 8)
            {
                t.localPosition = new Vector3(t_x, 1, -27);
            }
            if (i == 0 || i == 2)
            {
                t_x += 6;
            }
            else if (i == 7)
            {
                t_x += 7;
            }
            else
            {
                t_x += 5;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
    }
    private bool ptr = true;
    private int t_x = -7;
    public Transform tank;
}
