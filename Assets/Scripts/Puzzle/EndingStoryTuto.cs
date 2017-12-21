using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndingStoryTuto : MonoBehaviour {
	public static bool Is_FirstEndingTuto = false;

	public GameObject PuzzleImage;
	public GameObject HandImage;
	public GameObject ArrowImage;

	public GameObject PuzzleEndTuto;

	private float alpha = 0;
	private bool trun = false;

	private float x = -450;
	private float y = -160;
	// Use this for initialization
	void OnEnable () {
		//if(Is_FirstEndingTuto == true){
		Debug.Log("hi");
			StartCoroutine (EndingTuto());
	//	}
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void ExitTuto(){
		PuzzleEndTuto.SetActive (false);
	}


	IEnumerator EndingTuto(){
		while(alpha < 1){
			HandImage.GetComponent<Image>().color =  new Color(1, 1, 1, alpha);
			ArrowImage.GetComponent<Image>().color =  new Color(1, 1, 1, alpha);
			//Debug.Log ("ing");
			yield return new WaitForSeconds (0.1f);
			alpha += 0.1f;
		}
		StartCoroutine (HandalphaControl());
	}


	IEnumerator HandalphaControl(){
		while (true) {
			if (x >= -750 && y < 300) {
				PuzzleImage.GetComponent<RectTransform> ().anchoredPosition = new Vector3 (x, y, 0);
				HandImage.GetComponent<RectTransform> ().anchoredPosition = new Vector3 (-0.5f, -67.6f, 0);
				HandImage.GetComponent<RectTransform> ().eulerAngles = new Vector3 (0, 0, 0);
				HandImage.GetComponent<RectTransform> ().localScale = new Vector3 (0.3f, 0.3f, 0.3f);
				x -= 24;
				y += 39;
				Debug.Log ("x :" + x + "y : " + y);
			} else {
				x = -450;
				y = -160;
				yield return new WaitForSeconds (1.0f);
				PuzzleImage.GetComponent<RectTransform> ().anchoredPosition = new Vector3 (x, y, 0);
				HandImage.GetComponent<RectTransform> ().anchoredPosition = new Vector3 (-36.7f, -103.8f, 0);
				HandImage.GetComponent<RectTransform> ().eulerAngles = new Vector3 (0, 0, -30f);
				HandImage.GetComponent<RectTransform> ().localScale = new Vector3 (0.5f, 0.5f, 0.5f);
				yield return new WaitForSeconds (0.5f);
			}

			if(trun == true){
				HandImage.GetComponent<Image> ().color = new Color (1, 1, 1, alpha);
				ArrowImage.GetComponent<Image>().color =  new Color(1, 1, 1, alpha);
				alpha += 0.1f;
				if (alpha >= 1) {
					trun = false;
				}
			}else if(trun == false){
				HandImage.GetComponent<Image> ().color = new Color (1, 1, 1, alpha);
				ArrowImage.GetComponent<Image>().color =  new Color(1, 1, 1, alpha);
				alpha -= 0.1f;
				if (alpha <= 0.5){
					trun = true;
				}
			}
			yield return new WaitForSeconds (0.1f);
		}
	}
}
