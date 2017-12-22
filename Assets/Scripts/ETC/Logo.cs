using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Logo : MonoBehaviour
{
    Image img;
    public Image fade_img;

    bool alphaOn;
    bool isNext;

    float t = 0.0f;


	public GameObject BGM;

	void Awake(){
		DontDestroyOnLoad (BGM);
	}

    void Start()
    {
        StartCoroutine(FadeIn());
        img = GetComponent<Image>();
        SubAlpha();
        Invoke("NextTrue", 1f);
    }

    IEnumerator FadeIn()
    {
        float t = 1.0f;

        while (t >= 0)
        {
            t -= Time.deltaTime / 1;

            fade_img.color = new Color(0, 0, 0, t);

            yield return null;
        }
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
            SceneManager.LoadScene(2);
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
