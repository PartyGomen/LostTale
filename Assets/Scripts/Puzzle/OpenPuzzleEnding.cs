using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OpenPuzzleEnding : MonoBehaviour {	
	public GameObject Player;
	public GameObject PuzzleEnd;
	public GameObject MoblieControl;
	public float Distance;
	public GameObject Null;

	private GameObject target = null;
	private Vector2 pos;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetMouseButton (0))
        {
            Distance = Vector2.Distance(this.transform.position, Player.transform.position);

            if(Distance <= 2.0f)
            {
                CastRay();
                if (target.name == "PuzzleEnd")
                {
                    PuzzleEnd.SetActive(true);
                    MoblieControl.SetActive(false);
                }
            }
		}
	}

	public void CloseEndPuzzle(){
		GameObject.Find ("Puzzle1").GetComponent<RectTransform> ().anchoredPosition = new Vector3 (500, -710, 0);
		GameObject.Find ("Puzzle2").GetComponent<RectTransform> ().anchoredPosition = new Vector3 (800, -734, 0);
		GameObject.Find ("Puzzle3").GetComponent<RectTransform> ().anchoredPosition = new Vector3 (1100, -695, 0);
		GameObject.Find ("Puzzle4").GetComponent<RectTransform> ().anchoredPosition = new Vector3 (-500, -692, 0);
		GameObject.Find ("Puzzle5").GetComponent<RectTransform> ().anchoredPosition = new Vector3 (344, -920, 0);
		GameObject.Find ("Puzzle6").GetComponent<RectTransform> ().anchoredPosition = new Vector3 (644, -935, 0);
		GameObject.Find ("Puzzle7").GetComponent<RectTransform> ().anchoredPosition = new Vector3 (944, -899, 0);
		GameObject.Find ("Puzzle8").GetComponent<RectTransform> ().anchoredPosition = new Vector3 (1244, -920, 0);
		GameObject.Find ("Puzzle9").GetComponent<RectTransform> ().anchoredPosition = new Vector3 (1544, -935, 0);
		PuzzleEnd.SetActive (false);
		MoblieControl.SetActive (true);
	}


	void CastRay(){
		target = null;
		pos = Camera.main.ScreenToWorldPoint (Input.mousePosition);
		RaycastHit2D hit = Physics2D.Raycast (pos, Vector2.zero, 0f);

		if (hit.collider != null) {
			target = hit.collider.gameObject;
			//name = hit.collider.gameObject.name;
			//Debug.Log (name);
		}else {

			target = Null;
		}
	}

}
