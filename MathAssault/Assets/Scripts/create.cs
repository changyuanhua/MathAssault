using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class create : MonoBehaviour {

	// Use this for initialization
	void Start () {
        //bricks
        Transform h1;
        Transform s1, s2, s3, s4, s5, s6;
        //tank
        Transform t;

        //brick
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
        //tank
        GameObject[] brick=new GameObject[8];
         for (int i = 0; i < 8; i++)
         {
             brick[i] = GameObject.Find("brick" + i);
         }
        for (int i = 0; i < 9; i++)
        {
            t = Instantiate(tank);
            t.name = "tank" + i;
            int num_z;
            do
            {
                num_z = Random.Range(-27, 6);
                for (int j=0;j<8; j++)
                {
                    if (num_z == brick[j].transform.localPosition.z)
                    {
                        ptrt = false;
                    }
                }
            } while (!ptrt);
            t.localPosition= new Vector3(t_x, 1, num_z);

            /*if (i == 2 || i == 6)
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
            }*/
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
	void Update () {
		
	}
    private bool ptrh = false;
    private bool ptrs = false;
    private int h_x = -7;
    private int h_z = -27;
    private int s_x = -4;
    private int s_z = -27;
    public Transform strick_h;
    public Transform strick_s;

    private bool ptrt = true;
    private int t_x = -7;
    public Transform tank;
}
