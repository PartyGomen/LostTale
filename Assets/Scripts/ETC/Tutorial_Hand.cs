using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial_Hand : MonoBehaviour
{
    public GameObject[] hand_image = new GameObject[2];
    private float[] time_check = new float[3];
    private bool[] change = new bool[2];

	void Update ()
    {
        time_check[0] += Time.deltaTime;

        if(time_check[0] > 1f)
        {
            for (int i = 0; i < 2; i++)
            {
                change[i] = true;

                ChangeHandImage(i, true);
            }

            time_check[0] = 0.0f;
        }

        if(change[0] == true)
        {
            time_check[1] += Time.deltaTime;

            if(time_check[1] >= 0.2f)
            {
                change[0] = false;
                ChangeHandImage(0, false);
                time_check[1] = 0.0f;
            }
        }

        if (change[1] == true)
        {
            time_check[2] += Time.deltaTime;

            if (time_check[2] >= 0.5f)
            {
                change[1] = false;
                ChangeHandImage(1, false);
                time_check[2] = 0.0f;
            }
        }
    }

    void ChangeHandImage(int _idx, bool _true)
    {
        if(_true)
        {
            hand_image[_idx].transform.eulerAngles = new Vector3(0, 0, 0);
            hand_image[_idx].transform.localScale = new Vector3(0.8f, 0.8f, 1);
        }

        else
        {
            hand_image[_idx].transform.eulerAngles = new Vector3(0, 0, -30);
            hand_image[_idx].transform.localScale = new Vector3(1, 1, 1);
        }
    }
}
