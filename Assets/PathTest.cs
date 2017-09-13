using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathTest : MonoBehaviour
{
    //   public GameObject[] pos;
    //   Vector3 thispos;

    //   float distance;
    //   float speed = 1.0f;

    //   int idx;

    //void Update ()
    //   {
    //       distance = Vector3.Distance(this.transform.position, pos[idx].transform.position);

    //       if (distance < 1f && idx < pos.Length - 1)
    //       {
    //           idx++;
    //           speed += 0.5f;
    //       }

    //       thispos = Vector3.Lerp(this.transform.position, pos[idx].transform.position, speed * Time.deltaTime);

    //       this.transform.position = thispos;
    //}

    private float RotateSpeed = 5f;
    private float Radius = 0.5f;

    private Vector2 _centre;
    private float _angle;

    public GameObject pos;

    bool isclicked;

    private void Start()
    {
        _centre = transform.position;
    }

    private void Update()
    {
        if(!isclicked)
        {
            _angle += RotateSpeed * Time.deltaTime;


            var offset = new Vector2(Mathf.Sin(_angle), Mathf.Cos(_angle)) * Radius;
            transform.position = _centre + offset;
        }
        
        else
        {
            Vector3 thispos = Vector3.Lerp(this.transform.position, pos.transform.position, 2 * Time.deltaTime);

            this.transform.position = thispos;
        }

        if(Input.GetMouseButtonDown(0))
        {
            isclicked = true;
        }
    }
}
