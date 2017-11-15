using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GalleryManager : MonoBehaviour {

	public static bool HappyEnding = true;
	public static bool SadEnding = false;
	public static bool TrueEnding = false;
	public static bool SpecialEnding = false;

	public GameObject[] NowTitle;
	public Sprite[] TitleImage;
	public GameObject[] DisableImage;
	public GameObject[] NotImage;
	// Use this for initialization

	void Start(){
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
	
	// Update is called once per frame
	void Update () {
		
	}

	public void CheckGallery(int number){
		NowTitle [number].GetComponent<Image> ().sprite = TitleImage [3];
		DisableImage [number].SetActive (false);
		NotImage[number].SetActive (false);
	}
}
