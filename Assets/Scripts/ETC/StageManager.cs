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

    private bool isOk; //이거 사용하지 않는 변수
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
