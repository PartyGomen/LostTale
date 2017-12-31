using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBackGroundFish : MonoBehaviour {
	public float MinX;
	public float MaxX;
	private float FishSpeed = 0.02f;
	private bool trun = true;

	// Update is called once per frame
	void Update () {
		if (this.transform.localPosition.x < MinX && trun ==true) {
			trun = false;
		}else if(this.transform.localPosition.x > MaxX && trun == false){
			trun = true;
		}

		if (trun == true) {
			this.transform.localScale = new Vector3 (1, 1, 1);
			this.transform.localPosition = new Vector3 (this.transform.localPosition.x - FishSpeed, this.transform.localPosition.y, 0);
		} else if (trun == false) {
			this.transform.localScale = new Vector3 (-1, 1, 1);
			this.transform.localPosition = new Vector3 (this.transform.localPosition.x + FishSpeed, this.transform.localPosition.y, 0);
		}
	}
}
