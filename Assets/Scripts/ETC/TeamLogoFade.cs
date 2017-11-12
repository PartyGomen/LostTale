using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TeamLogoFade : MonoBehaviour
{
    enum FADE_OBJECT
    {
        IMAGE,
        FONT,
        ALLFADE,
        NONE
    };

    public float[] fade_time = null;

    public Image[] ui_object = null;

	// Use this for initialization
	void Start ()
    {
        StartCoroutine(AllFadeIn());
        StartCoroutine(ImgFadeOut());
        StartCoroutine(FontFadeOut());
        StartCoroutine(AllFadeOut());
        Invoke("SceneLoad", 7f);
	}

    void SceneLoad()
    {
        SceneManager.LoadScene(1);
    }

    IEnumerator AllFadeOut()
    {
        yield return new WaitForSeconds(6f);

        float t = 0.0f;

        while (t <= 1)
        {
            t += Time.deltaTime / fade_time[(int)FADE_OBJECT.ALLFADE];

            ui_object[(int)FADE_OBJECT.ALLFADE].color = new Color(0, 0, 0, t);

            yield return null;
        }
    }

    IEnumerator AllFadeIn()
    {
        float t = 1.0f;

        while (t >= 0)
        {
            t -= Time.deltaTime / fade_time[(int)FADE_OBJECT.ALLFADE];

            ui_object[(int)FADE_OBJECT.ALLFADE].color = new Color(0, 0, 0, t);

            yield return null;
        }
    }

    IEnumerator ImgFadeOut()
    {
        yield return new WaitForSeconds(1f);

        float t = 0.0f;

        while (t >= 0)
        {
            t += Time.deltaTime / fade_time[(int)FADE_OBJECT.IMAGE];

            ui_object[(int)FADE_OBJECT.IMAGE].color = new Color(1, 1, 1, t);

            yield return null;
        }
    }

    IEnumerator FontFadeOut()
    {
        yield return new WaitForSeconds(2f);

        float t = 0.0f;

        while (t >= 0)
        {
            t += Time.deltaTime / fade_time[(int)FADE_OBJECT.FONT];

            ui_object[(int)FADE_OBJECT.FONT].color = new Color(1, 1, 1, t);

            yield return null;
        }
    }
}
