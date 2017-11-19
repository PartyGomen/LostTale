using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    public RectTransform panel;

    Vector3 startPosition = new Vector3(300, -5, 0);
    Vector3 endPosition = new Vector3(-160, -5, 0);

    [HideInInspector]
    public bool isOn;

    public AudioSource clickSound;

    public void OnUI()
    {
        clickSound.Play();

        if (isOn)
            OffCoroutine();
        else
            OnCoroutine();

        isOn = !isOn;
    }

    public void OnCoroutine()
    {
        StartCoroutine(UIOn());
    }

    public void OffCoroutine()
    {
        StartCoroutine(UIOff());
    }

    IEnumerator UIOn()
    {
        float timeOfTravel = 0.5f; //time after object reach a target place 
        float currentTime = 0; // actual floting time 
        float normalizedValue;

        while (currentTime <= timeOfTravel)
        {
            currentTime += Time.deltaTime;
            normalizedValue = currentTime / timeOfTravel; // we normalize our time 


            panel.anchoredPosition = Vector3.Lerp(startPosition, endPosition, normalizedValue);

            yield return null;
        }
    }

    IEnumerator UIOff()
    {
        float timeOfTravel = 0.5f; //time after object reach a target place 
        float currentTime = 0; // actual floting time 
        float normalizedValue;

        while (currentTime <= timeOfTravel)
        {
            currentTime += Time.deltaTime;
            normalizedValue = currentTime / timeOfTravel; // we normalize our time 

            panel.anchoredPosition = Vector3.Lerp(endPosition, startPosition, normalizedValue);

            yield return null;
        }
    }
}
