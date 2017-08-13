using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTest : MonoBehaviour {

    public float shakeTimer;
    public float shakeAmount;
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetMouseButtonDown(0))
        {
            ShakeCamera(0.1f, 1);
        }

        if (shakeTimer >= 0)
        {
            Vector2 ShakePos = Random.insideUnitCircle * shakeAmount;

            transform.position = new Vector3(transform.position.x + ShakePos.x, transform.position.y + ShakePos.y, transform.position.z);

            shakeTimer -= Time.deltaTime;
        }
    }

    public void ShakeCamera(float shakePwr, float shakeDur)
    {
        shakeAmount = shakePwr;
        shakeTimer = shakeDur;
    }
}
