using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spider : MonoBehaviour
{
    Vector3 pos;
    Vector3 endPos;

    Rigidbody2D rb2d;

    RaycastHit2D hit2d;

    float distance;

    bool clicked;

	void Start ()
    {
        rb2d = GetComponent<Rigidbody2D>();	
	}
	
	// Update is called once per frame
	void Update ()
    {
	    if(Input.GetMouseButtonDown(0))
        {
            pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            hit2d = Physics2D.Raycast(pos, Vector2.zero, Mathf.Infinity);
            
            if(hit2d == true)
            {
                if(hit2d.collider.name == "Spider")
                {
                    clicked = true;
                }
            }
        }

        if(Input.GetMouseButtonUp(0) && clicked)
        {
            endPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            distance = endPos.x - pos.x;

            if(distance > 1f)
            {
                rb2d.AddForce(new Vector3(100, 0, 0));
            }

            else if(distance < 1f)
            {
                rb2d.AddForce(new Vector3(-100, 0, 0));
            }

            clicked = false;
        }
	}
}
