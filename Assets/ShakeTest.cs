using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShakeTest : MonoBehaviour {
	//public void []Vector3 StartPosition;
//	public static bool IsShake = true;
	private float ShakeTime = 3.0f;
	private float Switch = 1.0f;
	// Use this for initialization
	void Start () {
		
	}
	 
	// Update is called once per frame
	void Update () {
		if (ShakeTime > 0) {
			for (int i = 0; i < 2; i++) {
				Vector2 ShakePosition =  new Vector2(Switch * 20.0f, Switch * 20.0f);
				GameObject.Find (PuzzleEndManager.PuzzleEnd [i]).GetComponent<RectTransform> ().anchoredPosition = new Vector3 (GameObject.Find (PuzzleEndManager.PuzzleEnd [i]).GetComponent<RectTransform> ().anchoredPosition.x + ShakePosition.x, GameObject.Find (PuzzleEndManager.PuzzleEnd [i]).GetComponent<RectTransform> ().anchoredPosition.y + ShakePosition.y, 0);
				Switch = -1.0f * Switch;
			}
			ShakeTime -= Time.deltaTime;
		}else {
			Debug.Log ("finish");
		}

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
}
