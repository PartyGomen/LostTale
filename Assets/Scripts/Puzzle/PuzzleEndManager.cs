using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleEndManager : MonoBehaviour {
	const int MaxPuzzle = 5;

	public static bool PuzzleOn1 = false;
	public static bool PuzzleOn2 = false;
	public static bool PuzzleOn3 = false;
	public static bool PuzzleOn4 = false;
	public static bool PuzzleOn5 = false;


	public static string[] PuzzleEnd = new string[MaxPuzzle];
	// Use this for initialization
	
	// Update is called once per frame
	void Update () {

		Debug.Log (PuzzleOn1);
		Debug.Log (PuzzleOn2);
		Debug.Log (PuzzleOn3);
		Debug.Log (PuzzleOn4);
		Debug.Log (PuzzleOn5);

		if(PuzzleOn1 == true && PuzzleOn2 == true && PuzzleOn3 == true && PuzzleOn4 == true && PuzzleOn5 == true){

			StartCoroutine (ClearEndPuzzle());
		}
			
	}






	IEnumerator ClearEndPuzzle(){
		yield return new WaitForSeconds (0.5f);
		if (PuzzleEnd[0] == "Puzzle1" && PuzzleEnd[1] == "Puzzle2" && PuzzleEnd[2] == "Puzzle3" && PuzzleEnd[3] == "Puzzle4" && PuzzleEnd[4] == "Puzzle5") {
			Debug.Log ("진앤딩");
		} else if (PuzzleEnd[0] == "Puzzle1" && PuzzleEnd[1] == "Puzzle2" &&  PuzzleEnd[2] == "Puzzle3" && PuzzleEnd[3] == "Puzzle6" && PuzzleEnd[4] == "Puzzle7") {
			Debug.Log ("해피앤딩");
		} else if (PuzzleEnd[0] == "Puzzle1" && PuzzleEnd[1] == "Puzzle2" &&  PuzzleEnd[2] == "Puzzle3" && PuzzleEnd[3] == "Puzzle4" && PuzzleEnd[4] == "Puzzle8") {
			Debug.Log ("새드앤딩");
		} else if (PuzzleEnd[0] == "Puzzle1" && PuzzleEnd[1] == "Puzzle2" &&  PuzzleEnd[2] == "Puzzle3" && PuzzleEnd[3] == "Puzzle4" && PuzzleEnd[4] == "Puzzle9") {
			Debug.Log ("특전앤딩");
		} else {	
			GameObject.Find ("Puzzle1").GetComponent<RectTransform> ().anchoredPosition = new Vector3 (500, -602, 0);
			GameObject.Find ("Puzzle2").GetComponent<RectTransform> ().anchoredPosition = new Vector3 (800, -602, 0);
			GameObject.Find ("Puzzle3").GetComponent<RectTransform> ().anchoredPosition = new Vector3 (1100, -602, 0);
			GameObject.Find ("Puzzle4").GetComponent<RectTransform> ().anchoredPosition = new Vector3 (-500, -602, 0);
			GameObject.Find ("Puzzle5").GetComponent<RectTransform> ().anchoredPosition = new Vector3 (344, -894, 0);
			GameObject.Find ("Puzzle6").GetComponent<RectTransform> ().anchoredPosition = new Vector3 (644, -894, 0);
			GameObject.Find ("Puzzle7").GetComponent<RectTransform> ().anchoredPosition = new Vector3 (944, -894, 0);
			GameObject.Find ("Puzzle8").GetComponent<RectTransform> ().anchoredPosition = new Vector3 (1244, -894, 0);
			GameObject.Find ("Puzzle9").GetComponent<RectTransform> ().anchoredPosition = new Vector3 (1544, -894, 0);
			Debug.Log ("응 아니야 힌트");
		}
	}
}
