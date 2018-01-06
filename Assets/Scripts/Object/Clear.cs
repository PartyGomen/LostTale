﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Clear : MonoBehaviour
{
	public int PuzzleLevel;

    public float fadeT;

    public Image panel;

	public int Stage;

    ScreenTransitionImageEffect screenEffect;

    public GameObject mobile_control;
	public GameObject ClearImage;

	public GameObject Character;
	public GameObject[] PuzzleImage;
	public GameObject[] RightParticle;
	public GameObject[] PuzzleParticle;

		
	public Sprite[] CharacterImage;
	public Sprite[] GetPuzzleImage;

    public Inventory inven;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            mobile_control.SetActive(false);
            inven.PuzzleSave();
            panel.gameObject.SetActive(true);

			// 스테이지 클리어 변수 설정 
			if (PuzzleLevel == 1) {
				StageManager.IsClear_Stage1 = true;
				StageManager.IsFirstClear_Stage1++;
			} else if(PuzzleLevel == 2){
				StageManager.IsClear_Stage2 = true;
				StageManager.IsFirstClear_Stage2++;
			}


            GameObject.Find("HintManager").GetComponent<PuzzleHint>().StageClear();
         //   StartCoroutine(Fade());
            screenEffect = Camera.main.GetComponent<ScreenTransitionImageEffect>();
			Debug.Log ("HI");


			StartCoroutine (StageClearEffect(Stage));





            //screenEffect.maskInvert = true;



            //StartCoroutine(ScreenEffectStart());

         //   Invoke("BackToTitle", fadeT);
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

	IEnumerator  CheckStageClearEffect(int Stage){
		if (Stage == 1) {
			for(int i = 0 ; i <= Stage ; i++){
				if (Inventory.PuzzleGet [i] == true) {
					PuzzleParticle [i].SetActive (true);
					yield return new WaitForSeconds (1f);
					PuzzleImage [i].SetActive (true);
					PuzzleImage [i].GetComponent<Transform> ().localScale = new Vector3 (1, 1, 1);
					PuzzleImage [i].GetComponent<SpriteRenderer> ().sprite = GetPuzzleImage [i];
					yield return new WaitForSeconds (0.5f);
					RightParticle [i].GetComponent<ParticleSystem> ().Pause ();
				} else if(Inventory.PuzzleGet [i] == false){
					PuzzleImage [i].SetActive (true);
					PuzzleParticle [i].SetActive (false);
					yield return new WaitForSeconds (0.5f);
				}
			}
		} else if (Stage == 2) {

		} else if (Stage == 3) {

		}
	}
		
	IEnumerator StageClearEffect(int Stage){
		ClearImage.SetActive (true);
		yield return new WaitForSeconds (0.7f);
		Character.GetComponent<SpriteRenderer> ().sprite = CharacterImage [0];
		yield return new WaitForSeconds (0.5f);

		if (Stage == 1) {
			StartCoroutine (CheckStageClearEffect (1));
		} else if (Stage == 2) {
		
		} else if (Stage == 3) {
		
		}

	}

}
