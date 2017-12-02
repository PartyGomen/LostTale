﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CameraFollow : MonoBehaviour
{
    ScreenTransitionImageEffect screeneffect;

    public GameObject followTargetOBJ;
    public GameObject control;
    public GameObject backBtn;

    public float fadeTime;
    public float followSpeed;
    public float[] minxy = new float[2];
    public float[] maxxy = new float[2];

    public bool[] goPuzzele;
    bool isPuzzle;

    public Vector3[] puzzlePos;

    public Image panel;

    private void Start()
    {
        control.SetActive(false);

        screeneffect = GetComponent<ScreenTransitionImageEffect>();

        StartCoroutine(ScreenEffectStart());
        StartCoroutine(Fade(true, 0f));
    }

    IEnumerator Fade(bool is_in, float delay)
    {
        yield return new WaitForSeconds(delay);

        if(is_in)
        {
            float t = 1.0f;

            while (t >= 0)
            {
                t -= (Time.deltaTime / fadeTime);

                panel.color = new Color(0, 0, 0, t);

                yield return null;
            }

            panel.gameObject.SetActive(false);
        }

        else
        {
            panel.gameObject.SetActive(true);

            float t = 0.0f;

            while (t < 1)
            {
                t += (Time.deltaTime / fadeTime);

                panel.color = new Color(0, 0, 0, t);

                yield return null;
            }
        }
    }

    IEnumerator ScreenEffectStart()
    {
        float t = 1.0f;

        while (t >= 0)
        {
            t -= Time.deltaTime / fadeTime;

            screeneffect.maskValue = t;

            yield return null;
        }

        //Destroy(screeneffect);
        control.SetActive(true);
    }

    void FixedUpdate()
    { 
        if(!isPuzzle)
        {
            if (ShowPuzzle.puzzleOn == false)
            {
                Vector3 NewPosition = Vector3.Lerp(this.transform.position, followTargetOBJ.transform.position, followSpeed * Time.deltaTime);
                NewPosition = new Vector3(Mathf.Clamp(NewPosition.x, minxy[0], maxxy[0]), Mathf.Clamp(NewPosition.y, minxy[1], maxxy[1]), NewPosition.z);
                this.transform.position = new Vector3(NewPosition.x, NewPosition.y, this.transform.position.z);
            }
        }
    }
    
    public void CheckPuzzleOrPlayer(bool is_puzzle)
    {
        if (is_puzzle)
        {
            control.SetActive(false);
            Invoke("CheckPuzzle", 1f);
        }
        else
            Invoke("CheckPlayer", 1f);
    }

    public void CheckPuzzle()
    {
        isPuzzle = true;
        backBtn.SetActive(true);

        for (int i = 0; i < goPuzzele.Length; i++)
        {
            if(goPuzzele[i] == true)
            {
                this.transform.position = puzzlePos[i];
            }
        }
    }

    public void CheckPlayer()
    {
        isPuzzle = false;

        Transform tr = GameObject.FindWithTag("Player").GetComponent<Transform>();

        this.transform.position = new Vector3(tr.position.x, tr.position.y, -10);

        control.SetActive(true);
        backBtn.SetActive(false);
    }

    public void FadeCoroutine(bool fade_in, float delay_time)
    {
        StartCoroutine(Fade(fade_in, delay_time));
    }
}
