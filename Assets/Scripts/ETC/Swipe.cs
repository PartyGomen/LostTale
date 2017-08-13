using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Swipe : MonoBehaviour {

	const int MinPage = 1;
	const int MaxPage = 3;

	private int NowPage = 1;

	private  Vector2 StartPos;
	private  Vector2 EndPos;
	private  Vector2 SwipePos;

	private GameObject target;
	public Vector2 pos;

	private bool IsSwipe = false; // Swipe 인식을 위한 변수 

	public Animator BookAni;



	private GameObject ContentLeft1;
	private GameObject ContentLeft2;
	private GameObject ContentRight1;
	private GameObject ContentRight2;

	public GameObject Stage1;
	public GameObject Stage2;
	public GameObject Stage3;


	public GameObject Gallery;
	public GameObject Null;

	private bool TouchAble = true;  // 연속적인 Swipe 막기 위한 변수 


	float xScale = 0;

	private void Start()
	{
		ContentLeft1 = GameObject.Find ("ContentLeft1");
		ContentLeft2 = GameObject.Find ("ContentLeft2");
		ContentRight1 = GameObject.Find ("ContentRight1");
		ContentRight2 = GameObject.Find ("ContentRight2");
	}

	// Update is called once per frame
	void Update () {
		

		if (Input.GetMouseButtonDown (0) && TouchAble == true) {
			CastRay();
			if (target == this.gameObject) {
				StartPos = Camera.main.ScreenToWorldPoint (Input.mousePosition);
				IsSwipe = true;
			} else if (target.name == "Gallery" && target != this.gameObject) {
				Gallery.SetActive (false);
				GameObject.Find ("Book").GetComponent<BoxCollider2D> ().enabled = true;

			} 
		}

		if (Input.GetMouseButtonUp (0) && IsSwipe == true && TouchAble == true) {
			TouchAble = false;
			EndPos = Camera.main.ScreenToWorldPoint (Input.mousePosition);
			SwipePos.x = EndPos.x - StartPos.x;
			SwipePos.y =  Mathf.Abs(EndPos.y - StartPos.y);
	
			if (SwipePos.x > 1.0f && SwipePos.y < 2f && (NowPage > MinPage)) {  // 페이지를 왼쪽으로 옮길 경우 
				NowPage--; 
				Debug.Log ("Left");
				//StartCoroutine (FadeDisappearContents ()); // 책 내용물 페이드 효과 
				BookAni.SetBool ("PageLeft", true); 
			

				StartCoroutine (LeftFalse ()); // 책 넘김 효과 


			} else if (SwipePos.x < -1.0f && SwipePos.y < 2f && (NowPage < MaxPage)) { // 페이지를 오른쪽으로 옮길 경우 
				NowPage++;
				StartCoroutine (FadeDisappearContents ());
				BookAni.SetBool ("PageRight", true);
				StartCoroutine (RightFalse ());


			} else if (((NowPage >= MaxPage) && (SwipePos.x < -1.0f && SwipePos.y < 2f))|| ((NowPage <= MinPage) && (SwipePos.x > 1.0f && SwipePos.y < 2f))) { // 최소, 최대 페이지를 넘겼을 때 예외처리
				IsSwipe = false;
				TouchAble = true;
			} else {  // 책 클릭 시 Gallery가 나옴 
				GameObject.Find("Book").GetComponent<BoxCollider2D>().enabled = false;
				Gallery.SetActive (true);
				IsSwipe = false;
				TouchAble = true;
			}

		}

	}


	void CastRay()
	{
		target = null;
		pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		RaycastHit2D hit = Physics2D.Raycast(pos, Vector2.zero, 0f);

		if (hit.collider != null) {
			//	Debug.Log (target.name);
			target = hit.collider.gameObject;
		} else {
			target = Null;
		}
	}


	IEnumerator LeftFalse()
	{
		ContentLeft1.GetComponent<Image> ().fillOrigin = (int) Image.OriginHorizontal.Left;
		while(ContentLeft1.GetComponent<Image>().fillAmount > 0){
			yield return new WaitForSeconds(0.1f);
			ContentLeft1.GetComponent<Image> ().fillAmount -= 0.1f;
		}

		BookAni.SetBool ("PageLeft", false);
		
	}


	IEnumerator RightFalse()
	{
		yield return new WaitForSeconds(0.1f);
		BookAni.SetBool ("PageRight", false);
	}


	IEnumerator FadeDisappearContents()
	{
		xScale = 2;
		while (xScale > -1) {  // 책 내용물  Fade Out 시킴 
			ContentLeft1.GetComponent<Image> ().color =  new Color(1, 1, 1, xScale);
			ContentLeft2.GetComponent<Image> ().color =  new Color(1, 1, 1, xScale);
			ContentRight1.GetComponent<Image> ().color =  new Color(1, 1, 1, xScale);
			ContentRight2.GetComponent<Image> ().color =  new Color(1, 1, 1, xScale);
			Stage1.GetComponent<Image> ().color =  new Color(1, 1, 1, xScale);
			Stage2.GetComponent<Image> ().color =  new Color(1, 1, 1, xScale);
			Stage3.GetComponent<Image> ().color =  new Color(1, 1, 1, xScale);

			yield return new WaitForSeconds(0.001f);
			xScale -= 0.05f;
		} 
		xScale = 2;
		//yield return new WaitForSeconds(0.03f);
		StartCoroutine(FadeappearContents());
	}

	IEnumerator FadeappearContents()
	{
		xScale = 0;
		while (xScale < 2) {  // 책 내용물  Fade Out 시킴 
			ContentLeft1.GetComponent<Image> ().color =  new Color(1, 1, 1, xScale);
			ContentLeft2.GetComponent<Image> ().color =  new Color(1, 1, 1, xScale);
			ContentRight1.GetComponent<Image> ().color =  new Color(1, 1, 1, xScale);
			ContentRight2.GetComponent<Image> ().color =  new Color(1, 1, 1, xScale);
			Stage1.GetComponent<Image> ().color =  new Color(1, 1, 1, xScale);
			Stage2.GetComponent<Image> ().color =  new Color(1, 1, 1, xScale);
			Stage3.GetComponent<Image> ().color =  new Color(1, 1, 1, xScale);

			yield return new WaitForSeconds(0.001f);
			xScale += 0.05f;
		} 
		xScale = 0;
		IsSwipe = false;
		TouchAble = true;
	}



}
