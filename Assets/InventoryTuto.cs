using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class InventoryTuto : MonoBehaviour {
	public GameObject HandImage;

	private float alpha = 0;
	private bool trun = true;


	
	void OnEnable () {
		StartCoroutine (GalleryStartTuto());
	}


	IEnumerator GalleryStartTuto(){
		while(alpha < 1){
			HandImage.GetComponent<Image>().color =  new Color(1, 1, 1, alpha);

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
				alpha += 0.1f;
				if (alpha >= 1) {
					HandImage.GetComponent<RectTransform> ().anchoredPosition = new Vector3 (568, 380, 0);
					HandImage.GetComponent<RectTransform> ().eulerAngles = new Vector3 (0, 0, -30);
					HandImage.GetComponent<RectTransform> ().localScale = new Vector3 (1.9f, 1.9f, 1.9f);
					trun = false;
				}
			}else if(trun == false){
				HandImage.GetComponent<Image> ().color = new Color (1, 1, 1, alpha);
				alpha -= 0.1f;
				if (alpha <= 0.5){
					HandImage.GetComponent<RectTransform> ().anchoredPosition = new Vector3 (555, 401, 0);
					HandImage.GetComponent<RectTransform> ().eulerAngles = new Vector3 (0, 0, 0);
					HandImage.GetComponent<RectTransform> ().localScale = new Vector3 (2f, 2f, 2f);
					trun = true;
				}
			}
			yield return new WaitForSeconds (0.1f);
		}
	}
}
