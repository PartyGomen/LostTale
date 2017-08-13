using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class puzzleCrab : MonoBehaviour {

    private void OnTriggerEnter2D(Collider2D coll)
    {
        coll.transform.position = this.transform.position;
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
