using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StageManager : MonoBehaviour {
	public GameObject Book;
	public GameObject Stagemanager;
	public Button Stage1;
	private int CurrentPage;
	private bool isOk;
	// Use this for initialization


	void Start () {
		CurrentPage = Book.GetComponent<Book> ().currentPage;
		Debug.Log (CurrentPage);
	}
	
	// Update is called once per frame


	public void CheckPage(){
		CurrentPage = Book.GetComponent<Book> ().currentPage;
		StartCoroutine (PageCheck());
	}

	IEnumerator PageCheck(){
		yield return new WaitForSeconds (0.3f);
		CurrentPage = Book.GetComponent<Book> ().currentPage;
		Debug.Log(CurrentPage);
		if (CurrentPage == 0) {
			Stage1.onClick.AddListener (Scene1_1);
		} else if (CurrentPage == 2) {
			Stage1.onClick.AddListener (Scene1_2);
		}
	}

	public void Scene1_1(){
		SceneManager.LoadScene ("Scene1-1");

	}

	public void Scene1_2(){
		SceneManager.LoadScene ("Scene1-2");
	}



}
