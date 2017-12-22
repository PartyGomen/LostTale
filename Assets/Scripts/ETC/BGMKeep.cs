using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMKeep : MonoBehaviour {

	void Awake(){
		DontDestroyOnLoad (gameObject);
	}
}
