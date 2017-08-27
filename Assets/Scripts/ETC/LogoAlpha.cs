using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LogoAlpha : MonoBehaviour
{
    Image img;

    float delayTime;
    float checkTime;

    bool alphaOn;

	void Start ()
    {
        img = GetComponent<Image>();

        delayTime = Random.Range(0.5f, 2.0f);
	}
	
    void AddAlpha()
    {
        img.CrossFadeAlpha(1.0f, delayTime, true);

        delayTime = Random.Range(0.5f, 2.0f);
    }

    void SubAlpha()
    {
        img.CrossFadeAlpha(0.0f, delayTime, true);

        delayTime = Random.Range(0.5f, 2.0f);
    }
   
	void Update ()
    {
        checkTime += Time.deltaTime;
        
        if(checkTime > delayTime)
        {
            if(alphaOn)
            {
                AddAlpha();
            }

            else
            {
                SubAlpha();
            }

            alphaOn = !alphaOn;

            checkTime = 0;
        }	
	}
}
