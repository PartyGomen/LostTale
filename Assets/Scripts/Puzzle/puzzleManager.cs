using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class puzzleManager : MonoBehaviour {
	const int MaxPuzzle = 5;

	public static bool Stay1IsOn = false;
	public static bool Stay2IsOn = false;
	public static bool Stay3IsOn = false;
	public static bool Stay4IsOn = false;
	public static bool Stay5IsOn = false;

	public static string[] Puzzle = new string[MaxPuzzle];

	public GameObject CrapPuzzleTouchArea;
	public GameObject PassWordPuzzleTouchArea;



    Player player;

	// Use this for initialization
	void Start ()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();	
	}

	// Update is called once per frame
	void Update () {
		if (Stay1IsOn == true && Stay2IsOn == true && Stay3IsOn == true && Stay4IsOn == true && Stay5IsOn == true) {
			StartCoroutine (CheckPuzzle());
		}
	}



	IEnumerator ChangeCamera(){
		yield return new WaitForSeconds (0.5f);
		ShowPuzzle.puzzleClear = false;
		yield return null;
	}


	IEnumerator CheckPuzzle(){
		Debug.Log ("Check");
		yield return new WaitForSeconds (2.0f);
		if (Puzzle [0].Equals ("1") && Puzzle [1].Equals ("2") && Puzzle [2].Equals ("3") && Puzzle [3].Equals ("4") && Puzzle [4].Equals ("5")) {	
			Inventory.GetPuzzle1 ();
			CrapPuzzleTouchArea.SetActive (false);
			PassWordPuzzleTouchArea.SetActive (true);
			StartCoroutine ("ChangeCamera");
			ShowPuzzle.puzzleClear = true;
			ShowPuzzle.puzzleOn = false;
			this.gameObject.SetActive (false);
			player.saveZoneidx = 1;
			this.gameObject.GetComponent<puzzleManager> ().enabled = false;
			//ShowPuzzle.puzzleClear = false;
		} else {
			Debug.Log ("Again");
		}
	}

}
