﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial : MonoBehaviour
{
    public enum TUTORIAL_TYPE
    {
        PADDLE,
        TOUCH,
        BULB,
        PUZZLE_PIECE,
        NONE
    }

    public enum IMAGE_TYPE
    {
        HAND,
        SMALL_HAND,
        DOT,
        ARROW_LEFT,
        NONE
    }

    public Sprite[] image_sprite;

    public TUTORIAL_TYPE type = TUTORIAL_TYPE.NONE;

    private Player player;
    public float distance;

	// Use this for initialization
	void Start ()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        switch (type)
        {
            case TUTORIAL_TYPE.PADDLE:
                {
                    distance = Vector3.Distance(player.gameObject.transform.position, this.gameObject.transform.position);

                    if(distance < 5)
                    {
                        GetComponent<SpriteRenderer>().sprite = image_sprite[(int)IMAGE_TYPE.SMALL_HAND];
                        transform.Translate(Vector2.left * Time.deltaTime * 2);

                        if(transform.position.x < -2f)
                        {
                            this.transform.position = new Vector3(0.6f, 4.5f, 0);
                        }
                    }

                    else
                    {
                        GetComponent<SpriteRenderer>().sprite = image_sprite[(int)IMAGE_TYPE.NONE];
                    }
                }
                break;

            case TUTORIAL_TYPE.TOUCH:
                {

                }
                break;

            case TUTORIAL_TYPE.PUZZLE_PIECE:
                {

                }
                break;

            case TUTORIAL_TYPE.BULB:
                {

                }
                break;
        }
	}
}
