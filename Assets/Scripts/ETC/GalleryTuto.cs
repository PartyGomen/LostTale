using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GalleryTuto : MonoBehaviour {
	public GameObject HandImage;
	public GameObject DotImage;

	private float alpha = 0;
	private bool trun = false;

	// Use this for initialization
	void OnEnable () {
		StartCoroutine (GalleryStartTuto());
	}
	
	// Update is called once per frame
	void Update () {
		
	}


	IEnumerator GalleryStartTuto(){
		while(alpha < 1){
			HandImage.GetComponent<Image>().color =  new Color(1, 1, 1, alpha);
			DotImage.GetComponent<Image>().color =  new Color(1, 1, 1, alpha);
			//Debug.Log ("ing");
			yield return new WaitForSeconds (0.1f);
			alpha += 0.1f;
		}
		StartCoroutine (HandalphaControl());
	}


	IEnumerator HandalphaControl(){
		while (true) {
			if(trun == true){
				HandImage.GetComponent<Image> ().color = new Color (1, 1, 1, alpha);
				DotImage.GetComponent<Image>().color =  new Color(1, 1, 1, alpha);
				alpha += 0.1f;
				if (alpha >= 1) {
					HandImage.GetComponent<RectTransform> ().anchoredPosition = new Vector3 (-230, -255, 0);
					HandImage.GetComponent<RectTransform> ().eulerAngles = new Vector3 (0, 0, -30);
					HandImage.GetComponent<RectTransform> ().localScale = new Vector3 (1, 1, 1);
					trun = false;
				}
			}else if(trun == false){
				HandImage.GetComponent<Image> ().color = new Color (1, 1, 1, alpha);
				DotImage.GetComponent<Image>().color =  new Color(1, 1, 1, alpha);
				alpha -= 0.1f;
				if (alpha <= 0.5){
					HandImage.GetComponent<RectTransform> ().anchoredPosition = new Vector3 (-245, -270, 0);
					HandImage.GetComponent<RectTransform> ().eulerAngles = new Vector3 (0, 0, 0);
					HandImage.GetComponent<RectTransform> ().localScale = new Vector3 (0.8f, 0.8f, 0.8f);
					trun = true;
				}
			}
			yield return new WaitForSeconds (0.1f);
		}
	}

}
