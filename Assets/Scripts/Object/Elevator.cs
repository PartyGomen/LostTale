using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevator : MonoBehaviour {

    public GameObject elevatorGround;
    bool isUp;
    Vector3 pos;
    Player player;

    public float upSpeed;
    public float downSpeed;

    public float miny;
    public float maxy;

	void Start ()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
	}
	
	void FixedUpdate ()
    {
		if(isUp)
        {
            elevatorGround.transform.Translate(Vector2.up * upSpeed * Time.deltaTime);
        }

        if(player.grounded == true)
        {
            elevatorGround.transform.Translate(Vector2.down * downSpeed * Time.deltaTime);
        }

        pos = this.transform.position;
        transform.position = new Vector3(pos.x, Mathf.Clamp(pos.y, miny, maxy), pos.z);
	}

    private void OnCollisionEnter2D(Collision2D coll)
    {
        if(coll.gameObject.CompareTag("Player") && coll.contacts[0].normal.x > -1f && coll.contacts[0].normal.x < 1f && coll.contacts[0].normal.y < -0.35f)
        {
            coll.transform.SetParent(this.transform);
        }
    }

    void OnCollisionStay2D(Collision2D coll)
    {
        if(coll.gameObject.CompareTag("Player") && coll.contacts[0].normal.x > -1f && coll.contacts[0].normal.x < 1f && coll.contacts[0].normal.y < -0.35f)
        {
            isUp = true;
        }
    }

    void OnCollisionExit2D(Collision2D coll)
    {
        if(coll.gameObject.CompareTag("Player"))
        {
            isUp = false;
            coll.transform.parent = null;
        }
    }
}
