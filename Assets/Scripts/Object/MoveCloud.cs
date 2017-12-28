using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCloud : MonoBehaviour {
	public float speed;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
		this.GetComponent<Transform> ().transform.localPosition = new Vector3 (this.GetComponent<Transform> ().transform.localPosition.x - speed, this.GetComponent<Transform> ().transform.localPosition.y, 0);
		if (this.GetComponent<Transform> ().transform.localPosition.x < -6) {
			this.GetComponent<Transform> ().transform.localPosition = new Vector3 (187.5f, this.GetComponent<Transform> ().transform.localPosition.y, 0);
		}
	}
}
