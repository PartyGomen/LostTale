using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour {

	public AudioSource Click;

	void Awake(){
		Destroy (GameObject.Find("BGM"));
	}

	public void ClickSoundPlay(){
		Click.Play ();
	}
}
