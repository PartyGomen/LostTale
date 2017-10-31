using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EndingStoryManager : MonoBehaviour {
	public string[] EndingText;
	public Sprite[] EndingImage;

	public GameObject Ending;
	public Text EndText;

	private float colorcount = 0;
	private int Textcount = 0;
	private int Finishcount = 1;
	private int NowPosition = 0;
	// Use this for initialization
	private bool IsTyping = true;
	private bool IsFadeIn = true;
	void Start () {
		StartCoroutine (FadeOutEnding());
		StartCoroutine (ShowText(NowPosition));
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown (0)) {
			if (IsTyping == true) {   //타이핑 중이라면 스킵
				SkipEnding(NowPosition);
			}else{
				if (Finishcount != 6 && Finishcount !=2) {
					StartCoroutine (FadeInEnding ());
					Debug.Log ("NextPage");
				}else if(Finishcount == 2){ // 2번째 퍼즐 텍스트 유지 
					IsTyping = true;
					NowPosition = 2;
					StartCoroutine (ShowText(NowPosition)); 
					Finishcount++;
				}else {
					SceneManager.LoadScene ("Title");
					Debug.Log ("Go to Title");
				}
			}
		}

	}

	public IEnumerator FadeOutEnding(){
		while(colorcount < 255){
		colorcount += 0.02f;
			Ending.GetComponent<Image>().color  = new Color(255, 255, 255, colorcount);
			EndText.GetComponent<Text>().color  = new Color(255, 255, 255, colorcount);
		yield return new WaitForSeconds (0.025f);
		}	
		colorcount = 255;
	}
		
	public IEnumerator FadeInEnding(){
		while(colorcount > 0){
			colorcount -= 100f;
			Ending.GetComponent<Image>().color  = new Color(255, 255, 255, colorcount);
			EndText.GetComponent<Text>().color  = new Color(255, 255, 255, colorcount);
			yield return new WaitForSeconds (0.025f);
		}	
		colorcount = 0;
		if (PuzzleEndManager.EndingStoryNumber == 1) {  // 진 엔딩
			if (Finishcount == 1) {
				NowPosition = 1;
				ControlEnding (NowPosition);
			} else if (Finishcount == 3) {
				NowPosition = 3;
				ControlEnding (NowPosition);
			} else if (Finishcount == 4) {
				NowPosition = 4;
				ControlEnding (NowPosition);
			} else if (Finishcount == 5) {
				NowPosition = 5;
				ControlEnding (NowPosition);
			}
		}else if(PuzzleEndManager.EndingStoryNumber == 2){ // 해피 엔딩
			if (Finishcount == 1) {
				NowPosition = 1;
				ControlEnding (NowPosition);
			} else if (Finishcount == 3) {
				NowPosition = 3;
				ControlEnding (NowPosition);
			} else if (Finishcount == 4) {
				NowPosition = 6;
				ControlEnding (NowPosition);
			} else if (Finishcount == 5) {
				NowPosition = 7;
				ControlEnding (NowPosition);
			}

		}else if(PuzzleEndManager.EndingStoryNumber == 3){ // 세드 엔딩
			if (Finishcount == 1) {
				NowPosition = 1;
				ControlEnding (NowPosition);
			} else if (Finishcount == 3) {
				NowPosition = 3;
				ControlEnding (NowPosition);
			} else if (Finishcount == 4) {
				NowPosition = 4;
				ControlEnding (NowPosition);
			} else if (Finishcount == 5) {
				NowPosition = 8;
				ControlEnding (NowPosition);
			}

		}else if(PuzzleEndManager.EndingStoryNumber == 4){ // 특전 엔딩
			if (Finishcount == 1) {
				NowPosition = 1;
				ControlEnding (NowPosition);
			} else if (Finishcount == 3) {
				NowPosition = 3;
				ControlEnding (NowPosition);
			} else if (Finishcount == 4) {
				NowPosition = 4;
				ControlEnding (NowPosition);
			} else if (Finishcount == 5) {
				NowPosition = 9;
				ControlEnding (NowPosition);
			}

		}
		Finishcount++;
	}

	public IEnumerator ShowText(int number){
		while (Textcount <= EndingText[number].Length) {
			EndText.text = EndingText [number].Substring (0, Textcount);
			Textcount++;
			yield return new WaitForSeconds (0.15f);
		}
		IsTyping = false;
		Textcount = 0;
	}

	public void SkipEnding(int number){
		colorcount = 255;
		Textcount = 0;
		StopAllCoroutines ();
		EndText.text = EndingText [number];
		Ending.GetComponent<Image>().color  = new Color(255, 255, 255, 255);
		EndText.GetComponent<Text>().color  = new Color(255, 255, 255, 255);
		IsTyping = false;
	}
		
	public void ControlEnding(int number){
		IsTyping = true;
		Ending.GetComponent<Image> ().sprite = EndingImage [number];
		StartCoroutine (FadeOutEnding ());
		StartCoroutine (ShowText(number));
	}
}
