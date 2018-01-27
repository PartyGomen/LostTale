using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleHermitCrabManager : MonoBehaviour
{
    public bool[] check = new bool[9];

    CameraFollow camfollow;

    public GameObject bridge;
    public GameObject[] crabs = new GameObject[5];
    private Vector3[] crab_pos = new Vector3[5];

    [HideInInspector]
    public bool is_clear = false;

    private Player player;



	void Start ()
    {
        camfollow = Camera.main.GetComponent<CameraFollow>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();

        //소라게 위치 저장
        for(int i = 0; i < crabs.Length; i ++)
        {
            crab_pos[i] = crabs[i].transform.position;
        }
    }

    public void CheckEnd()
    {
        //클리어 조건
        if((check[0] && check[1] && check[2] && check[3] && check[4] && !is_clear) || (check[5] && check[6] && check[2] && check[7] && check[8] && !is_clear))
        {
			ClearHermitCrabPuzzle ();
		}
    }

	public void ClearHermitCrabPuzzle()
    {
		is_clear = true;
		camfollow.FadeCoroutine(false, 0f);
		camfollow.FadeCoroutine(true, 1f);
		camfollow.CheckPuzzleOrPlayer(false);
		bridge.SetActive(true);
        player.saveZoneidx = 1;
		// 퍼즐 획득 저장 기능 (Inventory.PuzzleGet[0] == false)
        if (Inventory.PuzzleGet[0] == true)
            GetComponent<PuzzleClear>().Clear();
    }

    public void Crab_Reset()
    {
        if (is_clear)
            return;

        for(int i = 0; i < crabs.Length; i++)
        {
            check[i] = false;
            crabs[i].transform.position = crab_pos[i];
        }
    }
}
