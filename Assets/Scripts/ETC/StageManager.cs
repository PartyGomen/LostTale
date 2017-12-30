using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StageManager : MonoBehaviour {
	public GameObject Book;
	public GameObject Stagemanager;
	public Button Stage1;
    public Button[] stages = new Button[3];
	private int CurrentPage;
	/*
	public static bool IsClear_Stage1 = false;
	public static bool IsClear_Stage2 = false;

	public static int IsFirstClear_Stage1 = 0;
	public static int IsFirstClear_Stage2 = 0;
	*/

	public static bool IsClear_Stage1 = true;
	public static bool IsClear_Stage2 = true;

	public static int IsFirstClear_Stage1 = 3;
	public static int IsFirstClear_Stage2 = 3;

	// Use this for initialization


	void Start () {
		CurrentPage = Book.GetComponent<Book> ().currentPage;
        Invoke("StageCheck", 0.3f);

        //Stage1.onClick.AddListener (Scene1_1);
        //Debug.Log (CurrentPage);
    }
	
	// Update is called once per frame


	public void CheckPage(){
		CurrentPage = Book.GetComponent<Book> ().currentPage;
		//StartCoroutine (PageCheck());
        Invoke("StageCheck", 0.3f);
	}

	IEnumerator PageCheck(){
		yield return new WaitForSeconds (0.3f);
		CurrentPage = Book.GetComponent<Book> ().currentPage;
		//Debug.Log(CurrentPage);
		if (CurrentPage == 0) {
			Stage1.onClick.AddListener (Scene1_1);
		} else if (CurrentPage == 2) {
			Stage1.onClick.AddListener (Scene1_2);
		}
	}

    void StageCheck()
    {
        CurrentPage = Book.GetComponent<Book>().currentPage;

        if(CurrentPage == 0)
        {
            stages[0].onClick.AddListener(delegate { LoadStage(7); });
            stages[1].onClick.AddListener(delegate { LoadStage(5); });
            stages[2].onClick.AddListener(delegate { LoadStage(6); });
        }
    }

	public void Scene1_1(){
		SceneManager.LoadScene ("Scene1-1");

	}

	public void Scene1_2(){
		SceneManager.LoadScene ("Scene1-2");
	}

    void LoadStage(int idx)
    {
        SceneManager.LoadScene(idx);
    }

}
