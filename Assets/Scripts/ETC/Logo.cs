using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Logo : MonoBehaviour
{
    Image img;

    bool alphaOn;
    bool isNext;

    float t = 0.0f;

    void Start()
    {
        img = GetComponent<Image>();
        SubAlpha();
        Invoke("NextTrue", 1f);
    }

    void NextTrue()
    {
        isNext = true;
    }

	void Update ()
    {
        t += Time.deltaTime;

        if(t > 1.0f)
        {
            alphaOn = !alphaOn;
            t = 0.0f;
        }

        if(alphaOn)
        {
            AddAlpha();
        }

        else
        {
            SubAlpha();
        }

	    if(Input.GetMouseButtonDown(0) && isNext == true)
        {
            SceneManager.LoadScene(1);
        }	
	}

    void AddAlpha()
    {
        img.CrossFadeAlpha(1f, 1f, false);
    }

    void SubAlpha()
    {
        img.CrossFadeAlpha(0.1f, 1f, false);
    }
}
