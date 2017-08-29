using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchArea : MonoBehaviour {
	public GameObject Player;
	private Vector2 distance;

	void Update () {
		distance = new Vector2 (Mathf.Abs(Player.transform.position.x - this.transform.position.x), Mathf.Abs(Player.transform.position.y - this.transform.position.y));
		if (distance.x <= 2 && distance.y <= 2) {
			ShowPuzzle.TouchAble = true;
		} else {
			ShowPuzzle.TouchAble = false;
		}
	}

}
