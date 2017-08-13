using UnityEngine;
using System.Collections;

public class HomingMissile : MonoBehaviour {

    public float speed = 5f;
    public float rotatingSpeed = 200f;

    public GameObject target;

    public bool isright;

    Rigidbody2D rb;
  
	void Start ()
    {
        target = GameObject.FindGameObjectWithTag("Player");
        rb = GetComponent<Rigidbody2D>();
	}
	
	void FixedUpdate ()
    {
        if (isright == true)
        {
            Vector2 point2Target = (Vector2)transform.position - (Vector2)target.transform.position;

            point2Target.Normalize();

            float value = Vector3.Cross(point2Target, transform.right).z;

            rb.angularVelocity = rotatingSpeed * value;

            rb.velocity = transform.right * speed;
        }

        if (isright == false)
        {
            Vector2 point2Target = (Vector2)transform.position - (Vector2)target.transform.position;

            point2Target.Normalize();

            float value = Vector3.Cross(point2Target, -transform.right).z;

            rb.angularVelocity = rotatingSpeed * value;

            rb.velocity = -transform.right * speed;
        }
	}

    void OnTriggerEnter2D(Collider2D coll)
    {
        Destroy(this.gameObject);
    }
}
