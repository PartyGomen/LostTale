using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndingStoryManager : MonoBehaviour {
	public string[] EndingText;
	public Sprite[] EndingImage;

	public GameObject Ending;
	public Text EndText;

	private float colorcount = 0;
	private int Textcount = 0;
	// Use this for initialization
	void Start () {
		StartCoroutine (FadeOutEnding());
		StartCoroutine (ShowText(0));
	}
	
	// Update is called once per frame
	void Update () {
		Debug.Log (EndingText.Length);
	}



	public IEnumerator FadeOutEnding(){
		while(colorcount < 255){
		colorcount += 0.05f;
		Ending.GetComponent<Image>().color  = new Color(colorcount, colorcount, colorcount, 255);
		EndText.GetComponent<Text>().color  = new Color(colorcount, colorcount, colorcount, 255);
		yield return new WaitForSeconds (0.025f);
		}
	}

	public IEnumerator ShowText(int number){
		while (Textcount <= EndingText[number].Length) {
			//EndingText [0].Substring (0, Textcount);
			EndText.text = EndingText [number].Substring (0, Textcount);
			Textcount++;
			yield return new WaitForSeconds (0.1f);
		}
	}
}
