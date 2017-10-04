using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
	public GameObject PuzzleImageShow;
	public static bool[] PuzzleGet = new bool[9] {false, false, false, false, false, false, false, false, false};
	public static GameObject[] piece = new GameObject[9];

	public Sprite[] InventoryPuzzleImage;
    public Image[] pieceImg = new Image[9];

    [TextArea]
    public string[] pieceStr = new string[9];
    public GameObject go;
	public GameObject InventoryShadowUp;
	public GameObject InventoryShadowDown;
	public GameObject MobileControl;
	void Start(){


	}




    public void OffInven()
    {
        go.SetActive(false);
		PuzzleImageShow.SetActive (false);
		InventoryShadowUp.SetActive (false);
		InventoryShadowDown.SetActive (false);
		MobileControl.SetActive (true);
    }

	public static void GetPuzzle1(){
		//Debug.Log ("Puzzle 1 Clear");

	}
	public static void GetPuzzle2(){
		//Debug.Log ("Puzzle 2 Clear");

	}

	public void DetailPuzzle(int number){
		if (number == 1) {
			PuzzleImageShow.SetActive (true);
			PuzzleImageShow.GetComponent<Image> ().sprite = InventoryPuzzleImage [number-1];
			this.GetComponent<ScrollRect> ().enabled = false;
		}
	}
	public void CloseDeatilPuzzle(){
		PuzzleImageShow.SetActive (false);
		this.GetComponent<ScrollRect> ().enabled = true;
	}


}
