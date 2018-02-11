using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Exit : MonoBehaviour {
	public GameObject ExitPopup;
	public GameObject RightHotSpot;
	public GameObject LeftHotSpot;
	public GameObject RightPage;
	public GameObject LeftPage;

	public GameObject GalleryOpen;
	public GameObject Stage1;
	public GameObject Stage2;
	public GameObject Stage3;

	public GameObject ExitBackGround;

	public GameObject GalleryTuto;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}


	public void OnExitPopup(){
		ExitPopup.SetActive (true);
		GameObject.Find ("Book").GetComponent<Book> ().enabled = false;
		gameObject.GetComponent<Button> ().interactable = false;
		RightPage.SetActive (false);
		LeftPage.SetActive (false);
		RightHotSpot.SetActive (false);
		LeftHotSpot.SetActive (false);
		GalleryOpen.SetActive (false);
		Stage1.GetComponent<Button> ().interactable = false;
		Stage2.GetComponent<Button> ().interactable = false;
		Stage3.GetComponent<Button> ().interactable = false;
		ExitBackGround.SetActive (true);
		GalleryTuto.SetActive (false);
	}

	public void OFFExitPopup(){
		ExitPopup.SetActive (false);
		GameObject.Find ("Book").GetComponent<Book> ().enabled = true;
		gameObject.GetComponent<Button> ().interactable = true;
		RightPage.SetActive (true);
		LeftPage.SetActive (true);
		RightHotSpot.SetActive (true);
		LeftHotSpot.SetActive (true);
		GalleryOpen.SetActive (true);
		Stage1.GetComponent<Button> ().interactable = true;
		Stage2.GetComponent<Button> ().interactable = true;
		Stage3.GetComponent<Button> ().interactable = true;
		ExitBackGround.SetActive (false);
	}
	public void OnExitGame(){
		Debug.Log ("Finish");
		Application.Quit ();
	}
}
