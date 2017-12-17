using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChessManager : MonoBehaviour {
	public static bool IsActiveScript = false;

	private GameObject target = null;
	public GameObject[] MovePossible;
	public GameObject[] BlackChess;
	public GameObject[] WhiteChess;
	public Vector2 pos;


	public GameObject GameText;
	public GameObject Null;


	public Sprite[] GameTextImage;
	private int Turn = 1;

	// Use this for initialization
	void OnEnable () {
		StartCoroutine (ShowGameText());
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonUp (0)) {
			CastRay ();
			Debug.Log (Turn);
			if (Turn == 1 && target.name == "Black_Queen") {
//				Debug.Log ("Touch");
				ShowMovePossible (7);
				StartCoroutine (ChangeTurn (2));
			}	else if(Turn == 1 && target.name != "Black_Queen") {
				Debug.Log (target.name);
				Reset ();
			}

			if (Turn == 2 && target.name == "MovePossible7") {
				WhiteChess [2].SetActive (false);
				BlackChess [0].transform.localPosition = new Vector3 (32.5f, -33.5f, 0);
				DeleteMovePossible (7);
				GameText.SetActive (true);
				GameText.GetComponent<SpriteRenderer> ().sprite = GameTextImage [1];
				StartCoroutine (ShowGameText());
				StartCoroutine (MoveRook());
			} else if(Turn == 2 && target.name != "MovePossible7") {
				Debug.Log (target.name);
				Reset ();
			}

			if (Turn == 3 && target.name == "Black_Knight") {
				ShowMovePossible (7);
				MovePossibleSeting ();
				StartCoroutine (ChangeTurn (4));
			}	else if(Turn == 3 && target.name != "Black_Knight") {
				Debug.Log (target.name);
				Reset ();
			}

			if (Turn == 4 && target.name == "MovePossible4") {
				DeleteMovePossible (7);
				BlackChess [2].transform.localPosition = new Vector3 (31.5f, -32.5f, 0);
				GameText.SetActive (true);
				GameText.GetComponent<SpriteRenderer> ().sprite = GameTextImage [2];
				StartCoroutine (ShowGameText());
			}	else if(Turn == 4 && target.name != "MovePossible4") {
				Debug.Log ("four");
				Debug.Log (target.name);
				Reset ();
			}


		}
	}

	void CastRay(){
		target = null;
		pos = Camera.main.ScreenToWorldPoint (Input.mousePosition);
		RaycastHit2D hit = Physics2D.Raycast (pos, Vector2.zero, 0f);

		if (hit.collider != null) {

			target = hit.collider.gameObject;
			//Debug.Log (target.name);
		} else {
			target = Null;
		}
	}

	public void Reset(){
		Turn = 1;
		BlackChess [0].SetActive (true);
		BlackChess [0].transform.localPosition = new Vector3 (30.5f, -31.5f, 0);
		BlackChess [2].transform.localPosition = new Vector3 (32.5f, -30.5f, 0); 	
		WhiteChess [2].SetActive (true);
		WhiteChess [3].transform.localPosition = new Vector3 (31.5f, -33.5f, 0); 	
		MovePossilbeReSet ();
		DeleteMovePossible (7);
		GameText.SetActive (true);
		GameText.GetComponent<SpriteRenderer> ().sprite = GameTextImage [0];
		StartCoroutine (ShowGameText());
	}

	public void ShowMovePossible(int number){
		for (int i = 0; i < number; i++) {
			MovePossible [i].SetActive (true);
		}
	}

	public void DeleteMovePossible(int number){
		for (int i = 0; i < number; i++) {
			MovePossible [i].SetActive (false);
		}
	}

	public void MovePossilbeReSet(){
		MovePossible [5].SetActive (true);
		MovePossible[0].transform.localPosition = new Vector3 (31.5f, -30.5f, 0);
		MovePossible[1].transform.localPosition = new Vector3 (32.5f, -29.5f, 0);
		MovePossible[2].transform.localPosition = new Vector3 (33.5f, -28.5f, 0);
		MovePossible[3].transform.localPosition = new Vector3 (31.5f, -32.5f, 0);
		MovePossible[4].transform.localPosition = new Vector3 (29.5f, -32.5f, 0);
		MovePossible[5].transform.localPosition = new Vector3 (28.5f, -33.5f, 0);
		MovePossible[6].transform.localPosition = new Vector3 (32.5f, -33.5f, 0);
	}

	public void MovePossibleSeting(){
		MovePossible[0].transform.localPosition = new Vector3 (30.5f, -29.5f, 0);
		MovePossible[1].transform.localPosition = new Vector3 (31.5f, -28.5f, 0);
		MovePossible[4].transform.localPosition = new Vector3 (30.5f, -31.5f, 0);
		MovePossible [5].SetActive (false);
		MovePossible[6].transform.localPosition = new Vector3 (33.5f, -32.5f, 0);
	
	}

	IEnumerator ShowGameText(){
		GameText.SetActive (true);
		yield return new WaitForSeconds(2.5f);
		GameText.SetActive (false);
		//StopAllCoroutines();
	}

	IEnumerator MoveRook(){
		yield return new WaitForSeconds(3.5f);
		WhiteChess [3].transform.localPosition = new Vector3 (32.5f, -33.5f, 0); 	
		BlackChess [0].SetActive (false);
		yield return new WaitForSeconds(1.5f);
		GameText.SetActive (true);
		GameText.GetComponent<SpriteRenderer> ().sprite = GameTextImage [0];
		StartCoroutine (ShowGameText());
		yield return new WaitForSeconds(2.0f);
		Turn = 3;
	}

	IEnumerator ChangeTurn(int number){
		yield return new WaitForSeconds(0.5f);
		Turn = number;
	}
}
