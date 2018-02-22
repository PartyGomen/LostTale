using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TitleTest : MonoBehaviour
{
    public GameObject BackGround;
	public GameObject BlackBackGround;
	public GameObject BackGroundText;
	public GameObject ExitButton;

	public GameObject Book;
	public GameObject RightPage;
	public GameObject LeftPage;
	public GameObject RightHotSpot;
	public GameObject LeftHotSpot;


	public GameObject Stage1;
	public GameObject Stage2;
	public GameObject Stage3;

	public GameObject Stage2Disable;
	public GameObject Stage3Disable;

	public GameObject Gallery;
	public GameObject GalleryMg;

	public GameObject GalleryTuto;
	public GameObject GalleryOpen;
//	private bool TouchBan = false;
//	private bool AppearBook = false;
//	public Sprite BackGroundSprite;

	public static bool IsFirstTuto = false;

    float xScale = 0;
    //float yScale = 0;
  //  float a = 1;

    //bool addAlpha = false;
	void OnEnable(){
		
	}
    private void Start()
    {
		ExitButton.SetActive (true);
		BlackBackGround.SetActive (true);
		StartCoroutine(FadeOutBackGround());
		//SceneManager.LoadScene(0);
	//	Button[] btns = BackGround.GetComponentsInChildren<Button>();
     //   btns[0].onClick.AddListener(() => PlayScene());
    }

    void Update ()
	{
		
	}

    IEnumerator FadeOutBackGround()
    {
		while(xScale < 2)
		{
			BackGround.GetComponent<Image> ().color =  new Color(1, 1, 1, xScale);
			ExitButton.GetComponent<Image> ().color =  new Color(1, 1, 1, xScale);
			yield return new WaitForSeconds(0.001f);
			xScale += 0.03f;
        }
		xScale = 0;
		StartCoroutine(FadeOutContents());
    }

	IEnumerator FadeOutContents()
	{
		while (xScale < 2) {  // 책 내용물  Fade Out 시킴 
			RightPage.GetComponent<Image> ().color =  new Color(1, 1, 1, xScale);
			LeftPage.GetComponent<Image> ().color =  new Color(1, 1, 1, xScale);
			yield return new WaitForSeconds(0.001f);
			xScale += 0.05f;
		} 
		xScale = 0;
		StartCoroutine(FadeOutBookMark());
	}

	IEnumerator FadeOutBookMark()
	{
		while (xScale < 2) {  // 책 내용물  Fade Out 시킴 
			Stage1.GetComponent<Image> ().color =  new Color(1, 1, 1, xScale);
			Stage2.GetComponent<Image> ().color =  new Color(1, 1, 1, xScale);
			Stage3.GetComponent<Image> ().color =  new Color(1, 1, 1, xScale);
			if(StageManager.IsClear_Stage1 == false || StageManager.IsFirstClear_Stage1 <= 2){
				Stage2Disable.GetComponent<Image> ().color =  new Color(1, 1, 1, xScale);
			}
			if(StageManager.IsClear_Stage2 == false || StageManager.IsFirstClear_Stage2 <= 2){
				Stage3Disable.GetComponent<Image> ().color =  new Color(1, 1, 1, xScale);
			}
			yield return new WaitForSeconds(0.001f);
			xScale += 0.03f;
		} 
		ExitButton.GetComponent<Button> ().interactable = true;
		Book.GetComponent<Book> ().enabled = true;  // Swipe 활성
		RightHotSpot.SetActive(true);
		LeftHotSpot.SetActive (true);
		if (GalleryManager.HappyEnding == false && GalleryManager.SadEnding == false && GalleryManager.SpecialEnding == false && GalleryManager.TrueEnding == false) {
			GalleryOpen.GetComponent<Button> ().interactable = false;
		} else {
			GameObject.Find ("GalleryOpen").GetComponent<Button> ().interactable = true;
		}

		// 스테이지 해금 이미지 컨트롤 
		Stage1.GetComponent<Button>().interactable = true;
		if(StageManager.IsClear_Stage1 == true){
			Stage2.GetComponent<Button>().interactable = true;
		}
		if(StageManager.IsClear_Stage2 == true){
			Stage3.GetComponent<Button>().interactable = true;
		}

		if(StageManager.IsFirstClear_Stage1 == 2 || StageManager.IsFirstClear_Stage2 ==2){
			StartCoroutine (FadeInStageDisable());
		}


		// 갤러리 튜토리얼 기능
		CheckGalleryTuto ();	
		Debug.Log (IsFirstTuto);
		// 갤러리 해금기능 
		if(EndingStoryManager.IsGetEnding == true && IsFirstTuto == false ){
			Gallery.SetActive (true);
			GalleryMg.SetActive (true);
			EndingStoryManager.IsGetEnding = false;
		}
		gameObject.GetComponent<TitleTest> ().enabled = false;
	}
		
	IEnumerator FadeInStageDisable()
	{
		while (xScale > 0) {  
			if(StageManager.IsClear_Stage1 == true && StageManager.IsFirstClear_Stage1 == 2){
				Stage2Disable.GetComponent<Image> ().color =  new Color(1, 1, 1, xScale);
			}
			if(StageManager.IsClear_Stage2 == true && StageManager.IsFirstClear_Stage2 == 2){
				Stage3Disable.GetComponent<Image> ().color =  new Color(1, 1, 1, xScale);
			}
			yield return new WaitForSeconds(0.001f);
			xScale -= 0.05f;
		} 
		if (StageManager.IsClear_Stage1 == true && StageManager.IsFirstClear_Stage1 == 2) {
			StageManager.IsFirstClear_Stage1 = 3;
		}
		if(StageManager.IsClear_Stage2 == true && StageManager.IsFirstClear_Stage2 == 2){
			StageManager.IsFirstClear_Stage2 = 3;
		}
			xScale = 0.0f;

	}


    void PlayScene()
    {
        SceneManager.LoadScene(0);
    }

	public void CheckGalleryTuto(){

	/*	if (GalleryManager.HappyEnding == true && GalleryManager.SadEnding == false && GalleryManager.SpecialEnding == false && GalleryManager.TrueEnding == false && IsFirstTuto == true) {
			//IsFirstTuto = false;
			GalleryTuto.SetActive (true);
			GalleryOpen.SetActive (false);
			Debug.Log ("1");
		}else if(GalleryManager.HappyEnding == false && GalleryManager.SadEnding == true && GalleryManager.SpecialEnding == false && GalleryManager.TrueEnding == false && IsFirstTuto == true){
			//IsFirstTuto = false;
			GalleryTuto.SetActive (true);
			GalleryOpen.SetActive (false);
			Debug.Log ("2");
		}else if(GalleryManager.HappyEnding == false && GalleryManager.SadEnding == false && GalleryManager.SpecialEnding == true && GalleryManager.TrueEnding == false && IsFirstTuto == true){
		//	IsFirstTuto = false;
			GalleryTuto.SetActive (true);
			GalleryOpen.SetActive (false);
			Debug.Log ("3");
		}else if(GalleryManager.HappyEnding == false && GalleryManager.SadEnding == false && GalleryManager.SpecialEnding == false && GalleryManager.TrueEnding == true && IsFirstTuto == true){
		//	IsFirstTuto = false;
			GalleryTuto.SetActive (true);
			GalleryOpen.SetActive (false);
			Debug.Log ("4");
		}*/
		if(IsFirstTuto == true){
			//	IsFirstTuto = false;
			GalleryTuto.SetActive (true);
			GalleryOpen.SetActive (false);
		}

	}

	public void StartGalleryTuto(){
		GalleryTuto.SetActive (false);
		GalleryOpen.SetActive (true);
		Gallery.SetActive (true);
		GalleryMg.SetActive (true);
		EndingStoryManager.IsGetEnding = false;
		IsFirstTuto = false;
	}
}
