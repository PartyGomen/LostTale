﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaperManager : MonoBehaviour 
{
	public PaperPuzzle[] paper_puzzle = new PaperPuzzle[3];

    private bool is_clear;

    public GameObject clearImage;

    private Player player;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

    public void CheckClear()
    {
        if(paper_puzzle[0].idx == 3 && paper_puzzle[1].idx == 1 && paper_puzzle[2].idx == 2 && !is_clear)
        {
            is_clear = true;
            clearImage.SetActive(true);

            CameraFollow cam_follow = Camera.main.GetComponent<CameraFollow>();

            cam_follow.FadeCoroutine(false, 0f);
            cam_follow.FadeCoroutine(true, 1f);
            cam_follow.CheckPuzzleOrPlayer(false);

            player.saveZoneidx = 3;

			// 퍼즐 저장기능 해제  (Inventory.PuzzleGet[4] == false)
            if (Inventory.PuzzleGet[4] == true)
                GetComponent<PuzzleClear>().Clear();
        }
    }
}
