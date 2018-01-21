using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StageManager : MonoBehaviour {
	public GameObject Book;
	public GameObject Stagemanager;
	public GameObject[] stagesButton;
	public GameObject[] DisableButton;
    public Button[] stages = new Button[3];
	private int CurrentPage;

	/* 스테이지 못 깬 상태 
	public static bool IsClear_Stage1 = false;
	public static bool IsClear_Stage2 = false;

	public static int IsFirstClear_Stage1 = 0;
	public static int IsFirstClear_Stage2 = 0;
*/

	public static bool IsClear_Stage1 = true;
	public static bool IsClear_Stage2 = true;

	public static int IsFirstClear_Stage1 = 3;
	public static int IsFirstClear_Stage2 = 3;

	public static bool OpenChapter1 = true;
	public static bool OpenChapter2 = false;
	public static bool OpenChapter3 = false;
	public static bool OpenChapter4 = false;
	// Use this for initialization


	void Start () {
		CurrentPage = Book.GetComponent<Book> ().currentPage;
		stages[0].onClick.AddListener(delegate { LoadStage(7); });
		stages[1].onClick.AddListener(delegate { LoadStage(5); });
		stages[2].onClick.AddListener(delegate { LoadStage(6); });
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
		Debug.Log(CurrentPage);
		if (CurrentPage == 0) {
			stages[0].onClick.AddListener (Scene1_1);
		} else if (CurrentPage == 2) {
			stages[0].onClick.AddListener (Scene1_2);
		}
	}

    void StageCheck()
    {
        CurrentPage = Book.GetComponent<Book>().currentPage;
		Debug.Log(CurrentPage);
        if(CurrentPage == 0)
        {
            stages[0].onClick.AddListener(delegate { LoadStage(7); });
            stages[1].onClick.AddListener(delegate { LoadStage(5); });
            stages[2].onClick.AddListener(delegate { LoadStage(6); });
			stages [0].enabled = true;
			DisableButton [0].GetComponent<Image> ().color = new Color (1, 1, 1, 0);
			if (IsClear_Stage1 == true || IsFirstClear_Stage1 >= 3) {
				stages [1].enabled = true;
				DisableButton [1].GetComponent<Image> ().color = new Color (1, 1, 1, 0);
			}
			if(IsClear_Stage2 == true || IsFirstClear_Stage2 >= 3){
				stages [2].enabled = true;
				DisableButton[2].GetComponent<Image> ().color =  new Color(1, 1, 1, 0);
			}

			if (StageManager.IsClear_Stage1 == false && StageManager.IsFirstClear_Stage1 <= 2 && CurrentPage == 0) {
				DisableButton[1].GetComponent<Image> ().color =  new Color(1, 1, 1, 1);
			}
			if (StageManager.IsClear_Stage2 == false && StageManager.IsFirstClear_Stage2 <= 2 && CurrentPage == 0) {
				DisableButton[2].GetComponent<Image> ().color =  new Color(1, 1, 1, 1);
			}
        }
		else if(CurrentPage == 2 && OpenChapter2 == false)
		{
			Debug.Log ("Hi");
			DisableButton[0].GetComponent<Image> ().color = new Color (1, 1, 1, 1);
			DisableButton[1].GetComponent<Image> ().color = new Color (1, 1, 1, 1);
			DisableButton[2].GetComponent<Image> ().color = new Color (1, 1, 1, 1);
			stages [0].enabled = false;
			stages [1].enabled = false;
			stages [2].enabled = false;
		}else if(CurrentPage == 4 && OpenChapter2 == false)
		{
			DisableButton[0].GetComponent<Image> ().color = new Color (1, 1, 1, 1);
			DisableButton[1].GetComponent<Image> ().color = new Color (1, 1, 1, 1);
			DisableButton[2].GetComponent<Image> ().color = new Color (1, 1, 1, 1);
			stages [0].enabled = false;
			stages [1].enabled = false;
			stages [2].enabled = false;
		}
		else if(CurrentPage == 6 && OpenChapter2 == false)
		{
			DisableButton[0].GetComponent<Image> ().color = new Color (1, 1, 1, 1);
			DisableButton[1].GetComponent<Image> ().color = new Color (1, 1, 1, 1);
			DisableButton[2].GetComponent<Image> ().color = new Color (1, 1, 1, 1);
			stages [0].enabled = false;
			stages [1].enabled = false;
			stages [2].enabled = false;
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
