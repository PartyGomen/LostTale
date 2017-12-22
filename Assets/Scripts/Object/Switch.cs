using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : MonoBehaviour
{
    public GameObject door;
    public GameObject obstacle;

    BoxCollider2D box2d;
    EdgeCollider2D edge2d;

    Vector3 pos;

    bool isDown = false;
    bool isSwitch = false;

    public Sprite[] sprites = new Sprite[2];

    SpriteRenderer spriterenderer;

    private void Start()
    {
        box2d = GetComponent<BoxCollider2D>();
        edge2d = GetComponent<EdgeCollider2D>();
        spriterenderer = GetComponent<SpriteRenderer>();
    }

    void FixedUpdate ()
    {
        this.transform.position = new Vector3(71.0f, 9.6f, 0f);

       if(isDown)
        {
            door.transform.Translate(Vector2.down * 0.5f * Time.deltaTime);

            if(door.transform.position.y <= 10.2f)
            {
                obstacle.SetActive(false);
                isDown = false;
                box2d.enabled = true;
                edge2d.enabled = false;
                spriterenderer.sprite = sprites[0];
            }

            pos = door.transform.position;
            door.transform.position = new Vector3(pos.x, Mathf.Clamp(pos.y, 10.2f, 14.2f), pos.z);
        }
	}

    private void OnCollisionEnter2D(Collision2D coll)
    {
        if(!isDown)
        {
            if (coll.gameObject.CompareTag("Player") && coll.contacts[0].normal.x > -1f && coll.contacts[0].normal.x < 1f && coll.contacts[0].normal.y < -0.35f)
            {
                door.transform.Translate(Vector2.up * 4f);
                obstacle.SetActive(true);
                isSwitch = true;
                box2d.enabled = false;
                edge2d.enabled = true;
                spriterenderer.sprite = sprites[1];
            }
        }
    }

    private void OnCollisionExit2D(Collision2D coll)
    {
        if(isSwitch)
        {
            if (coll.gameObject.CompareTag("Player"))
            {
                isDown = true;
                this.transform.Translate(Vector2.up * 0.4f);
                isSwitch = false;
            }
        }
    }
}
