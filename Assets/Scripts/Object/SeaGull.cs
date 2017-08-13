using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeaGull : MonoBehaviour
{
    public GameObject[] waypoint = new GameObject[8];

    public int i = 0;

    float t = 0;
    public float speed = 0;

    void Update ()
    {
        this.transform.position = Vector2.MoveTowards(this.transform.position, waypoint[i].transform.position, speed * Time.deltaTime);

        t = Vector2.Distance(waypoint[i].transform.position, this.transform.position);

        if(t < 0.1f)
        {
            i++;

            if(i > 7)
            {
                i = 0;
            }
        }
    }
}
