using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class create_map : MonoBehaviour
{
    // Use this for initialization
    void Awake()
    {
        Transform h1, h2, h3, h4, h5, h6;
        Transform s1, s2, s3, s4, s5, s6;
        //h_x: -7~37-8
        //h_z: -27~7
        /*h_x = Random.Range(-7, 29);
        for (int i = 0; i < 11; i++)
        {
            h1 = Instantiate(strick_h);
            h1.localPosition = new Vector3(h_x, 1, h_z);
            h2 = Instantiate(strick_h);
            h2.localPosition = h1.localPosition + new Vector3(4, 0, 0);
            h3 = Instantiate(strick_h);
            h3.localPosition = h2.localPosition + new Vector3(4, 0, 0);
            if (ptrh)
            {
                h_x -= 13;
            }
            else
            {
                h_x += 10;
            }
            if (h_x > 29)
            {
                ptrh = true;
                h_x = 29;
            }
            if (h_x < -7)
            {
                ptrh = false;
                h_x = -7;
            }
            h_z += 3;
        }*/
        //s_x: -3~37
        //s_z: -27+8~7
        s_z = Random.Range(-15, 1);
        int ptr = 0;
        for (int i = 0; i < 8; i++)
        {
            s1 = Instantiate(strick_s);
            s1.localPosition = new Vector3(s_x, 1, s_z);
            s2 = Instantiate(strick_s);
            s2.localPosition = s1.localPosition - new Vector3(0, 0, 4);
            s3 = Instantiate(strick_s);
            s3.localPosition = s2.localPosition - new Vector3(0, 0, 4);
            if (s_z > 4)
            {
                s4 = Instantiate(strick_s);
                s4.localPosition = new Vector3(s_x, 1, -19); ;
                s5 = Instantiate(strick_s);
                s5.localPosition = s4.localPosition - new Vector3(0, 0, 4);
                s6 = Instantiate(strick_s);
                s6.localPosition = s5.localPosition - new Vector3(0, 0, 4);
            }
            if (s_z < -16)
            {
                s4 = Instantiate(strick_s);
                s4.localPosition = new Vector3(s_x, 1, 7); ;
                s5 = Instantiate(strick_s);
                s5.localPosition = s4.localPosition - new Vector3(0, 0, 4);
                s6 = Instantiate(strick_s);
                s6.localPosition = s5.localPosition - new Vector3(0, 0, 4);
            }
            if ((i + 1) % 2 == 1)
            {
                h1 = Instantiate(strick_h);
                h1.localPosition = new Vector3(s2.localPosition.x - 3, 1, s2.localPosition.z);
                h1.name = "brick" + i;
                ptr++;
            }
            if ((i + 1) % 2 == 0)
            {
                h1 = Instantiate(strick_h);
                h1.localPosition = new Vector3(s2.localPosition.x + 3, 1, s2.localPosition.z);
                h1.name = "brick" + i;
                ptr++;
            }
            if (ptrs)
            {
                s_z -= 13;
            }
            else
            {
                s_z += 10;
            }
            if (s_z > 4)
            {
                ptrs = true;
                s_z = 7;
            }
            if (s_z < -16)
            {
                ptrs = false;
                s_z = -19;
            }
            if (i == 0)
            {
                s_x += 6;
            }
            else if (i == 6)
            {
                s_x += 7;
            }
            else
            {
                s_x += 5;
            }
        }
    }

    private bool ptrh = false;
    private bool ptrs = false;
    private int h_x = -7;
    private int h_z = -27;
    private int s_x = -4;
    private int s_z = -27;
    public Transform strick_h;
    public Transform strick_s;
}
