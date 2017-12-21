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

	public GameObject Gallery;
	public GameObject GalleryMg;

	public GameObject GalleryTuto;
	public GameObject GalleryOpen;
//	private bool TouchBan = false;
//	private bool AppearBook = false;
//	public Sprite BackGroundSprite;

	private bool IsFirstTuto = true;

    float xScale = 0;
    //float yScale = 0;
  //  float a = 1;

    //bool addAlpha = false;

    private void Start()
    {
		ExitButton.SetActive (true);
		BlackBackGround.SetActive (true);
		StartCoroutine(GrowPanel());
		//SceneManager.LoadScene(0);
	//	Button[] btns = BackGround.GetComponentsInChildren<Button>();
     //   btns[0].onClick.AddListener(() => PlayScene());
    }

    void Update ()
	{
		
	}

    IEnumerator GrowPanel()
    {
//		TouchBan = true;
		while(xScale < 2)
		{
		//	Book.GetComponent<SpriteRenderer> ().color =  new Color(1, 1, 1, yScale);
		//	BlackBackGround.GetComponent<Image> ().color =  new Color(0, 0, 0, 1-xScale);
			BackGround.GetComponent<Image> ().color =  new Color(1, 1, 1, xScale);
			ExitButton.GetComponent<Image> ().color =  new Color(1, 1, 1, xScale);
			yield return new WaitForSeconds(0.001f);
			xScale += 0.03f;
        }
		//Book.SetActive (true);
		//AppearBook = true;
		xScale = 0;
		StartCoroutine(FadeOutContents());
	//	BackGround.GetComponent<Image> ().sprite = BackGroundSprite;

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
			yield return new WaitForSeconds(0.001f);
			xScale += 0.03f;
		} 
		ExitButton.GetComponent<Button> ().interactable = true;
		Book.GetComponent<Book> ().enabled = true;  // Swipe 활성
		RightHotSpot.SetActive(true);
		LeftHotSpot.SetActive (true);
		GameObject.Find ("GalleryOpen").GetComponent<Button>().interactable = true;
		Stage1.GetComponent<Button>().interactable = true;
		Stage2.GetComponent<Button>().interactable = true;
		Stage3.GetComponent<Button>().interactable = true;
		CheckGalleryTuto ();	

		if(EndingStoryManager.IsGetEnding == true && IsFirstTuto == false ){
			Gallery.SetActive (true);
			GalleryMg.SetActive (true);
			EndingStoryManager.IsGetEnding = false;
		}
		gameObject.GetComponent<TitleTest> ().enabled = false;
	}
		
    void PlayScene()
    {
        SceneManager.LoadScene(0);
    }

	public void CheckGalleryTuto(){

		if (GalleryManager.HappyEnding == true && GalleryManager.SadEnding == false && GalleryManager.SpecialEnding == false && GalleryManager.TrueEnding == false && IsFirstTuto == true) {
			GalleryTuto.SetActive (true);
			GalleryOpen.SetActive (false);
			Debug.Log ("1");
		}else if(GalleryManager.HappyEnding == false && GalleryManager.SadEnding == true && GalleryManager.SpecialEnding == false && GalleryManager.TrueEnding == false && IsFirstTuto == true){
			GalleryTuto.SetActive (true);
			GalleryOpen.SetActive (false);
			Debug.Log ("2");
		}else if(GalleryManager.HappyEnding == false && GalleryManager.SadEnding == false && GalleryManager.SpecialEnding == true && GalleryManager.TrueEnding == false && IsFirstTuto == true){
			GalleryTuto.SetActive (true);
			GalleryOpen.SetActive (false);
			Debug.Log ("3");
		}else if(GalleryManager.HappyEnding == false && GalleryManager.SadEnding == false && GalleryManager.SpecialEnding == false && GalleryManager.TrueEnding == true && IsFirstTuto == true){
			GalleryTuto.SetActive (true);
			GalleryOpen.SetActive (false);
			Debug.Log ("4");
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
