using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleObject : MonoBehaviour
{
    public AudioSource paddleAudio;
	public GameObject BakcGround;
	public GameObject Control;
    public GameObject arrowController;
    bool sounded;
	
	void Update ()
    {
	    if(this.transform.localPosition.x < -43.93f && sounded == false)
        {
            sounded = true;
            paddleAudio.Play();
			BakcGround.SetActive (false);
			Control.SetActive (true);
            arrowController.SetActive(true);
			Debug.Log ("Down");
        }

        if(this.transform.localPosition.x >= -43.93f)
        {
            sounded = false;
        }
	}
}
