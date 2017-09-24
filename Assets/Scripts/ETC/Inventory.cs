using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
	public GameObject PuzzleImageShow;
    public static GameObject[] piece = new GameObject[9];

    public Image[] pieceImg = new Image[9];

    [TextArea]
    public string[] pieceStr = new string[9];

    public GameObject go;

    public void OffInven()
    {
        go.SetActive(false);
		PuzzleImageShow.SetActive (false);
    }

	public static void GetPuzzle1(){
		Debug.Log ("Puzzle 1 Clear");

	}
	public static void GetPuzzle2(){
		Debug.Log ("Puzzle 2 Clear");

	}

	public void DetailPuzzle(int number){
		if (number == 1) {
			PuzzleImageShow.SetActive (true);
		}
	}


}
