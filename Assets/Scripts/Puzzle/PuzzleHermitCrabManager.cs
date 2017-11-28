using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleHermitCrabManager : MonoBehaviour
{
    public bool[] check = new bool[5];

    Player player;

    CameraFollow camfollow;

    public GameObject bridge;

	// Use this for initialization
	void Start ()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        camfollow = Camera.main.GetComponent<CameraFollow>();
	}

    public void CheckEnd()
    {
        if(check[0] && check[1] && check[2] && check[3] && check[4])
        {
            camfollow.CheckPlayer();
            //Inventory.PuzzleGet[0] = true;
            //Inventory.GetPuzzle1();
            bridge.SetActive(true);
            GetComponent<PuzzleClear>().Clear();
        }
    }
}
