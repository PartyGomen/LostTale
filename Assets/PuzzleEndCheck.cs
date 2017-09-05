using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleEndCheck : MonoBehaviour {

	void OnTriggerStay2D(Collider2D other)
	{
		if (other.gameObject.tag == "MoveObject") {
			if(this.gameObject.name == "PuzzleFix1" && PuzzleEndManager.PuzzleOn1 == false){
				PuzzleEndManager.PuzzleEnd [0] = other.gameObject.name;
				Debug.Log (PuzzleEndManager.PuzzleEnd [0]);
				PuzzleEndManager.PuzzleOn1 = true;
			}
			if(this.gameObject.name == "PuzzleFix2" && PuzzleEndManager.PuzzleOn2 == false){
				PuzzleEndManager.PuzzleEnd [1] = other.gameObject.name;
				Debug.Log (PuzzleEndManager.PuzzleEnd [1]);
				PuzzleEndManager.PuzzleOn2 = true;
			}
			if(this.gameObject.name == "PuzzleFix3" && PuzzleEndManager.PuzzleOn3 == false){
				PuzzleEndManager.PuzzleEnd [2] = other.gameObject.name;
				Debug.Log (PuzzleEndManager.PuzzleEnd [2]);
				PuzzleEndManager.PuzzleOn3 = true;
			}
			if(this.gameObject.name == "PuzzleFix4" && PuzzleEndManager.PuzzleOn4 == false){
				PuzzleEndManager.PuzzleEnd [3] = other.gameObject.name;
				Debug.Log (PuzzleEndManager.PuzzleEnd [3]);
				PuzzleEndManager.PuzzleOn4 = true;
			}
			if(this.gameObject.name == "PuzzleFix5" && PuzzleEndManager.PuzzleOn5 == false){
				PuzzleEndManager.PuzzleEnd [4] = other.gameObject.name;
				Debug.Log (PuzzleEndManager.PuzzleEnd [4]);
				PuzzleEndManager.PuzzleOn5 = true;
			}

		}
	}

	void OnTriggerExit2D(Collider2D other){
		if (other.gameObject.tag == "MoveObject") {
			if (this.gameObject.name == "PuzzleFix1" && PuzzleEndManager.PuzzleOn1 == true) {
				PuzzleEndManager.PuzzleEnd [0] = "";
				Debug.Log (PuzzleEndManager.PuzzleEnd [0]);
				PuzzleEndManager.PuzzleOn1 = false;
			}
			if (this.gameObject.name == "PuzzleFix2" && PuzzleEndManager.PuzzleOn2 == true) {
				PuzzleEndManager.PuzzleEnd [1] = "";
				Debug.Log (PuzzleEndManager.PuzzleEnd [1]);
				PuzzleEndManager.PuzzleOn2 = false;
			}
			if (this.gameObject.name == "PuzzleFix3" && PuzzleEndManager.PuzzleOn3 == true) {
				PuzzleEndManager.PuzzleEnd [2] = "";
				Debug.Log (PuzzleEndManager.PuzzleEnd [2]);
				PuzzleEndManager.PuzzleOn3 = false;
			}
			if (this.gameObject.name == "PuzzleFix4" && PuzzleEndManager.PuzzleOn4 == true) {
				PuzzleEndManager.PuzzleEnd [3] = "";
				Debug.Log (PuzzleEndManager.PuzzleEnd [3]);
				PuzzleEndManager.PuzzleOn4 = false;
			}
			if (this.gameObject.name == "PuzzleFix5" && PuzzleEndManager.PuzzleOn5 == true) {
				PuzzleEndManager.PuzzleEnd [4] = "";
				Debug.Log (PuzzleEndManager.PuzzleEnd [4]);
				PuzzleEndManager.PuzzleOn5 = false;
			}
		}

	}
}
