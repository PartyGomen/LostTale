using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GalleryManager : MonoBehaviour {

	public static bool HappyEnding = true;
	public static bool SadEnding = false;
	public static bool TrueEnding = false;
	public static bool SpecialEnding = false;

	public GameObject[] GalleryButton;
	public GameObject[] NowTitle;
	public Sprite[] TitleImage;
	public GameObject[] DisableImage;
	public GameObject[] NotImage;

	// Use this for initialization

	private float count = 1;

	void OnEnable(){
		if(EndingStoryManager.ClearEnding == 1){
			
		}else if(EndingStoryManager.ClearEnding == 2){
			
		}else if(EndingStoryManager.ClearEnding == 3){

		}else if(EndingStoryManager.ClearEnding == 4){

		}else if(EndingStoryManager.ClearEnding == 0){
			StartCoroutine (FadeInGallery());
			if(TrueEnding == true){
				CheckGallery (0);
			}else if(SadEnding == true){
				CheckGallery (1);
			}else if(HappyEnding == true){
				CheckGallery (2);
			}else if(SpecialEnding == true){
				CheckGallery (3);
			}

		}
	}
	public void CheckGallery(int number){
		GalleryButton [number].GetComponent<Button> ().interactable = true;
		NowTitle [number].GetComponent<Image> ().sprite = TitleImage [number];
		DisableImage [number].SetActive (false);
		NotImage[number].SetActive (false);
	}

	IEnumerator FadeInGallery()
	{
		while (count > 0){  // 책 내용물  Fade Out 시킴 
			DisableImage[0].GetComponent<Image> ().color =  new Color(1, 1, 1, count);
			NotImage[0].GetComponent<Image> ().color =  new Color(1, 1, 1, count);
			NowTitle[0].GetComponent<Image> ().color =  new Color(1, 1, 1, count);
			//Stage1.GetComponent<Image> ().color =  new Color(255, 255, 255, count);
			//Stage2.GetComponent<Image> ().color =  new Color(255, 255, 255, count);
			Debug.Log(count);
			yield return new WaitForSeconds(0.01f);
			count -= 0.02f;
		} 
		count = 0;
		StartCoroutine (FadeOutGallery());
	}

	IEnumerator FadeOutGallery()
	{
		NowTitle [0].GetComponent<Image> ().sprite = TitleImage [0];
		while (count < 1){  // 책 내용물  Fade Out 시킴 
			NowTitle[0].GetComponent<Image> ().color =  new Color(1, 1, 1, count);
			Debug.Log(count);
			yield return new WaitForSeconds(0.01f);
			count += 0.02f;
		} 
	}
}
