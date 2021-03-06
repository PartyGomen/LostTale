﻿using System.Collections;
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
	Vector3 Camposition;

	public Text HintText;
	private bool KindHint = false;
	public float ShakeAmount;


	public AudioClip HappyEnding;
	public AudioClip AnotherEnding;


	public GameObject ClearSound;
	public GameObject FailSound;

	public GameObject BackButton;


	void Start(){
		GalleryManager.LoadData ();
		Camposition = GameObject.FindGameObjectWithTag ("MainCamera").GetComponent<Transform> ().position;
		Camposition.z = -10f;

	}
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
		} else if (PuzzleEnd[0] == "Puzzle1" && PuzzleEnd[1] == "Puzzle2" &&  PuzzleEnd[2] == "Puzzle3" && PuzzleEnd[3] == "Puzzle4" && PuzzleEnd[4] == "Puzzle9" && GalleryManager.SpecialEnding == true && GalleryManager.TrueEnding == false) {
			ShowHint = true;
			StartCoroutine (ClearEffect());
		} else if (PuzzleEnd[0] == "Puzzle1" && PuzzleEnd[1] == "Puzzle2" &&  PuzzleEnd[2] == "Puzzle3" && PuzzleEnd[3] == "Puzzle6" && PuzzleEnd[4] == "Puzzle7" && GalleryManager.HappyEnding == true && GalleryManager.TrueEnding == true) {
			StartCoroutine (ClearEffect());
		} else if (PuzzleEnd[0] == "Puzzle1" && PuzzleEnd[1] == "Puzzle2" &&  PuzzleEnd[2] == "Puzzle3" && PuzzleEnd[3] == "Puzzle4" && PuzzleEnd[4] == "Puzzle8" && GalleryManager.SadEnding == true && GalleryManager.TrueEnding == true) {
			StartCoroutine (ClearEffect());
		} else if (PuzzleEnd[0] == "Puzzle1" && PuzzleEnd[1] == "Puzzle2" &&  PuzzleEnd[2] == "Puzzle3" && PuzzleEnd[3] == "Puzzle4" && PuzzleEnd[4] == "Puzzle9" && GalleryManager.SpecialEnding == true && GalleryManager.TrueEnding == true) {
			StartCoroutine (ClearEffect());
		} else if (PuzzleEnd[0] == "Puzzle1" && PuzzleEnd[1] == "Puzzle2" && PuzzleEnd[2] == "Puzzle3" && PuzzleEnd[3] == "Puzzle4" && PuzzleEnd[4] == "Puzzle5" && GalleryManager.TrueEnding == false) { 
			if(GalleryManager.SadEnding == false && GalleryManager.HappyEnding == false && GalleryManager.SpecialEnding == false){
				TitleTest.IsFirstTuto = true;	
			}
			Debug.Log ("진앤딩");
			ShowEnding = true;
			EndingStoryNumber = 1;
			this.GetComponent<AudioSource> ().Stop ();
			this.GetComponent<AudioSource> ().clip = AnotherEnding;
			this.GetComponent<AudioSource> ().Play ();
			StartCoroutine (ClearEffect());
		} else if (PuzzleEnd[0] == "Puzzle1" && PuzzleEnd[1] == "Puzzle2" &&  PuzzleEnd[2] == "Puzzle3" && PuzzleEnd[3] == "Puzzle4" && PuzzleEnd[4] == "Puzzle8" && GalleryManager.SadEnding == false) {
			if(GalleryManager.TrueEnding == false && GalleryManager.HappyEnding == false && GalleryManager.SpecialEnding == false){
				TitleTest.IsFirstTuto = true;	
			}
			Debug.Log ("새드앤딩");
			ShowEnding = true;
			EndingStoryNumber = 2;
			this.GetComponent<AudioSource> ().Stop ();
			this.GetComponent<AudioSource> ().clip = AnotherEnding;
			this.GetComponent<AudioSource> ().Play ();
			StartCoroutine (ClearEffect());
		} else if (PuzzleEnd[0] == "Puzzle1" && PuzzleEnd[1] == "Puzzle2" &&  PuzzleEnd[2] == "Puzzle3" && PuzzleEnd[3] == "Puzzle6" && PuzzleEnd[4] == "Puzzle7" && GalleryManager.HappyEnding == false) {
			if(GalleryManager.TrueEnding == false && GalleryManager.SadEnding == false && GalleryManager.SpecialEnding == false){
				TitleTest.IsFirstTuto = true;	
			}
			Debug.Log ("해피앤딩");
			ShowEnding = true;
			EndingStoryNumber = 3;
			this.GetComponent<AudioSource> ().Stop ();
			this.GetComponent<AudioSource> ().clip = HappyEnding;
			this.GetComponent<AudioSource> ().Play ();
			StartCoroutine (ClearEffect());
		} else if (PuzzleEnd[0] == "Puzzle1" && PuzzleEnd[1] == "Puzzle2" &&  PuzzleEnd[2] == "Puzzle3" && PuzzleEnd[3] == "Puzzle4" && PuzzleEnd[4] == "Puzzle9" && GalleryManager.SpecialEnding == false) {
			if(GalleryManager.TrueEnding == false && GalleryManager.HappyEnding == false && GalleryManager.SadEnding == false){
				TitleTest.IsFirstTuto = true;	
			}
			Debug.Log ("특전앤딩");
			EndingStoryNumber = 4;
			ShowEnding = true;
			this.GetComponent<AudioSource> ().Stop ();
			this.GetComponent<AudioSource> ().clip = AnotherEnding;
			this.GetComponent<AudioSource> ().Play ();
			StartCoroutine (ClearEffect());
		} else {	
			StopAllCoroutines ();
			HintOn (PuzzleEnd);

		}
	}
		
	IEnumerator ClearEffect()
	{
		ClearSound.SetActive (true);
		ClearBackGround.SetActive (true);
		while (count < 2) {  
			ClearBackGround.GetComponent<Image>().color = new Color(255, 255, 255, count);
			yield return new WaitForSeconds(0.001f);
			count += 0.002f;
		} 

		while (count1 < 256) {  
			ClearBackGround.GetComponent<Image>().color = new Color(255 - count1, 255 - count1, 255 - count1, 255);
			yield return new WaitForSeconds(0.1f);
			count1 += 1f;
			Debug.Log (count1);
		} 
		yield return new WaitForSeconds(1.0f);
		ClearSound.SetActive (false);
		EndingCheck = true;

		if (ShowHint == true) {
			HintOn (PuzzleEnd);
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
		if (Inventory.PuzzleGet [0] == true) {
			GameObject.Find ("Puzzle1").GetComponent<RectTransform> ().anchoredPosition = new Vector3 (500, -710, 0);
		}  
		if (Inventory.PuzzleGet [1] == true) {
			GameObject.Find ("Puzzle2").GetComponent<RectTransform> ().anchoredPosition = new Vector3 (800, -716, 0);
		}
		if (Inventory.PuzzleGet [2] == true) {
			GameObject.Find ("Puzzle3").GetComponent<RectTransform> ().anchoredPosition = new Vector3 (1100, -704, 0);
		}
		if (Inventory.PuzzleGet [3] == true) {
			GameObject.Find ("Puzzle4").GetComponent<RectTransform> ().anchoredPosition = new Vector3 (1420, -704, 0);
		} 
		if (Inventory.PuzzleGet [4] == true) {
			GameObject.Find ("Puzzle5").GetComponent<RectTransform> ().anchoredPosition = new Vector3 (344, -920, 0);
		} 
		if (Inventory.PuzzleGet [5] == true) {
			GameObject.Find ("Puzzle6").GetComponent<RectTransform> ().anchoredPosition = new Vector3 (644, -922, 0);
		}
		if (Inventory.PuzzleGet [6] == true) {
			GameObject.Find ("Puzzle7").GetComponent<RectTransform> ().anchoredPosition = new Vector3 (944, -913, 0);
		}
		if (Inventory.PuzzleGet [7] == true) {
			GameObject.Find ("Puzzle8").GetComponent<RectTransform> ().anchoredPosition = new Vector3 (1244, -920, 0);
		}
		if (Inventory.PuzzleGet [8] == true) {
			GameObject.Find ("Puzzle9").GetComponent<RectTransform> ().anchoredPosition = new Vector3 (1544, -924, 0);
		}
		count = 0;  // 기본 변수 초기화 
		count1 = 0;
		ClearBackGround.GetComponent<Image>().color = new Color(255, 255, 255, 0);
		ClearBackGround.SetActive (false);
		EndingCheck = false;
	}

		
	public void HintOn(string[] Puzzle){
		EndingCheck = true;
		HintPanel.SetActive (true);
		FailSound.SetActive (true);
		BackButton.SetActive (false);
		for(int i = 0 ; i < 5 ; i ++){
			if (Puzzle [i] == "Puzzle1" || Puzzle [i] == "Puzzle2" || Puzzle [i] == "Puzzle3" || Puzzle [i] == "Puzzle4" || Puzzle [i] == "Puzzle5") {
				KindHint = true;
			} else {
				KindHint = false;
				break;
			}
		}
		if (KindHint == true) {
			HintText.text = "퍼즐 순서가 틀렸어...";
		} else {
			HintText.text = "퍼즐 조각이 틀렸어...";
		}
		KindHint = false;
		this.gameObject.GetComponent<EndingMovePuzzle> ().enabled = false;

	}

	public void HintOff(){
		BackButton.SetActive (true);
		FailSound.SetActive (false);
		RelocatePuzzle ();
		this.gameObject.GetComponent<EndingMovePuzzle> ().enabled = true;
		HintPanel.SetActive (false);
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
	/*IEnumerator ShakePuzzle(string []PuzzleEnd, float ShakeAmount){
		while (true) {
			for (int i = 0; i < MaxPuzzle; i++) {
				Vector2 ShakePosition = ShakeAmount * Random.insideUnitCircle;
				GameObject.Find (PuzzleEnd [i]).transform.position = new Vector3 (GameObject.Find (PuzzleEnd [i]).transform.position.x + ShakePosition.x, GameObject.Find (PuzzleEnd [i]).transform.position.y + ShakePosition.y, GameObject.Find (PuzzleEnd [i]).transform.position.z);
			}
		}
		yield return new WaitForSeconds(1.5f);
	}*/
}
  