﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    LineRenderer line;

    public GameObject[] mirror;

    public bool[] reflected;

    int linecount = 2;

	void Start ()
    {
        line = GetComponent<LineRenderer>();

        line.SetPosition(0, this.transform.position);
        line.SetPosition(1, mirror[0].transform.position);
    }
	
	void Update ()
    {
        line.positionCount = linecount;

        if (reflected[0])
        {
            linecount = 3;
            line.SetPosition(2, mirror[1].transform.position);

            if (reflected[1])
            {
                linecount = 4;
                line.SetPosition(3, mirror[2].transform.position);

                if (reflected[3])
                {
                    linecount = 5;
                    line.SetPosition(4, mirror[4].transform.position);
                }

                else
                {
                    linecount = 4;
                }
            }

            else if (reflected[2])
            {
                linecount = 4;
                line.SetPosition(3, mirror[3].transform.position);

                if (reflected[4])
                {
                    linecount = 5;
                    line.SetPosition(4, mirror[5].transform.position);
                }

                else
                {
                    linecount = 4;
                }
            }

            else
            {
                linecount = 3;
            }
        }

        else
        {
            linecount = 2;
        }
	}
}