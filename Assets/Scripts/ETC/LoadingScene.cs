﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadingScene : MonoBehaviour
{
    public static string nextScene;
	public Text ProcessText;
	public Text TipText;
	public GameObject RunningImage;

	public string []TipTextArray;
	private int random;
    [SerializeField]
    Image progressBar;
	RectTransform RunningPosition;
	private float X_Position;

    private void Start()
    {
		
		random = Random.Range (0, 5);
		Debug.Log (random);
		TipText.text = TipTextArray [random];
        StartCoroutine(LoadScene());
//		RunningPosition = RunningImage.GetComponent<RectTransform> ().anchoredPosition;
    }

    string nextSceneName;
	public static bool IsGameTuto = false;

    public static void LoadScene(string sceneName)
    {
        nextScene = sceneName;
    }

    IEnumerator LoadScene()
    {
        yield return null;

        AsyncOperation op = SceneManager.LoadSceneAsync(nextScene);
        op.allowSceneActivation = false;

        float timer = 0.0f;
        while (!op.isDone)
        {
            yield return null;

            timer += Time.deltaTime / 5;
			//ProcessText .text = timer +"%";
			ProcessText .text = Mathf.Round(progressBar.fillAmount * 100) +"%";
			X_Position = progressBar.fillAmount * 1850;
			RunningImage.GetComponent<RectTransform> ().anchoredPosition = new Vector3 ( X_Position, 103, 0);
            if (op.progress >= 0.9f)
            {
                progressBar.fillAmount = Mathf.Lerp(progressBar.fillAmount*0.7f, 1f, timer);

				if (progressBar.fillAmount == 1.0f) {
					if (IsGameTuto == true) {
						SceneManager.LoadScene ("Scene1-1");
					}
					op.allowSceneActivation = true;
				}
            }
            else
            {
				progressBar.fillAmount = Mathf.Lerp(progressBar.fillAmount*0.7f, op.progress, timer);
                if (progressBar.fillAmount >= op.progress)
                {
                    timer = 0f;
                }
            }
        }
    }
}
