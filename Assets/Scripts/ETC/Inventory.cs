using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
	
public class Inventory : MonoBehaviour
{
	public GameObject PuzzleImageShow;
	public static bool[] PuzzleGet = new bool[9] { false, false, false, false, false, false, false, false, false };
	//{true, true, true, true, true, true, true, true, true}
	//{false, false, false, false, false, false, false, false, false}
	public static int[] PuzzleGetNumber = new int[9] {0, 0, 0, 0, 0, 0, 0, 0, 0};
	public GameObject[] piece = new GameObject[9];

	public Sprite[] InventoryPuzzleImage;
	public Sprite[] InventoryPuzzleDetail;
    public Image[] pieceImg = new Image[9];

    [TextArea]
    public string[] pieceStr = new string[9];
    public GameObject go;
	public GameObject InventoryShadow;
	public GameObject MobileControl;

	private int count = 0;

    private string save_puzzle_string = "";
    private bool is_checked;

    public void OffInven()
    {
        go.SetActive(false);
		PuzzleImageShow.SetActive (false);
		InventoryShadow.SetActive (false);
		MobileControl.SetActive (true);
    }

	public static void GetPuzzle1(){
		//Debug.Log ("Puzzle 1 Clear");

	}
	public static void GetPuzzle2(){
		//Debug.Log ("Puzzle 2 Clear");

	}

	public void DetailPuzzle(int number){
		PuzzleImageShow.SetActive (true);
		PuzzleImageShow.GetComponent<Image> ().sprite = InventoryPuzzleImage [PuzzleGetNumber [number-1]];
		this.GetComponent<ScrollRect> ().enabled = false;
	}

	public void CloseDeatilPuzzle(){
		PuzzleImageShow.SetActive (false);
		this.GetComponent<ScrollRect> ().enabled = true;
	}

	public void CheckInventory()
    {
        if (PlayerPrefs.HasKey("PuzzlePiece") && !is_checked)
        {
            is_checked = true;
            PuzzleLoad();
        }

        for (int i = 0; i < PuzzleGet.Length; i++)
        {
			if (PuzzleGet [i] == true)
            {
				piece [count].SetActive (true);
				piece [count].GetComponent<Image> ().sprite = InventoryPuzzleDetail [i];
				PuzzleGetNumber [count] = i;
				//piece [count].GetComponent<RectTransform> ().sizeDelta = new Vector2 (350, 300);
				count++;
			}
		}

		for(int j = count ; j < 9 ; j++)
        {
			piece [j].SetActive (false);
		}

		count = 0;
	}

    public void PuzzleSave()
    {
        save_puzzle_string = "";

        for (int i = 0; i < PuzzleGet.Length; i++)
        {
            save_puzzle_string = save_puzzle_string + PuzzleGet[i] + ",";
        }

        PlayerPrefs.SetString("PuzzlePiece", save_puzzle_string);
    }

    public void PuzzleLoad()
    {
        string[] puzzle_string = PlayerPrefs.GetString("PuzzlePiece").Split(',');

        for (int i = 0; i < PuzzleGet.Length; i++)
        {
            PuzzleGet[i] = bool.Parse(puzzle_string[i]);
        }
    }
}
