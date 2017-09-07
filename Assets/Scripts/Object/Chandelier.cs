using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chandelier : MonoBehaviour
{
    RaycastHit2D hit;

    Vector3 pos;

    Rigidbody2D rb2d;

    int count;

    void Start ()
    {
        rb2d = GetComponent<Rigidbody2D>();	
	}
	
	void Update ()
    {
	    if(Input.GetMouseButtonDown(0))
        {
            pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            hit = Physics2D.Raycast(pos, Vector2.zero, Mathf.Infinity);

            if(hit)
            {
                if (hit.collider.gameObject == this.gameObject)
                {
                    count++;
                }
            }
        }

        if(count == 2)
        {
            rb2d.bodyType = RigidbodyType2D.Dynamic;
        }
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        rb2d.bodyType = RigidbodyType2D.Static;
        CameraShake shake = Camera.main.GetComponent<CameraShake>();
        shake.ShakeCamera(0.1f, 0.2f);
        Destroy(this);
    }
}
