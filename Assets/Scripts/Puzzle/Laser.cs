﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Laser : MonoBehaviour
{
    LineRenderer line;

    public GameObject[] mirror;
    public GameObject laser_obj;
    public GameObject deathMark;
    public Image[] clearImage = new Image[2];

    public bool[] reflected;
    private bool is_clear;

    private Player player;

	void Start ()
    {
        line = GetComponent<LineRenderer>();

        line.SetPosition(0, this.transform.position);
        line.SetPosition(1, mirror[0].transform.position);

        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

    void Update()
    {
        if (reflected[0])
        {
            line.positionCount = 3;
            line.SetPosition(2, mirror[1].transform.position);

            if (reflected[1])
            {
                line.positionCount = 4;
                line.SetPosition(3, mirror[2].transform.position);

                if (reflected[3])
                {
                    line.positionCount = 5;
                    line.SetPosition(4, mirror[4].transform.position);
                }

                else if (reflected[5])
                {
                    line.positionCount = 5;
                    line.SetPosition(4, mirror[6].transform.position);
                }

                else
                {
                    line.positionCount = 4;
                }
            }

            else if (reflected[2])
            {
                line.positionCount = 4;
                line.SetPosition(3, mirror[3].transform.position);

                if (reflected[4])
                {
                    line.positionCount = 5;
                    line.SetPosition(4, mirror[5].transform.position);
                }

                else if (reflected[6])
                {
                    line.positionCount = 5;
                    line.SetPosition(4, mirror[7].transform.position);
                }

                else
                {
                    line.positionCount = 4;
                }
            }

            else
            {
                line.positionCount = 3;
            }
        }

        else if (reflected[7])
        {
            line.positionCount = 3;
            line.SetPosition(2, mirror[8].transform.position);
        }

        else
        {
            line.positionCount = 2;
        }
	}

    public void CheckClear()
    {
        if(reflected[0] && reflected[1] && reflected[3] && !is_clear)
        {
            is_clear = true;
            StartCoroutine(ClearFade());

            laser_obj.SetActive(false);
            deathMark.SetActive(false);

            player.saveZoneidx = 1;

            CameraFollow cam_follow = Camera.main.GetComponent<CameraFollow>();

            cam_follow.FadeCoroutine(false, 1f);
            cam_follow.FadeCoroutine(true, 2f);
            cam_follow.CheckPuzzleOrPlayer(false);

			// 퍼즐 저장기능 해제  (Inventory.PuzzleGet[5] == false)
			if (Inventory.PuzzleGet[5] == false)
                GetComponent<PuzzleClear>().Clear();
        }
    }

    IEnumerator ClearFade()
    {
        float t = 0.0f;

        clearImage[0].gameObject.SetActive(true);
        clearImage[1].gameObject.SetActive(true);

        while (t < 1)
        {
            t += Time.deltaTime;

            clearImage[0].color = new Color(1, 1, 1, t);
            clearImage[1].color = new Color(1, 1, 1, t);

            yield return null;
        }
    }
}
