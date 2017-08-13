using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Water : MonoBehaviour
{
    float posY;
    public float maxY;
    float scale = 0.1f;
    float alpha = 1.0f;

    SpriteRenderer sprite;

	void Start ()
    {
        posY = this.transform.position.y;
        sprite = GetComponent<SpriteRenderer>();
	}
	
	void Update ()
    {
        this.transform.Translate(Vector2.up * 1 * Time.deltaTime);

        if(scale < 1f)
        {
            scale += Time.deltaTime * 0.5f;
        }

        if(alpha > 0f)
        {
            alpha -= Time.deltaTime * 0.5f;
        }

        sprite.color = new Color(1, 1, 1, alpha);
        //this.transform.localScale = new Vector3(scale, scale);

        if(this.transform.position.y > maxY)
        {
            scale = 0.1f;
            alpha = 1.0f;
            this.transform.position = new Vector3(this.transform.position.x, posY, this.transform.position.z);
        }
	}
}
