using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShakeTest : MonoBehaviour {
	//public void []Vector3 StartPosition;
//	public static bool IsShake = true;
	public GameObject []PuzzleBox;
	private float count = 0.0f;
	// Use this for initialization

	void Start () {
		
	}
	 
	void OnEnable () {
		StartCoroutine (ShakePuzzles());
	}
	// Update is called once per frame
	void Update () {
	//	if(Input.GetMouseButton(0)){
		//	StartCoroutine (ShakePuzzles());
	//	}
	}

/*	public void ShakePuzzle(){
		while (IsShake == true) {
			for (int i = 0; i < 2; i++) {
				Vector2 ShakePosition = Random.insideUnitCircle * 5;
				GameObject.Find (PuzzleEndManager.PuzzleEnd [i]).GetComponent<RectTransform> ().anchoredPosition = new Vector3 (GameObject.Find (PuzzleEndManager.PuzzleEnd [i]).GetComponent<RectTransform> ().anchoredPosition.x + ShakePosition.x, GameObject.Find (PuzzleEndManager.PuzzleEnd [i]).GetComponent<RectTransform> ().anchoredPosition.y + ShakePosition.y, 0);
				yield return new WaitForSeconds (5.0f);
				IsShake = false;
				StopAllCoroutines ();
			}
			/*yield return new WaitForSeconds (5.0f);
			IsShake = false;
			Debug.Log ("finish");*/
		//	StopAllCoroutines ();
		//}
			//yield return new WaitForSeconds (5.0f);
			//IsShake = false;
		//	StopAllCoroutines ();
		
		//IsShake = true;
		//Debug.Log ("finish");
//	}*/

	IEnumerator ShakePuzzles(){
		while (count < 20) {
			for (int i = 0; i < 2; i++) {	
				Debug.Log ("start");
				Vector2 ShakePosition = new Vector2 (20f, 20f);
				PuzzleBox[i].GetComponent<RectTransform> ().anchoredPosition = new Vector3 (PuzzleBox[i].GetComponent<RectTransform> ().anchoredPosition.x + ShakePosition.x,PuzzleBox[i].GetComponent<RectTransform> ().anchoredPosition.y, 0);
				//!GameObject.Find (PuzzleEndManager.PuzzleEnd [i]).GetComponent<RectTransform> ().anchoredPosition = new Vector3 (GameObject.Find (PuzzleEndManager.PuzzleEnd [i]).GetComponent<RectTransform> ().anchoredPosition.x + ShakePosition.x, GameObject.Find (PuzzleEndManager.PuzzleEnd [i]).GetComponent<RectTransform> ().anchoredPosition.y, 0);
				//	GameObject.Find (PuzzleEndManager.PuzzleEnd [i]).GetComponent<RectTransform> ().anchoredPosition = new Vector3 (GameObject.Find (PuzzleEndManager.PuzzleEnd [i]).GetComponent<RectTransform> ().anchoredPosition.x - ShakePosition.x, GameObject.Find (PuzzleEndManager.PuzzleEnd [i]).GetComponent<RectTransform> ().anchoredPosition.y - ShakePosition.y, 0);
				Debug.Log ("shake");
			}
			//	count++;
			yield  return new WaitForSeconds (0.01f);

			//}
			for (int i = 0; i < 2; i++) {	
				Debug.Log ("start");
				Vector2 ShakePosition = new Vector2 (20f, 20f);
				PuzzleBox[i].GetComponent<RectTransform> ().anchoredPosition = new Vector3 (PuzzleBox[i].GetComponent<RectTransform> ().anchoredPosition.x - ShakePosition.x,PuzzleBox[i].GetComponent<RectTransform> ().anchoredPosition.y, 0);
				//GameObject.Find (PuzzleEndManager.PuzzleEnd [i]).GetComponent<RectTransform> ().anchoredPosition = new Vector3 (GameObject.Find (PuzzleEndManager.PuzzleEnd [i]).GetComponent<RectTransform> ().anchoredPosition.x + ShakePosition.x, GameObject.Find (PuzzleEndManager.PuzzleEnd [i]).GetComponent<RectTransform> ().anchoredPosition.y + ShakePosition.y, 0);
				//!GameObject.Find (PuzzleEndManager.PuzzleEnd [i]).GetComponent<RectTransform> ().anchoredPosition = new Vector3 (GameObject.Find (PuzzleEndManager.PuzzleEnd [i]).GetComponent<RectTransform> ().anchoredPosition.x - ShakePosition.x, GameObject.Find (PuzzleEndManager.PuzzleEnd [i]).GetComponent<RectTransform> ().anchoredPosition.y, 0);
				Debug.Log ("shake");
			}
			yield  return new WaitForSeconds (0.01f);
			count++;
		}
		count = 0;
	}


}
