using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleObject : MonoBehaviour
{
    public AudioSource paddleAudio;

    bool sounded;
	
	void Update ()
    {
	    if(this.transform.localPosition.x < -43.65f && sounded == false)
        {
            sounded = true;
            paddleAudio.Play();
        }

        if(this.transform.localPosition.x >= -43.65f)
        {
            sounded = false;
        }
	}
}
