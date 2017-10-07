using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PuzzleEndManager : MonoBehaviour {
	const int MaxPuzzle = 5;

	public GameObject HintPanel;

	private bool Hint = false;
	public static bool PuzzleOn1 = false;
	public static bool PuzzleOn2 = false;
	public static bool PuzzleOn3 = false;
	public static bool PuzzleOn4 = false;
	public static bool PuzzleOn5 = false;


	public static string[] PuzzleEnd = new string[MaxPuzzle];
	// Use this for initialization
	
	// Update is called once per frame
	void Update () {
		if(PuzzleOn1 == true && PuzzleOn2 == true && PuzzleOn3 == true && PuzzleOn4 == true && PuzzleOn5 == true){
			StartCoroutine (ClearEndPuzzle());
		}
	}






	IEnumerator ClearEndPuzzle(){
		yield return new WaitForSeconds (2.5f);
		Debug.Log ("코루틴중");
		if (PuzzleEnd[0] == "Puzzle1" && PuzzleEnd[1] == "Puzzle2" && PuzzleEnd[2] == "Puzzle3" && PuzzleEnd[3] == "Puzzle4" && PuzzleEnd[4] == "Puzzle5") {
			Debug.Log ("진앤딩");
		} else if (PuzzleEnd[0] == "Puzzle1" && PuzzleEnd[1] == "Puzzle2" &&  PuzzleEnd[2] == "Puzzle3" && PuzzleEnd[3] == "Puzzle6" && PuzzleEnd[4] == "Puzzle7") {
			Debug.Log ("해피앤딩");
		} else if (PuzzleEnd[0] == "Puzzle1" && PuzzleEnd[1] == "Puzzle2" &&  PuzzleEnd[2] == "Puzzle3" && PuzzleEnd[3] == "Puzzle4" && PuzzleEnd[4] == "Puzzle8") {
			Debug.Log ("새드앤딩");
		} else if (PuzzleEnd[0] == "Puzzle1" && PuzzleEnd[1] == "Puzzle2" &&  PuzzleEnd[2] == "Puzzle3" && PuzzleEnd[3] == "Puzzle4" && PuzzleEnd[4] == "Puzzle9") {
			Debug.Log ("특전앤딩");
		} else {	
			HintPanel.SetActive (true);
			this.gameObject.GetComponent<EndingMovePuzzle> ().enabled = false;
			//StopMovePuzzle ();
			if (Hint == true) {
				yield return new WaitForSeconds (0.5f);
				GameObject.Find ("Puzzle1").GetComponent<RectTransform> ().anchoredPosition = new Vector3 (500, -710, 0);
				GameObject.Find ("Puzzle2").GetComponent<RectTransform> ().anchoredPosition = new Vector3 (800, -734, 0);
				GameObject.Find ("Puzzle3").GetComponent<RectTransform> ().anchoredPosition = new Vector3 (1100, -695, 0);
				GameObject.Find ("Puzzle4").GetComponent<RectTransform> ().anchoredPosition = new Vector3 (-500, -692, 0);
				GameObject.Find ("Puzzle5").GetComponent<RectTransform> ().anchoredPosition = new Vector3 (344, -920, 0);
				GameObject.Find ("Puzzle6").GetComponent<RectTransform> ().anchoredPosition = new Vector3 (644, -935, 0);
				GameObject.Find ("Puzzle7").GetComponent<RectTransform> ().anchoredPosition = new Vector3 (944, -899, 0);
				GameObject.Find ("Puzzle8").GetComponent<RectTransform> ().anchoredPosition = new Vector3 (1244, -920, 0);
				GameObject.Find ("Puzzle9").GetComponent<RectTransform> ().anchoredPosition = new Vector3 (1544, -935, 0);
				Debug.Log ("응 아니야 힌트");
				Hint = false;
				this.gameObject.GetComponent<EndingMovePuzzle> ().enabled = true;
				HintPanel.SetActive (false);
				StopAllCoroutines ();
			}
		}
	}
		
	public void HintOn(){
		Hint = true;
	}

	public void ShowPanel(){
		HintPanel.SetActive (true);
	}
}
