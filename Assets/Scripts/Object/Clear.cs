using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Clear : MonoBehaviour
{
    public float fadeT;

    public Image panel;

    ScreenTransitionImageEffect screenEffect;

    public GameObject mobile_control;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            mobile_control.SetActive(false);
            panel.gameObject.SetActive(true);
            StartCoroutine(Fade());
            screenEffect = Camera.main.GetComponent<ScreenTransitionImageEffect>();

            //screenEffect.maskInvert = true;

            StartCoroutine(ScreenEffectStart());
        }
    }


    IEnumerator ScreenEffectStart()
    {
        float t = 0.0f;

        while (t < 1)
        {
            t += Time.deltaTime / fadeT;

            screenEffect.maskValue = t;

            yield return null;
        }
    }

    IEnumerator Fade()
    {
        float t = 0.0f;

        while(t <= 1)
        {
            t += (Time.deltaTime / fadeT);

            panel.color = new Color(0, 0, 0, t);

            yield return null;
        }

        SceneManager.LoadScene(3);
    }
}
