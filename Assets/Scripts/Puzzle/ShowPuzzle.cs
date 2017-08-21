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

	private bool TouchAble = true;

	void Update () {


		if (Input.GetMouseButtonDown (0) && TouchAble == true) {
			CastRay ();
			if (target.name == "CrabpuzzleShow") {
				Control.SetActive(false);
				puzzleOn = true;
				this.gameObject.GetComponent<SpriteRenderer>().enabled = false;
				this.gameObject.GetComponent<CircleCollider2D>().enabled = false;
				Bridge.SetActive (true);
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
			//	Debug.Log (target.name);
			target = hit.collider.gameObject;
		} else {
			target = Null;
		}
	}
}