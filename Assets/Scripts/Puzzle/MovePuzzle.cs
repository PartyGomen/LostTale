﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePuzzle : MonoBehaviour {
	public GameObject Null;
	private GameObject target = null;
	public Vector2 pos;

	public  GameObject Puzzle1;
	public  GameObject Puzzle2;
	public  GameObject Puzzle3;
	public  GameObject Puzzle4;
	public  GameObject Puzzle5;
	public  GameObject Puzzle6;
	public  GameObject Puzzle7;
	public  GameObject Puzzle8;
	public  GameObject Puzzle9;

	public bool DragOn1 = false;
	public bool DragOn2 = false;
	public bool DragOn3 = false;
	public bool DragOn4 = false;
	public bool DragOn5 = false;
	public bool DragOn6 = false;
	public bool DragOn7 = false;
	public bool DragOn8 = false;
	public bool DragOn9 = false;


	void FixedUpdate () {


		if (Input.GetMouseButton (0)) {
			CastRay ();	
			if(target.name == Puzzle1.name && DragOn1 == false) {
				Puzzle1.transform.position = pos;
				DragOn1 = false;
				DragOn2 = true;
				DragOn3 = true;
				DragOn4 = true;
				DragOn5 = true;
				DragOn6 = true;
				DragOn7 = true;
				DragOn8 = true;
				DragOn9 = true;
			}else if(target.name == Puzzle2.name && DragOn2 == false){				
				Puzzle2.transform.position = pos;
				DragOn1 = true;
				DragOn2 = false;
				DragOn3 = true;
				DragOn4 = true;
				DragOn5 = true;
				DragOn6 = true;
				DragOn7 = true;
				DragOn8 = true;
				DragOn9 = true;
			}else if(target.name == Puzzle3.name && DragOn3 == false){				
				Puzzle3.transform.position = pos;
				DragOn1 = true;
				DragOn2 = true;
				DragOn3 = false;
				DragOn4 = true;
				DragOn5 = true;
				DragOn6 = true;
				DragOn7 = true;
				DragOn8 = true;
				DragOn9 = true;
			}else if(target.name == Puzzle4.name && DragOn4 == false){				
				Puzzle4.transform.position = pos;
				DragOn1 = true;
				DragOn2 = true;
				DragOn3 = true;
				DragOn4 = false;
				DragOn5 = true;
				DragOn6 = true;
				DragOn7 = true;
				DragOn8 = true;
				DragOn9 = true;
			}else if(target.name == Puzzle5.name && DragOn5 == false){				
				Puzzle5.transform.position = pos;
				DragOn1 = true;
				DragOn2 = true;
				DragOn3 = true;
				DragOn4 = true;
				DragOn5 = false;
				DragOn6 = true;
				DragOn7 = true;
				DragOn8 = true;
				DragOn9 = true;
			}else if(target.name == Puzzle6.name && DragOn6 == false){				
				Puzzle6.transform.position = pos;
				DragOn1 = true;
				DragOn2 = true;
				DragOn3 = true;
				DragOn4 = true;
				DragOn5 = true;
				DragOn6 = false;
				DragOn7 = true;
				DragOn8 = true;
				DragOn9 = true;
			}else if(target.name == Puzzle7.name && DragOn7 == false){				
				Puzzle7.transform.position = pos;
				DragOn1 = true;
				DragOn2 = true;
				DragOn3 = true;
				DragOn4 = true;
				DragOn5 = true;
				DragOn6 = true;
				DragOn7 = false;
				DragOn8 = true;
				DragOn9 = true;
			}else if(target.name == Puzzle8.name && DragOn8 == false){				
				Puzzle8.transform.position = pos;
				DragOn1 = true;
				DragOn2 = true;
				DragOn3 = true;
				DragOn4 = true;
				DragOn5 = true;
				DragOn6 = true;
				DragOn7 = true;
				DragOn8 = false;
				DragOn9 = true;
			}else if(target.name == Puzzle9.name && DragOn9 == false){				
				Puzzle9.transform.position = pos;
				DragOn1 = true;
				DragOn2 = true;
				DragOn3 = true;
				DragOn4 = true;
				DragOn5 = true;
				DragOn6 = true;
				DragOn7 = true;
				DragOn8 = true;
				DragOn9 = false;
			}

		}
		if(Input.GetMouseButtonUp(0)){
			DragOn1 = false;
			DragOn2 = false;
			DragOn3 = false;
			DragOn4 = false;
			DragOn5 = false;
			DragOn6 = false;
			DragOn7 = false;
			DragOn8 = false;
			DragOn9 = false;
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
		}else {

			target = Null;
		}
	}
}
