using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GhostGround : MonoBehaviour {

    public bool isFirst = false;

    public GameObject nextGround;

    SpriteRenderer sprite;

    //[HideInInspector]
    public float t;

	// Use this for initialization
	void Start ()
    {
        sprite = GetComponent<SpriteRenderer>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (!isFirst)
        {
            t -= Time.deltaTime;
            sprite.color = new Color(1, 1, 1, t);

            if (t <= 0.0f)
            {
                this.gameObject.SetActive(false);
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D coll)
    {
        if(nextGround != null && coll.gameObject.CompareTag("Player") && coll.contacts[0].normal.x > -1f && coll.contacts[0].normal.x < 1f && coll.contacts[0].normal.y < -0.35f)
        {
            nextGround.SetActive(true);
            nextGround.GetComponent<GhostGround>().t = 1.5f;
        }
    }
}
