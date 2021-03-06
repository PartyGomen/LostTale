﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class GalleryManager : MonoBehaviour {

	public static bool HappyEnding;
	public static bool SadEnding ;
	public static bool TrueEnding ;
	public static bool SpecialEnding ;

	public GameObject[] GalleryButton;
	public GameObject[] NowTitle;
	public GameObject[] DisableImage;
	public GameObject[] NotImage;

	// Use this for initialization

	private float count = 1;


	[Serializable]
	public class PlayerData{
		public bool HappyEnding;
		public bool SadEnding;
		public bool TrueEnding;
		public bool SpecialEnding;
	}

	void OnEnable(){
		if(EndingStoryManager.ClearEnding == 1){
			if(SadEnding == true){
				CheckGallery (1);
			}
			if(HappyEnding == true){
				CheckGallery (2);
			}
			if(SpecialEnding == true){
				CheckGallery (3);
			}
			GameObject.Find ("BookManager").GetComponent<BookManager>().ShowGallery();
			StartCoroutine (FadeInGallery(1));
		}else if(EndingStoryManager.ClearEnding == 2){
			if(TrueEnding == true){
				CheckGallery (0);
			} 
			if(HappyEnding == true){
				CheckGallery (2);
			} 
			if(SpecialEnding == true){
				CheckGallery (3);
			}
			GameObject.Find ("BookManager").GetComponent<BookManager>().ShowGallery();
			StartCoroutine (FadeInGallery(2));
		}else if(EndingStoryManager.ClearEnding == 3){
			if (TrueEnding == true) {
				CheckGallery (0);
			} 
			if (SadEnding == true) {
				CheckGallery (1);
			} 
			if(SpecialEnding == true){
				CheckGallery (3);
			}
			GameObject.Find ("BookManager").GetComponent<BookManager>().ShowGallery();
			StartCoroutine (FadeInGallery(3));
		}else if(EndingStoryManager.ClearEnding == 4){
			if(TrueEnding == true){
				CheckGallery (0);
			} 
			if(SadEnding == true){
				CheckGallery (1);
			} 
			if(HappyEnding == true){
				CheckGallery (2);
			}
			GameObject.Find ("BookManager").GetComponent<BookManager>().ShowGallery();
			StartCoroutine (FadeInGallery(4));
		}else { 
			if(TrueEnding == true){
				CheckGallery (0);
			} 
			if(SadEnding == true){
				CheckGallery (1);
			} 
			if(HappyEnding == true){
				CheckGallery (2);
			} 
			if(SpecialEnding == true){
				CheckGallery (3);
			}
		}
	}
	public void CheckGallery(int number){
		GalleryButton [number].GetComponent<Button> ().interactable = true;
		NowTitle [number].SetActive (true);
		DisableImage [number].SetActive (false);
		NotImage[number].SetActive (false);
	}
		

	IEnumerator FadeInGallery(int number)
	{
		while (count > 0){  // 책 내용물  Fade Out 시킴 
			DisableImage[number-1].GetComponent<Image> ().color =  new Color(1, 1, 1, count);
			NotImage[number-1].GetComponent<Image> ().color =  new Color(1, 1, 1, count);
			NowTitle[number-1].GetComponent<Image> ().color =  new Color(1, 1, 1, count);
			yield return new WaitForSeconds(0.01f);
			count -= 0.02f;
		} 
		count = 0;
		StartCoroutine (FadeOutGallery(number));
	}

	IEnumerator FadeOutGallery(int number)
	{
		NowTitle [number-1].SetActive (true);
		while (count < 1){  // 책 내용물  Fade Out 시킴 
			NowTitle[number-1].GetComponent<Image> ().color =  new Color(1, 1, 1, count);
			yield return new WaitForSeconds(0.01f);
			count += 0.02f;
		} 
		GalleryButton [number-1].GetComponent<Button> ().interactable = true;
		EndingStoryManager.ClearEnding = 0;
	}

	public static void SaveData(){
		Debug.Log ("Save");
		BinaryFormatter bf = new BinaryFormatter ();
		FileStream file = File.Create (Application.persistentDataPath + "/playerInfo.dat");

		PlayerData data = new PlayerData ();

		data.HappyEnding = HappyEnding;
		data.SadEnding = SadEnding;
		data.TrueEnding = TrueEnding;
		data.SpecialEnding = SpecialEnding;

		bf.Serialize (file, data);
		file.Close ();
	}


	public static void LoadData(){
		Debug.Log ("Load");
		BinaryFormatter bf = new BinaryFormatter ();
		FileStream file = File.Open (Application.persistentDataPath + "/playerInfo.dat", FileMode.Open);

		if (file != null && file.Length > 0) {

			PlayerData data = (PlayerData)bf.Deserialize (file);

			HappyEnding = data.HappyEnding;
			SadEnding = data.SadEnding;
			TrueEnding = data.TrueEnding;
			SpecialEnding = data.SpecialEnding;
		}
		file.Close ();
	}
}
