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

	public int Stage;

    ScreenTransitionImageEffect screenEffect;

    public GameObject mobile_control;
    public GameObject arrowController;
	public GameObject ClearImage;
	public GameObject Player;

	public GameObject Character;
	public GameObject[] PuzzleImage;
	public GameObject[] RightParticle;
	public GameObject[] PuzzleParticle;

		
	public Sprite[] CharacterImage;
	public Sprite[] GetPuzzleImage;

    public Inventory inven;
	public Camera GameCamera;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            mobile_control.SetActive(false);
            arrowController.SetActive(false);
            inven.PuzzleSave();
            panel.gameObject.SetActive(true);

			// 스테이지 클리어 변수 설정 
			if (PuzzleLevel == 1) {
				StageManager.IsClear_Stage1 = true;
				StageManager.IsFirstClear_Stage1++;
				Debug.Log (StageManager.IsFirstClear_Stage1);
			} else if(PuzzleLevel == 2){
				StageManager.IsClear_Stage2 = true;
				StageManager.IsFirstClear_Stage2 ++;
				StageManager.IsFirstClear_Stage2 ++;
				Debug.Log (StageManager.IsFirstClear_Stage2);
			}


            GameObject.Find("HintManager").GetComponent<PuzzleHint>().StageClear();
         //   StartCoroutine(Fade());
         //   screenEffect = Camera.main.GetComponent<ScreenTransitionImageEffect>();
			Debug.Log ("HI");
			StartCoroutine (StageClearEffect(Stage));





            //screenEffect.maskInvert = true;



            //StartCoroutine(ScreenEffectStart());

         //   Invoke("BackToTitle", fadeT);
        }
    }


 /*   IEnumerator ScreenEffectStart()
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
    }*/

    void BackToTitle()
    {
        SceneManager.LoadScene(3);
    }

	public void ClickButton(){
		Debug.Log ("Finish");

	}

	IEnumerator  CheckStageClearEffect(int Stage, int Value){
		for (int i = 0; i <= Stage; i++) {
			if (Inventory.PuzzleGet [Value + i] == true) {
				PuzzleParticle [i].SetActive (true);
				yield return new WaitForSeconds (1f);
				PuzzleImage [i].SetActive (true);
				PuzzleImage [i].GetComponent<Transform> ().localScale = new Vector3 (1, 1, 1);
				PuzzleImage [i].GetComponent<SpriteRenderer> ().sprite = GetPuzzleImage [i];
				yield return new WaitForSeconds (0.5f);
				RightParticle [i].GetComponent<ParticleSystem> ().Pause ();
			} else if (Inventory.PuzzleGet [Value + i] == false) {
				PuzzleImage [i].SetActive (true);
				PuzzleParticle [i].SetActive (false);
				yield return new WaitForSeconds (0.5f);
			}
		}
		ClearImage.GetComponent<BoxCollider2D> ().enabled = true;
	}
		
	IEnumerator StageClearEffect(int Stage){
		if (Stage == 1) {
			GameCamera.GetComponent<CameraFollow> ().enabled = false;
			Player.SetActive (false);
			GameCamera.transform.localPosition = new Vector3 (129f, -0.2393f, -10f);
		} else if (Stage == 2) {
			GameCamera.GetComponent<CameraFollow> ().enabled = false;
			Player.SetActive (false);
			GameCamera.transform.localPosition = new Vector3 (166.3f, -1f, -10f);
		} else if (Stage == 3) {
			Player.SetActive (false);
			Player.transform.localPosition = new Vector3 (Player.transform.localPosition.x, 8.770699f, 0f);
			GameCamera.transform.localPosition = new Vector3 (183f, 8.770699f, -10f);
		}

		ClearImage.SetActive (true);
		//PuzzleParticle [0].SetActive (true);
		//PuzzleParticle [1].SetActive (true);
		yield return new WaitForSeconds (0.7f);
		Character.GetComponent<SpriteRenderer> ().sprite = CharacterImage [0];
	//	yield return new WaitForSeconds (0.5f);


		if (Stage == 1) {
			StartCoroutine (CheckStageClearEffect (1, 0));
		} else if (Stage == 2) {
			StartCoroutine (CheckStageClearEffect (2, 2));
		} else if (Stage == 3) {
			StartCoroutine (CheckStageClearEffect (3, 5));
		}

	}

}
