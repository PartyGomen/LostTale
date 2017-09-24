using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PuzzleCheck : MonoBehaviour {

	void OnTriggerStay2D(Collider2D other)
	{
		if (other.gameObject.tag == "MoveObject" ) {
		if (this.gameObject.name == "Stay1" && puzzleManager.Stay1IsOn == false ) {
				Debug.Log ("1");
				puzzleManager.Puzzle [0] = other.gameObject.name;	
				puzzleManager.Stay1IsOn = true;
			}else if (this.gameObject.name == "Stay2" && puzzleManager.Stay2IsOn == false) {
				puzzleManager.Puzzle [1] = other.gameObject.name;
				puzzleManager.Stay2IsOn = true;
			} else if (this.gameObject.name == "Stay3" && puzzleManager.Stay3IsOn == false) {
				puzzleManager.Puzzle [2] = other.gameObject.name;
				puzzleManager.Stay3IsOn = true;
			} else if (this.gameObject.name == "Stay4" && puzzleManager.Stay4IsOn == false) {
				puzzleManager.Puzzle [3] = other.gameObject.name;
				puzzleManager.Stay4IsOn = true;
			} else if (this.gameObject.name == "Stay5" && puzzleManager.Stay5IsOn == false) {
				puzzleManager.Puzzle [4] = other.gameObject.name;
				puzzleManager.Stay5IsOn = true;
			}
		}
		
	}

	void OnTriggerExit2D(Collider2D other){
		if (other.gameObject.tag == "MoveObject") {
			if (this.gameObject.name == "Stay1"  && puzzleManager.Stay1IsOn == true) {
				puzzleManager.Puzzle [0] = "";
				puzzleManager.Stay1IsOn = false;
			}else if (this.gameObject.name == "Stay2" && puzzleManager.Stay2IsOn == true) {
				puzzleManager.Puzzle [1] = "";
				puzzleManager.Stay2IsOn = false;
			} else if (this.gameObject.name == "Stay3" && puzzleManager.Stay3IsOn == true) {
				puzzleManager.Puzzle [2] = "";
				puzzleManager.Stay3IsOn = false;
			} else if (this.gameObject.name == "Stay4" && puzzleManager.Stay4IsOn == true) {
				puzzleManager.Puzzle [3] = "";
				puzzleManager.Stay4IsOn = false;
			}else if (this.gameObject.name == "Stay5" && puzzleManager.Stay5IsOn == true) {
				puzzleManager.Puzzle [4] = "";
				puzzleManager.Stay5IsOn = false;
			}

		}
	}
}
