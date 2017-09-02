using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePuzzle : MonoBehaviour {

	private GameObject target = null;
	public Vector2 pos;


	void FixedUpdate () {


		if (Input.GetMouseButton (0)) {
			CastRay ();	
			if(this.gameObject.name == "Puzzle1" && target == this.gameObject) {
				this.gameObject.transform.position = pos;
			}else if(this.gameObject.name == "Puzzle2" && target == this.gameObject){				
				this.gameObject.transform.position = pos;
			}else if(this.gameObject.name == "Puzzle3" && target == this.gameObject){
				this.gameObject.transform.position = pos;
			}else if(this.gameObject.name == "Puzzle4" && target == this.gameObject){
				this.gameObject.transform.position = pos;
			}else if(this.gameObject.name == "Puzzle5" && target == this.gameObject){
				this.gameObject.transform.position = pos;
			}else if(this.gameObject.name == "Puzzle6" && target == this.gameObject){
				this.gameObject.transform.position = pos;
			}else if(this.gameObject.name == "Puzzle7" && target == this.gameObject){
				this.gameObject.transform.position = pos;
			}else if(this.gameObject.name == "Puzzle8" && target == this.gameObject){
				this.gameObject.transform.position = pos;
			}else if(this.gameObject.name == "Puzzle9" && target == this.gameObject){
				this.gameObject.transform.position = pos;
			}
		}


	}

	void CastRay(){
		target = null;
		pos = Camera.main.ScreenToWorldPoint (Input.mousePosition);
		RaycastHit2D hit = Physics2D.Raycast (pos, Vector2.zero, 0f);

		if (hit.collider != null) {
			target = hit.collider.gameObject;
			//name = hit.collider.gameObject.name;
			//Debug.Log (name);
		}
	}
}
