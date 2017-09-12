using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaperPuzzle : MonoBehaviour
{
    SpriteRenderer spriterender;

    public Sprite[] sprites;

    RaycastHit2D hit;

    Vector3 pos;

    public int idx;

	void Start ()
    {
        spriterender = GetComponent<SpriteRenderer>();	
	}
	
	void Update ()
    {
        spriterender.sprite = sprites[idx];

        if(Input.GetMouseButtonDown(0))
        {
            pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            hit = Physics2D.Raycast(pos, Vector2.zero, Mathf.Infinity);

            if(hit)
            {
                if(hit.collider.gameObject == this.gameObject)
                {
                    idx++;

                    if(idx >= sprites.Length)
                    {
                        idx = 0;
                    }
                }
            }
        }
	}
}
