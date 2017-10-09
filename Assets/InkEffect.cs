using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InkEffect : MonoBehaviour {
	public Sprite[] InkImage;
	public Image Ink;

	void OnEnable(){
		StartCoroutine ("Ink_Effect");
	}
	public IEnumerator Ink_Effect(){
		for (int i=0; i < InkImage.Length; i++)
		{
			Ink.sprite = InkImage[i];
			yield return new WaitForSeconds(0.05f);
		}
	}
}
