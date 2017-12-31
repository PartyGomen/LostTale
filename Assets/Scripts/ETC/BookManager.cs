using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class BookManager : MonoBehaviour {

	private float timeControl = 0;
	private float timeControl2 = 0;
	private GameObject target;
	public Vector2 pos;




	public GameObject Stage1;
	public GameObject Stage2;
	public GameObject Stage3;

	public GameObject Gallery;

	public GameObject RightNext;
	public GameObject LeftNext;

	public GameObject ExitButton;
	public GameObject GalleryManager;

	public AudioSource BookSkip;
	public AudioSource BookGrid;

	public GameObject Null;



	public void FadeDisappearStart(){
		StartCoroutine (FadeDisappearContents());
	}
	public void FadeappearStart(){
		StopAllCoroutines ();
		StartCoroutine (FadeappearContents());
	}

	IEnumerator FadeDisappearContents()
	{
		Debug.Log ("Disappear");
		Stage1.GetComponent<Button> ().interactable = false; // 스테이지 버튼 비초기화
		Stage2.GetComponent<Button> ().interactable = false;
		Stage3.GetComponent<Button> ().interactable = false;
		timeControl = 2;
		while (timeControl > -1) {  // 책 내용물  Fade Out 시킴 
			Stage1.GetComponent<Image> ().color =  new Color(1, 1, 1, timeControl);
			Stage2.GetComponent<Image> ().color =  new Color(1, 1, 1, timeControl);
			Stage3.GetComponent<Image> ().color =  new Color(1, 1, 1, timeControl);

			yield return new WaitForSeconds(0.001f);
			timeControl -= 0.2f;
		} 
	//	timeControl = 2;
		//yield return new WaitForSeconds(0.03f);
	}

	IEnumerator FadeappearContents()
	{
		Debug.Log ("appear");
		timeControl2 = 0;
		while (timeControl2 < 2) {  // 책 내용물  Fade Out 시킴 
			Stage1.GetComponent<Image> ().color =  new Color(1, 1, 1, timeControl2);
			Stage2.GetComponent<Image> ().color =  new Color(1, 1, 1, timeControl2);
			Stage3.GetComponent<Image> ().color =  new Color(1, 1, 1, timeControl2);

			yield return new WaitForSeconds(0.001f);
			timeControl2 += 0.2f;
		} 
	//	timeControl2 = 0;
		Stage1.GetComponent<Button> ().interactable = true; // 스테이지 버튼 비초기화
		Stage2.GetComponent<Button> ().interactable = true;
		Stage3.GetComponent<Button> ().interactable = true;
	}

	public void	ShowGallery(){
		GalleryManager.SetActive (true);
		RightNext.SetActive (false); // 페이지 넘기는 이벤트 방지 
		LeftNext.SetActive (false);
		Gallery.SetActive (true); // 갤러리 이미지 보여줌
		Stage1.GetComponent<Button> ().interactable = false; // 스테이지 버튼 비초기화
		Stage2.GetComponent<Button> ().interactable = false;
		Stage3.GetComponent<Button> ().interactable = false;
		ExitButton.GetComponent<Button>().interactable = false; // 종료 버튼 비활성화
		GameObject.Find ("GalleryOpen").GetComponent<Image>().raycastTarget = false;
		GameObject.Find ("GalleryOpen").GetComponent<Button>().interactable = false;  // 책에 갤러리 보이는 버튼 비활성화
	}

	public void DisappearGallery(){
		GalleryManager.SetActive (false);
		Gallery.SetActive (false);
		RightNext.SetActive (true);
		LeftNext.SetActive (true);
		Stage1.GetComponent<Button> ().interactable = true; // 스테이지 버튼 비초기화
		Stage2.GetComponent<Button> ().interactable = true;
		Stage3.GetComponent<Button> ().interactable = true;
		ExitButton.GetComponent<Button>().interactable = true;
		GameObject.Find ("GalleryOpen").GetComponent<Image>().raycastTarget = true;
		GameObject.Find ("GalleryOpen").GetComponent<Button>().interactable = true;
	}

	public void PlayBookGridAudio(){
		BookGrid.Play ();
	}

	public void PlayBookSkipAudio(){
		BookSkip.Play ();
	}

}
