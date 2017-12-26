using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bubble : MonoBehaviour
{
    private SpriteRenderer sprite;

    private Vector3 start_pos;

    private float speed;
    private float vector_x;
    private float alpha_value;
    private float divide_value;
    private float scale_value;
    public float vector_y;

	// Use this for initialization
	void Start ()
    {
        sprite = GetComponent<SpriteRenderer>();
        start_pos = this.transform.position;
        RandomValue();
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (alpha_value <= 0)
        {
            RandomValue();
            this.transform.position = new Vector3(start_pos.x, vector_y, 0);
        }

        else
        {
            this.transform.localScale = new Vector3(scale_value, scale_value, 0);
            scale_value += Time.deltaTime / divide_value;
            alpha_value -= Time.deltaTime / divide_value;
            transform.Translate(Vector2.up * Time.deltaTime * speed);
            sprite.color = new Color(1, 1, 1, alpha_value);
        }
    }

    void RandomValue()
    {
        scale_value = 0.1f;
        alpha_value = 1.0f; 
        //vector_x = Random.Range(start_pos.x - 0.2f, start_pos.x + 0.2f);
        speed = Random.Range(0.4f, 0.8f);
        divide_value = Random.Range(1.0f, 2.0f);
    }
}
