using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PuzzleEndManager : MonoBehaviour {
	const int MaxPuzzle = 5;

	public GameObject HintPanel;
	public GameObject ClearBackGround;
	public GameObject EndingStory;

	private bool EndingCheck = false;
	public static bool PuzzleOn1 = false;
	public static bool PuzzleOn2 = false;
	public static bool PuzzleOn3 = false;
	public static bool PuzzleOn4 = false;
	public static bool PuzzleOn5 = false;


	public static int EndingStoryNumber = 0;

	private bool ShowHint = false;
	private bool ShowEnding = false;

	public static string[] PuzzleEnd = new string[MaxPuzzle];
	// Use this for initialization

	private float count;
	private float count1;

	// Update is called once per frame
	void Update () {
		if (PuzzleOn1 == true && PuzzleOn2 == true && PuzzleOn3 == true && PuzzleOn4 == true && PuzzleOn5 == true && EndingCheck == false) {
			StartCoroutine (ClearEndPuzzle ());
		} else {
			StopAllCoroutines ();
		}
	}
		
	IEnumerator ClearEndPuzzle(){
		yield return new WaitForSeconds (1.5f);
		if (PuzzleEnd[0] == "Puzzle1" && PuzzleEnd[1] == "Puzzle2" && PuzzleEnd[2] == "Puzzle3" && PuzzleEnd[3] == "Puzzle4" && PuzzleEnd[4] == "Puzzle5" && GalleryManager.TrueEnding == true) {
			StartCoroutine (ClearEffect());
		} else if (PuzzleEnd[0] == "Puzzle1" && PuzzleEnd[1] == "Puzzle2" &&  PuzzleEnd[2] == "Puzzle3" && PuzzleEnd[3] == "Puzzle6" && PuzzleEnd[4] == "Puzzle7" && GalleryManager.HappyEnding == true && GalleryManager.TrueEnding == false) {
			ShowHint = true;
			StartCoroutine (ClearEffect());
		} else if (PuzzleEnd[0] == "Puzzle1" && PuzzleEnd[1] == "Puzzle2" &&  PuzzleEnd[2] == "Puzzle3" && PuzzleEnd[3] == "Puzzle4" && PuzzleEnd[4] == "Puzzle8" && GalleryManager.SadEnding == true && GalleryManager.TrueEnding == false) {
			ShowHint = true;
			StartCoroutine (ClearEffect());
		} else if (PuzzleEnd[0] == "Puzzle1" && PuzzleEnd[1] == "Puzzle2" &&  PuzzleEnd[2] == "Puzzle3" && PuzzleEnd[3] == "Puzzle4" && PuzzleEnd[4] == "Puzzle9" && GalleryManager.ExceptEnding == true && GalleryManager.TrueEnding == false) {
			ShowHint = true;
			StartCoroutine (ClearEffect());
		} else if (PuzzleEnd[0] == "Puzzle1" && PuzzleEnd[1] == "Puzzle2" &&  PuzzleEnd[2] == "Puzzle3" && PuzzleEnd[3] == "Puzzle6" && PuzzleEnd[4] == "Puzzle7" && GalleryManager.HappyEnding == true && GalleryManager.TrueEnding == true) {
			StartCoroutine (ClearEffect());
		} else if (PuzzleEnd[0] == "Puzzle1" && PuzzleEnd[1] == "Puzzle2" &&  PuzzleEnd[2] == "Puzzle3" && PuzzleEnd[3] == "Puzzle4" && PuzzleEnd[4] == "Puzzle8" && GalleryManager.SadEnding == true && GalleryManager.TrueEnding == true) {
			StartCoroutine (ClearEffect());
		} else if (PuzzleEnd[0] == "Puzzle1" && PuzzleEnd[1] == "Puzzle2" &&  PuzzleEnd[2] == "Puzzle3" && PuzzleEnd[3] == "Puzzle4" && PuzzleEnd[4] == "Puzzle9" && GalleryManager.ExceptEnding == true && GalleryManager.TrueEnding == true) {
			StartCoroutine (ClearEffect());
		} else if (PuzzleEnd[0] == "Puzzle1" && PuzzleEnd[1] == "Puzzle2" && PuzzleEnd[2] == "Puzzle3" && PuzzleEnd[3] == "Puzzle4" && PuzzleEnd[4] == "Puzzle5" && GalleryManager.TrueEnding == false) {
			Debug.Log ("진앤딩");
			ShowEnding = true;
			EndingStoryNumber = 1;
			StartCoroutine (ClearEffect());
		} else if (PuzzleEnd[0] == "Puzzle1" && PuzzleEnd[1] == "Puzzle2" &&  PuzzleEnd[2] == "Puzzle3" && PuzzleEnd[3] == "Puzzle6" && PuzzleEnd[4] == "Puzzle7" && GalleryManager.HappyEnding == false) {
			Debug.Log ("해피앤딩");
			ShowEnding = true;
			EndingStoryNumber = 2;
			StartCoroutine (ClearEffect());
		} else if (PuzzleEnd[0] == "Puzzle1" && PuzzleEnd[1] == "Puzzle2" &&  PuzzleEnd[2] == "Puzzle3" && PuzzleEnd[3] == "Puzzle4" && PuzzleEnd[4] == "Puzzle8" && GalleryManager.SadEnding == false) {
			Debug.Log ("새드앤딩");
			ShowEnding = true;
			EndingStoryNumber = 3;
			StartCoroutine (ClearEffect());
		} else if (PuzzleEnd[0] == "Puzzle1" && PuzzleEnd[1] == "Puzzle2" &&  PuzzleEnd[2] == "Puzzle3" && PuzzleEnd[3] == "Puzzle4" && PuzzleEnd[4] == "Puzzle9" && GalleryManager.ExceptEnding == false) {
			Debug.Log ("특전앤딩");
			EndingStoryNumber = 4;
			ShowEnding = true;
			StartCoroutine (ClearEffect());
		} else {	
			StopAllCoroutines ();
			HintOn ();

		}
	}
		
	IEnumerator ClearEffect()
	{
		ClearBackGround.SetActive (true);
		while (count < 2) {  // 책 내용물  Fade Out 시킴 
			ClearBackGround.GetComponent<Image>().color = new Color(255, 255, 255, count);
			yield return new WaitForSeconds(0.001f);
			count += 0.002f;
		} 

		while (count1 < 256) {  // 책 내용물  Fade Out 시킴 
			ClearBackGround.GetComponent<Image>().color = new Color(255 - count1, 255 - count1, 255 - count1, 255);
			yield return new WaitForSeconds(0.1f);
			count1 += 1f;
			Debug.Log (count1);
		} 
		//StopAllCoroutines ();
		EndingCheck = true;
		if (ShowHint == true) {
			HintOn ();
			ShowHint = false;
		}else if(ShowEnding == true){
			EndingStoryOn ();
			ShowEnding = false;
		}
		RelocatePuzzle ();
		StopAllCoroutines ();
		Debug.Log ("finish");
	}
		
	public void RelocatePuzzle(){
		GameObject.Find ("Puzzle1").GetComponent<RectTransform> ().anchoredPosition = new Vector3 (500, -710, 0);
		GameObject.Find ("Puzzle2").GetComponent<RectTransform> ().anchoredPosition = new Vector3 (800, -734, 0);
		GameObject.Find ("Puzzle3").GetComponent<RectTransform> ().anchoredPosition = new Vector3 (1100, -695, 0);
		GameObject.Find ("Puzzle4").GetComponent<RectTransform> ().anchoredPosition = new Vector3 (-500, -692, 0);
		GameObject.Find ("Puzzle5").GetComponent<RectTransform> ().anchoredPosition = new Vector3 (344, -920, 0);
		GameObject.Find ("Puzzle6").GetComponent<RectTransform> ().anchoredPosition = new Vector3 (644, -935, 0);
		GameObject.Find ("Puzzle7").GetComponent<RectTransform> ().anchoredPosition = new Vector3 (944, -899, 0);
		GameObject.Find ("Puzzle8").GetComponent<RectTransform> ().anchoredPosition = new Vector3 (1244, -920, 0);
		GameObject.Find ("Puzzle9").GetComponent<RectTransform> ().anchoredPosition = new Vector3 (1544, -935, 0);
		count = 0;  // 기본 변수 초기화 
		count1 = 0;
		ClearBackGround.GetComponent<Image>().color = new Color(255, 255, 255, 0);
		ClearBackGround.SetActive (false);
		EndingCheck = false;
	}

		
	public void HintOn(){
		EndingCheck = true;
		Debug.Log ("HintOn");
		HintPanel.SetActive (true);
		this.gameObject.GetComponent<EndingMovePuzzle> ().enabled = false;

	}

	public void HintOff(){
		this.gameObject.GetComponent<EndingMovePuzzle> ().enabled = true;
		HintPanel.SetActive (false);
		RelocatePuzzle ();
	}

	public void EndingStoryOn(){
		EndingCheck = true;
		EndingStory.SetActive (true);
		this.gameObject.GetComponent<EndingMovePuzzle> ().enabled = false;
	}

	public void EndingStoryOff(){
		this.gameObject.GetComponent<EndingMovePuzzle> ().enabled = true;
		EndingStory.SetActive (true);
		RelocatePuzzle ();

	}
}
