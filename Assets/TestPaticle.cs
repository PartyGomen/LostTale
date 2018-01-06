using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestPaticle : MonoBehaviour {
	public GameObject Test;

	// Use this for initialization
	void Start () {
		//Test.GetComponent<ParticleSystem> ().Stop ();
		StartCoroutine(StopParicle());
	}
	
	// Update is called once per frame
	void Update () {
		
	}


	IEnumerator StopParicle(){
		yield return new WaitForSeconds(1.2f);
		Test.GetComponent<ParticleSystem> ().Pause ();

	}
}
