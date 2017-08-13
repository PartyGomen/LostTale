using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleMoveObject : MonoBehaviour {

	private GameObject target = null;
	public Vector2 pos;

	public Animator Ani1;
	public Animator Ani2;
	public Animator Ani3;
	public Animator Ani4;
	public Animator Ani5;
	//private string name = null;


	// Update is called once per frame
	void Update () {

		if (this.gameObject.name.Equals("1")) {
			Ani1.SetBool ("IsOut", false);
		}else if(this.gameObject.name.Equals("2")){
			Ani2.SetBool ("IsOut", false);
		}else if(this.gameObject.name.Equals("3")){
			Ani3.SetBool ("IsOut", false);
		}else if(this.gameObject.name.Equals("4")){
			Ani4.SetBool ("IsOut", false);
		}else if(this.gameObject.name.Equals("5")){
			Ani5.SetBool ("IsOut", false);
		}

		if (Input.GetMouseButton (0)) {
			CastRay ();	
			if(this.gameObject.name == "1" && target == this.gameObject) {
				Ani1.SetBool ("IsOut", true);
				this.gameObject.transform.position = pos;
			}else if(this.gameObject.name == "2" && target == this.gameObject){
				Ani2.SetBool ("IsOut", true);
				this.gameObject.transform.position = pos;
			}else if(this.gameObject.name == "3" && target == this.gameObject){
				Ani3.SetBool ("IsOut", true);
				this.gameObject.transform.position = pos;
			}else if(this.gameObject.name == "4" && target == this.gameObject){
				Ani4.SetBool ("IsOut", true);
				this.gameObject.transform.position = pos;
			}else if(this.gameObject.name == "5" && target == this.gameObject){
				Ani5.SetBool ("IsOut", true);
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
