using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial : MonoBehaviour
{
	public enum TUTORIAL_TYPE
	{
		DRAG,
		TOUCH,
		BULB,
		PUZZLE_PIECE,
		NONE
	}

	public TUTORIAL_TYPE type = TUTORIAL_TYPE.NONE;

	private Player player;
	private Bridge bridge;
    private PuzzleShow puzzle_show;
    private Vector3 pos;
    public GameObject[] tutorial_image;

	public float distance;
    public float min_value;
	private float time;
    private float alpha;

    [HideInInspector]
    public bool is_clicked;
    private bool is_first;
    private bool alpha_on;

	// Use this for initialization
	void Start ()
	{
		player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        pos = this.transform.position;

		switch (type)
        {
            case TUTORIAL_TYPE.DRAG:
                {
                    bridge = GameObject.Find("Paddle_Joint").GetComponent<Bridge>();
                }
                break;

            case TUTORIAL_TYPE.TOUCH:
                {
                    puzzle_show = GameObject.Find("CrabpuzzleShow").GetComponent<PuzzleShow>();
                }
                break;

            case TUTORIAL_TYPE.BULB:
                {
                    puzzle_show = GameObject.Find("CrabpuzzleShow").GetComponent<PuzzleShow>();
                }
                break;
        }
    }

	// Update is called once per frame
	void Update ()
	{
        alpha = Mathf.Clamp(alpha, 0.0f, 1.0f);

        GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, alpha);
        for (int i = 0; i < tutorial_image.Length; i++)
        {
            tutorial_image[i].GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, alpha);
        }


        switch (type)
		{
            case TUTORIAL_TYPE.DRAG:
                {
                    if (bridge.is_clear == false)
                    {
                        distance = Vector3.Distance(player.gameObject.transform.position, bridge.gameObject.transform.position);

                        if (distance < 7)
                        {
                            if(!is_first)
                            {
                                time = 0.0f;
                                this.transform.position = pos;
                                this.transform.eulerAngles = new Vector3(0, 0, -30);
                                transform.localScale = new Vector3(1f, 1f, 1f);
                            }

                            is_first = true;

                            if(alpha_on)
                            {
                                alpha += Time.deltaTime;

                                if (alpha >= 1)
                                    alpha_on = false;
                            }

                            else
                            {
                                alpha -= Time.deltaTime;

                                if (alpha < 0.5)
                                    alpha_on = true;
                            }

                            time += Time.deltaTime;

                            if (time > 0.5f)
                            {
                                transform.transform.eulerAngles = new Vector3(0, 0, 0);
                                transform.localScale = new Vector3(0.8f, 0.8f, 0.8f);
                                transform.Translate(Vector2.left * Time.deltaTime * 2);

                                if (transform.position.x < min_value)
                                {
                                    time = 0.0f;
                                    this.transform.position = pos;
                                    this.transform.eulerAngles = new Vector3(0, 0, -30);
                                    transform.localScale = new Vector3(1f, 1f, 1f);
                                }
                            }
                        }

                        else
                        {
                            alpha -= Time.deltaTime;
                            is_first = false;
                        }
                    }

                    else
                    {
                        alpha -= Time.deltaTime;

                        if(alpha <= 0)
                        {
                            for (int i = 0; i < tutorial_image.Length; i++)
                            {
                                tutorial_image[i].SetActive(false);
                            }
                            this.gameObject.SetActive(false);
                        }
                    }
                }
                break;

            case TUTORIAL_TYPE.TOUCH:
                {
                    if (puzzle_show.is_clicked == false)
                    {
                        distance = Vector3.Distance(player.gameObject.transform.position, puzzle_show.gameObject.transform.position);

                        if (distance < 5f)
                        {
                            if (!is_first)
                            {
                                time = 0.0f;
                                this.transform.eulerAngles = new Vector3(0, 0, -30);
                                transform.localScale = new Vector3(1f, 1f, 1f);
                            }

                            is_first = true;

                            if (alpha_on)
                            {
                                alpha += Time.deltaTime;

                                if (alpha >= 1)
                                    alpha_on = false;
                            }

                            else
                            {
                                alpha -= Time.deltaTime;

                                if (alpha < 0.5)
                                    alpha_on = true;
                            }

                            time += Time.deltaTime;

                            if (time > 0.5f)
                            {
                                transform.transform.eulerAngles = new Vector3(0, 0, 0);
                                transform.localScale = new Vector3(0.8f, 0.8f, 0.8f);

                                if (time > 1f)
                                {
                                    time = 0.0f;
                                    this.transform.eulerAngles = new Vector3(0, 0, -30);
                                    transform.localScale = new Vector3(1f, 1f, 1f);
                                }
                            }
                        }

                        else
                        {
                            alpha -= Time.deltaTime;
                            is_first = false;
                        }
                    }
                    else
                    {
                        puzzle_show.is_clicked = true;
                        alpha -= Time.deltaTime;

                        if (alpha <= 0)
                        {
                            for (int i = 0; i < tutorial_image.Length; i++)
                            {
                                tutorial_image[i].SetActive(false);
                            }
                            this.gameObject.SetActive(false);
                        }
                    }
                }
                break;

            case TUTORIAL_TYPE.PUZZLE_PIECE:
                {

                }
                break;

            case TUTORIAL_TYPE.BULB:
                {
                    if (!is_clicked && puzzle_show.is_clicked)
                    {
                        if (alpha_on)
                        {
                            alpha += Time.deltaTime;

                            if (alpha >= 1)
                                alpha_on = false;
                        }

                        else
                        {
                            alpha -= Time.deltaTime;

                            if (alpha < 0.5)
                                alpha_on = true;
                        }

                        transform.Translate(Vector2.up * Time.deltaTime * 0.7f);

                        if (transform.position.y < min_value)
                        {
                            this.transform.position = new Vector3(-9.5f, -32.5f, 0);
                        }
                    }

                    else if(is_clicked)
                    {
                        alpha -= Time.deltaTime;
                        this.gameObject.SetActive(false);
                    }
                }
                break;
        }
    }
}