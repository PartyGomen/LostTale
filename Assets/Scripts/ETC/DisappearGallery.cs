using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisappearGallery : MonoBehaviour {
	public GameObject Gallery;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButton (0)) {
			Gallery.SetActive (false);
		}
	}
}
