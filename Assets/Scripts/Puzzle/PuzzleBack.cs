using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleBack : MonoBehaviour
{
    CameraFollow camfollow;

	void Start ()
    {
        camfollow = Camera.main.GetComponent<CameraFollow>();
	}

    public void Back()
    {
		GameObject.Find("BackButtonSound").GetComponent<AudioSource> ().Play ();
        camfollow.CheckPlayer();
    }
}
