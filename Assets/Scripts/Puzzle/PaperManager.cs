using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PaperManager : MonoBehaviour 
{
	public PaperPuzzle[] paper_puzzle = new PaperPuzzle[3];

    private bool is_clear;

    public Image[] clearImage = new Image[2];

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
            StartCoroutine(ClearFade());

            CameraFollow cam_follow = Camera.main.GetComponent<CameraFollow>();

            cam_follow.FadeCoroutine(false, 1f);
            cam_follow.FadeCoroutine(true, 2f);
            cam_follow.CheckPuzzleOrPlayer(false);

            player.saveZoneidx = 3;

			// 퍼즐 저장기능 해제  (Inventory.PuzzleGet[4] == false)
			if (Inventory.PuzzleGet[4] == false)
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
