using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StageClear : MonoBehaviour {
	private GameObject target = null;
	public Vector2 pos;
	public GameObject Null;

	public GameObject Control;
	public GameObject Control2;
	public GameObject EndingPuzzle;

	public GameObject ClearImage;
	public GameObject ClearPoint;

	public GameObject Panel;
	public GameObject FadePanel;
	public GameObject Player;

	public GameObject Silder;


	public int Stage;

	// Use this for initialization

	public float fadeT;

	ScreenTransitionImageEffect screenEffect;

	void Start () {
		this.GetComponent<AudioSource> ().Play ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonUp (0)) {
				CastRay ();
			if (target.name == "ClearImage" && Stage != 3) {
				Invoke ("BackToTitle", fadeT);
			}else if (target.name == "ClearImage" && Stage == 3) {
				Player.GetComponent<Player> ().Button_Left_release ();
				Player.GetComponent<Player> ().Button_Right_release ();
				Silder.GetComponent<Slider> ().value = 0.5f;
				Panel.SetActive (false);
				FadePanel.SetActive (false);
				EndingPuzzle.SetActive (true);
				Control.SetActive (true);
				Control2.SetActive (true);
				Player.SetActive (true);
				ClearPoint.SetActive (false);
				ClearImage.SetActive (false);
			}
		}
	}

	void CastRay(){
		target = null;
		pos = Camera.main.ScreenToWorldPoint (Input.mousePosition);
		RaycastHit2D hit = Physics2D.Raycast (pos, Vector2.zero, 0f);

		if (hit.collider != null) {

			target = hit.collider.gameObject;
			//Debug.Log (target.name);
		} else {
			target = Null;
		}
	}
		
	void BackToTitle()
	{
		SceneManager.LoadScene(3);
	}
}
