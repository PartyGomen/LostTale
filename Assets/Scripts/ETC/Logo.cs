using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Logo : MonoBehaviour
{
    public Image[] img;

    bool alphaOn;

    float t = 0.0f;

    void Start()
    {
        SubAlpha();
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

	    if(Input.GetMouseButtonDown(0))
        {
            SceneManager.LoadScene(1);
        }	
	}

    void AddAlpha()
    {
        img[0].CrossFadeAlpha(1f, 1f, false);

        for (int i = 1; i < img.Length; i++)
        {
            img[i].CrossFadeAlpha(1f, Random.Range(0.5f, 2.0f), false);
        }
    }

    void SubAlpha()
    {
        img[0].CrossFadeAlpha(0.2f, 1f, false);

        for (int i = 1; i < img.Length; i++)
        {
            img[i].CrossFadeAlpha(0.2f, Random.Range(0.5f, 2.0f), false);
        }
    }
}
