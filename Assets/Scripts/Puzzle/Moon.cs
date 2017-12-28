using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moon : MonoBehaviour
{
    public TideManager tide_manager;

    public GameObject[] waterObj = new GameObject[2];
 
    public float[] waterYPos = new float[2];

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "rising")
        {
            tide_manager.mmon_check = 1;
            tide_manager.rising = true;
            tide_manager.is_trigger_on = false;
            waterYPos[0] = -6.7f;
            waterYPos[1] = -2.5f;
        }

        else if (collision.gameObject.name == "edd")
        {
            tide_manager.mmon_check = 2;
            tide_manager.rising = false;
            tide_manager.is_trigger_on = true;
            waterYPos[0] = -10.7f;
            waterYPos[1] = -14.5f;
        }

        else
        {
            tide_manager.mmon_check = 3;
            tide_manager.rising = false;
            tide_manager.is_trigger_on = false;
            waterYPos[0] = -7.7f;
            waterYPos[1] = -7.5f;
        }
    }
}
