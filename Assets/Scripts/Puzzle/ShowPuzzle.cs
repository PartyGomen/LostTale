using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowPuzzle : MonoBehaviour
{
	public GameObject Control;
	public GameObject PuzzleScreen;
	public static bool puzzleOn = false;
	public static bool puzzleClear = false;
    public GameObject Bridge;

	private GameObject target;
	public GameObject Null;
	public Vector2 pos;

	CameraFollow cam;
	public static bool TouchAble = false;

	void Update () {


		if (Input.GetMouseButtonDown (0) && TouchAble == true) {
			CastRay ();
			if (target.name == "CrabpuzzleShow") {
				cam = Camera.main.GetComponent<CameraFollow>();	
				cam.goPuzzele[0] = true;
				cam.CheckPuzzle();
				/*Control.SetActive(false);
				puzzleOn = true;*/
				//this.gameObject.GetComponent<SpriteRenderer>().enabled = false;
				//this.gameObject.GetComponent<CircleCollider2D>().enabled = false;
				//Bridge.SetActive (true);
			}
		}
	}
/*	void OnTriggerEnter2D(Collider2D other)
	{
        if (other.gameObject.CompareTag("Player"))
        {
            Control.SetActive(false);
            puzzleOn = true;
            this.gameObject.GetComponent<SpriteRenderer>().enabled = false;
            this.gameObject.GetComponent<CircleCollider2D>().enabled = false;
            Bridge.SetActive (true);
        }
    }*/



	void CastRay()
	{
		target = null;
		pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		RaycastHit2D hit = Physics2D.Raycast(pos, Vector2.zero, 0f);

		if (hit.collider != null) {
				
			target = hit.collider.gameObject;
			Debug.Log (target.name);
		} else {
			target = Null;
		}
	}
}