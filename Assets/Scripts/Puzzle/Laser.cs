using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    LineRenderer line;

    public GameObject[] mirror;
    public GameObject laser_obj;

    public bool[] reflected;
    private bool is_clear;

    private int linecount = 2;

	void Start ()
    {
        line = GetComponent<LineRenderer>();

        line.SetPosition(0, this.transform.position);
        line.SetPosition(1, mirror[0].transform.position);

        if (PlayerPrefs.HasKey(("PuzzlePiece")))
        {
            string[] puzzle_string = PlayerPrefs.GetString("PuzzlePiece").Split(',');

            is_clear = bool.Parse(puzzle_string[5]);

            if (is_clear)
                laser_obj.SetActive(false);
        }
    }

    void Update()
    {
        line.positionCount = linecount;

        if (reflected[0])
        {
            linecount = 3;
            line.SetPosition(2, mirror[1].transform.position);

            if (reflected[1])
            {
                linecount = 4;
                line.SetPosition(3, mirror[2].transform.position);

                if (reflected[3])
                {
                    linecount = 5;
                    line.SetPosition(4, mirror[4].transform.position);
                }

                else if (reflected[5])
                {
                    linecount = 5;
                    line.SetPosition(4, mirror[6].transform.position);
                }

                else
                {
                    linecount = 4;
                }
            }

            else if (reflected[2])
            {
                linecount = 4;
                line.SetPosition(3, mirror[3].transform.position);

                if (reflected[4])
                {
                    linecount = 5;
                    line.SetPosition(4, mirror[5].transform.position);
                }

                else if (reflected[6])
                {
                    linecount = 5;
                    line.SetPosition(4, mirror[7].transform.position);
                }

                else
                {
                    linecount = 4;
                }
            }

            else
            {
                linecount = 3;
            }
        }

        else
        {
            linecount = 2;
        }
	}

    public void CheckClear()
    {
        if(reflected[0] && reflected[1] && reflected[3] && !is_clear)
        {
            is_clear = true;

            laser_obj.SetActive(false);

            GetComponent<PuzzleClear>().Clear();

            CameraFollow cam_follow = Camera.main.GetComponent<CameraFollow>();

            cam_follow.FadeCoroutine(false, 0f);
            cam_follow.FadeCoroutine(true, 1f);
            cam_follow.CheckPuzzleOrPlayer(false);
        }
    }
}
