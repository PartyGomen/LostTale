using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleEndCheck : MonoBehaviour {
	public GameObject[] PuzzleInk;
	
	
	void OnTriggerStay2D(Collider2D other)
	{
		if (other.gameObject.tag == "MoveObject") {
			if(this.gameObject.name == "PuzzleFix1" && PuzzleEndManager.PuzzleOn1 == false){
				PuzzleEndManager.PuzzleEnd [0] = other.gameObject.name;
				Debug.Log (PuzzleEndManager.PuzzleEnd [0]);
				PuzzleInk [0].SetActive (true);
				PuzzleEndManager.PuzzleOn1 = true;
			}
			if(this.gameObject.name == "PuzzleFix2" && PuzzleEndManager.PuzzleOn2 == false){
				PuzzleEndManager.PuzzleEnd [1] = other.gameObject.name;
				Debug.Log (PuzzleEndManager.PuzzleEnd [1]);
				PuzzleInk [1].SetActive (true);
				PuzzleEndManager.PuzzleOn2 = true;
			}
			if(this.gameObject.name == "PuzzleFix3" && PuzzleEndManager.PuzzleOn3 == false){
				PuzzleEndManager.PuzzleEnd [2] = other.gameObject.name;
				Debug.Log (PuzzleEndManager.PuzzleEnd [2]);
				PuzzleInk [2].SetActive (true);
				PuzzleEndManager.PuzzleOn3 = true;
			}
			if(this.gameObject.name == "PuzzleFix4" && PuzzleEndManager.PuzzleOn4 == false){
				PuzzleEndManager.PuzzleEnd [3] = other.gameObject.name;
				Debug.Log (PuzzleEndManager.PuzzleEnd [3]);
				PuzzleInk [3].SetActive (true);
				PuzzleEndManager.PuzzleOn4 = true;
			}
			if(this.gameObject.name == "PuzzleFix5" && PuzzleEndManager.PuzzleOn5 == false){
				PuzzleEndManager.PuzzleEnd [4] = other.gameObject.name;
				Debug.Log (PuzzleEndManager.PuzzleEnd [4]);
				PuzzleInk [4].SetActive (true);
				PuzzleEndManager.PuzzleOn5 = true;
			}

		}
	}

	void OnTriggerExit2D(Collider2D other){
		if (other.gameObject.tag == "MoveObject") {
			if (this.gameObject.name == "PuzzleFix1" && PuzzleEndManager.PuzzleOn1 == true) {
				PuzzleEndManager.PuzzleEnd [0] = "";
				PuzzleInk [0].SetActive (false);
				PuzzleEndManager.PuzzleOn1 = false;
			}
			if (this.gameObject.name == "PuzzleFix2" && PuzzleEndManager.PuzzleOn2 == true) {
				PuzzleEndManager.PuzzleEnd [1] = "";
				PuzzleInk [1].SetActive (false);
				PuzzleEndManager.PuzzleOn2 = false;
			}
			if (this.gameObject.name == "PuzzleFix3" && PuzzleEndManager.PuzzleOn3 == true) {
				PuzzleEndManager.PuzzleEnd [2] = "";
				PuzzleInk [2].SetActive (false);
				PuzzleEndManager.PuzzleOn3 = false;
			}
			if (this.gameObject.name == "PuzzleFix4" && PuzzleEndManager.PuzzleOn4 == true) {
				PuzzleEndManager.PuzzleEnd [3] = "";
				PuzzleInk [3].SetActive (false);
				PuzzleEndManager.PuzzleOn4 = false;
			}
			if (this.gameObject.name == "PuzzleFix5" && PuzzleEndManager.PuzzleOn5 == true) {
				PuzzleEndManager.PuzzleEnd [4] = "";
				PuzzleInk [4].SetActive (false);
				PuzzleEndManager.PuzzleOn5 = false;
			}
		}

	}
}
