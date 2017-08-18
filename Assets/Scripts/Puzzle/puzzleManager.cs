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

    Player player;

	// Use this for initialization
	void Start ()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();	
	}
	
	// Update is called once per frame
	void Update () {
		if (Stay1IsOn == true && Stay2IsOn == true && Stay3IsOn == true && Stay4IsOn == true && Stay5IsOn == true) {
			Debug.Log ("Check");
			if (Puzzle [0].Equals("1") && Puzzle [1].Equals("2") && Puzzle [2].Equals("3") && Puzzle [3].Equals("4") && Puzzle [4].Equals("5")) {	
				StartCoroutine ("ChangeCamera");
				ShowPuzzle.puzzleClear = true;
				ShowPuzzle.puzzleOn = false;
				this.gameObject.SetActive (false);
                player.saveZoneidx = 1;
				//ShowPuzzle.puzzleClear = false;
			} else {
				Debug.Log ("Again");
			}
		}
	}



	IEnumerator ChangeCamera(){
		yield return new WaitForSeconds (0.5f);
		ShowPuzzle.puzzleClear = false;
		yield return null;
	}
}
