using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moon : MonoBehaviour
{
    public GameObject[] waterObj = new GameObject[2];
 
    public float[] waterYPos = new float[2];

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "rising")
        {
            waterYPos[0] = -6.7f;
            waterYPos[1] = -2.5f;
        }

        else if (collision.gameObject.name == "edd")
        {
            waterYPos[0] = -10.7f;
            waterYPos[1] = -14.5f;
        }

        else
        {
            waterYPos[0] = -7.7f;
            waterYPos[1] = -7.5f;
        }
    }
}
