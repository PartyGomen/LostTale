using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EndingStoryManager : MonoBehaviour {
	public string[] EndingText;
	public Sprite[] EndingImage;

	public Sprite[] TrueEndingletter;
	public Sprite[] HappyEndingletter;
	public Sprite[] SadEndingletter;
	public Sprite[] SpecialEndingletter;

	public GameObject Ending;
	public Text EndText;
	public GameObject EndingLetter;
	public GameObject EndingManager;
	public GameObject EndingImag;
	public GameObject EndingBackGround;

	private float colorcount = 0;
	private int Textcount = 0;
	private int Finishcount = 1;
	private int NowPosition = 0;
	private int Endinglettercount = 1;

	// Use this for initialization
	private bool IsTyping = true;
	private bool IsGallery = false;

	public static bool IsGetEnding = false;
	public static int ClearEnding = 0;

	public AudioClip HappyEnding;
	public AudioClip AnotehrEnding;

	public EndingHand EndingHand;
	private delegate IEnumerator handDelegate();
	private handDelegate handDelegateHandler;


	GalleryManager GalleryManager;

	void OnEnable () {
		EndingImag.SetActive (true);
		EndingBackGround.SetActive (true);
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
					StartCoroutine (ShowEndingletter (PuzzleEndManager.EndingStoryNumber));
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
		}else if(PuzzleEndManager.EndingStoryNumber == 2){ // 세드 엔딩
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
		}else if(PuzzleEndManager.EndingStoryNumber == 3){ // 해피 엔딩
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
		
		handDelegateHandler = EndingHand.Touch;
		StopCoroutine(handDelegateHandler());
		EndingHand.gameObject.SetActive(false); 

		while (Textcount <= EndingText[number].Length) {
			EndText.text = EndingText [number].Substring (0, Textcount);
			Textcount++;
			yield return new WaitForSeconds (0.15f);
		}
		IsTyping = false;
		Textcount = 0;

		EndingHand.gameObject.SetActive(true);
		StartCoroutine(handDelegateHandler());
	}

	public void SkipEnding(int number){
		colorcount = 255;
		Textcount = 0;
		StopAllCoroutines ();
		EndingHand.gameObject.SetActive(true);
		StartCoroutine(handDelegateHandler());
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

	public IEnumerator ShowEndingletter(int number){
			EndingLetter.SetActive(true);
		while (Endinglettercount < 12){
			if (PuzzleEndManager.EndingStoryNumber == 1) {
				EndingLetter.GetComponent<Image> ().sprite = TrueEndingletter [Endinglettercount];
				GalleryManager.TrueEnding = true;
				GalleryManager.SaveData ();
			} else if (PuzzleEndManager.EndingStoryNumber == 2) {
				EndingLetter.GetComponent<Image> ().sprite = SadEndingletter [Endinglettercount];
				GalleryManager.SadEnding = true;
				GalleryManager.SaveData ();
			}else if (PuzzleEndManager.EndingStoryNumber == 3) {
				EndingLetter.GetComponent<Image> ().sprite = HappyEndingletter [Endinglettercount];	
				GalleryManager.HappyEnding = true;
				GalleryManager.SaveData ();
			}else if (PuzzleEndManager.EndingStoryNumber == 4) {
				EndingLetter.GetComponent<Image> ().sprite = SpecialEndingletter [Endinglettercount];
				GalleryManager.SpecialEnding = true;
				GalleryManager.SaveData ();
				//GameObject.Find ("GalleryManager").GetComponent<GalleryManager> ().SaveData ();
			}
			yield return new WaitForSeconds (0.2f);
			Endinglettercount++;
		}	
		//	yield return new WaitForSeconds (3.0f);
		yield return new WaitForSeconds (2.0f);
		Debug.Log("Finish");

		IsGetEnding = true;
		if (IsGallery == false) {
			ClearEnding = number;
			SceneManager.LoadScene ("Title");
		} else {
			GameObject.Find ("Main Camera").GetComponent<AudioSource> ().Play ();
			GameObject.Find ("Gallery").GetComponent<AudioSource> ().Stop ();
			EndingManager.SetActive (false);
			EndingImag.SetActive (false);
			EndingBackGround.SetActive (false);
			resetGalleryEndingShow ();
		}
	}

	public void resetGalleryEndingShow(){
		Ending.GetComponent<Image> ().sprite = EndingImage [0];
		IsGallery = false;
		Textcount = 0;
		Finishcount = 1;
		Endinglettercount = 1;
		NowPosition = 0;
		EndingLetter.SetActive(false);
	}

	public void GalleryShowEnding(int number){
		// 사운드 제어 부분
		GameObject.Find ("Main Camera").GetComponent<AudioSource> ().Pause ();
		if (number == 3) {
			GameObject.Find ("Gallery").GetComponent<AudioSource> ().clip = HappyEnding;
			GameObject.Find ("Gallery").GetComponent<AudioSource> ().Play ();
		} else {
			GameObject.Find ("Gallery").GetComponent<AudioSource> ().clip = AnotehrEnding;
			GameObject.Find ("Gallery").GetComponent<AudioSource> ().Play ();
		}
		//
		IsGallery = true;
		EndingManager.SetActive (true);
		PuzzleEndManager.EndingStoryNumber = number;
	}

	public void SkipButton(){

	}
}
