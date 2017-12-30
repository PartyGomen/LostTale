using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Clear : MonoBehaviour
{
	public int PuzzleLevel;

    public float fadeT;

    public Image panel;

    ScreenTransitionImageEffect screenEffect;

    public GameObject mobile_control;

    public Inventory inven;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            mobile_control.SetActive(false);
            inven.PuzzleSave();
            panel.gameObject.SetActive(true);
            GameObject.Find("HintManager").GetComponent<PuzzleHint>().StageClear();
            StartCoroutine(Fade());
            screenEffect = Camera.main.GetComponent<ScreenTransitionImageEffect>();
			Debug.Log ("HI");
            //screenEffect.maskInvert = true;
			if (PuzzleLevel == 1) {
				StageManager.IsClear_Stage1 = true;
				StageManager.IsFirstClear_Stage1++;
			} else if(PuzzleLevel == 2){
				StageManager.IsClear_Stage2 = true;
				StageManager.IsFirstClear_Stage2++;
			}


            StartCoroutine(ScreenEffectStart());

            Invoke("BackToTitle", fadeT);
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
    }

    void BackToTitle()
    {
        SceneManager.LoadScene(3);
    }
}
