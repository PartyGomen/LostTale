using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleHermitCrabManager : MonoBehaviour
{
    public bool[] check = new bool[5];

    CameraFollow camfollow;

    public GameObject bridge;
    public GameObject[] crabs = new GameObject[5];
    private Vector3[] crab_pos = new Vector3[5];

	// Use this for initialization
	void Start ()
    {
        camfollow = Camera.main.GetComponent<CameraFollow>();

        for(int i = 0; i < crabs.Length; i ++)
        {
            crab_pos[i] = crabs[i].transform.position;
        }
	}

    public void CheckEnd()
    {
        if(check[0] && check[1] && check[2] && check[3] && check[4])
        {
            camfollow.CheckPuzzleOrPlayer(false);
            //Inventory.PuzzleGet[0] = true;
            //Inventory.GetPuzzle1();
            bridge.SetActive(true);
            GetComponent<PuzzleClear>().Clear();
        }
    }

    public void Crab_Reset()
    {
        for(int i = 0; i < crabs.Length; i++)
        {
            check[i] = false;
            crabs[i].transform.position = crab_pos[i];
        }
    }
}
