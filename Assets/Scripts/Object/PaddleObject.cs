using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleObject : MonoBehaviour
{
    public AudioSource paddleAudio;

    bool sounded;
	
	void Update ()
    {
	    if(this.transform.position.x < -43.245 && sounded == false)
        {
            sounded = true;
            paddleAudio.Play();
        }

        if(this.transform.position.x >= -43)
        {
            sounded = false;
        }
	}
}
