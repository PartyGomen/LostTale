using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OpenPuzzleEnding : MonoBehaviour {	
	public GameObject Cam;
	public GameObject Player;
	public GameObject PuzzleEnd;
	public GameObject MoblieControl;
	public float Distance;
	public GameObject Null;

	private GameObject target = null;
	private Vector2 pos;

	CameraFollow cam;
	Vector3 camPosition;
	// Use this for initialization
	void Start () {
		cam = Camera.main.GetComponent<CameraFollow>();
		camPosition = cam.transform.position;
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
					Player.transform.position = new Vector3 (185, -10, 0);
					Player.SetActive (false);
                    PuzzleEnd.SetActive(true);
                    MoblieControl.SetActive(false);


                }
            }
		}
	}

	public void CloseEndPuzzle(){
		if (Inventory.PuzzleGet [0] == true) {
			GameObject.Find ("Puzzle1").GetComponent<RectTransform> ().anchoredPosition = new Vector3 (500, -710, 0);
		} else if (Inventory.PuzzleGet [1] == true) {
			GameObject.Find ("Puzzle2").GetComponent<RectTransform> ().anchoredPosition = new Vector3 (800, -734, 0);
		} else if (Inventory.PuzzleGet [2] == true) {
			GameObject.Find ("Puzzle3").GetComponent<RectTransform> ().anchoredPosition = new Vector3 (1100, -695, 0);
		} else if (Inventory.PuzzleGet [3] == true) {
			GameObject.Find ("Puzzle4").GetComponent<RectTransform> ().anchoredPosition = new Vector3 (1420, -692, 0);
		} else if (Inventory.PuzzleGet [4] == true) {
			GameObject.Find ("Puzzle5").GetComponent<RectTransform> ().anchoredPosition = new Vector3 (344, -920, 0);
		} else if (Inventory.PuzzleGet [5] == true) {
			GameObject.Find ("Puzzle6").GetComponent<RectTransform> ().anchoredPosition = new Vector3 (644, -935, 0);
		} else if (Inventory.PuzzleGet [6] == true) {
			GameObject.Find ("Puzzle7").GetComponent<RectTransform> ().anchoredPosition = new Vector3 (944, -899, 0);
		} else if (Inventory.PuzzleGet [7] == true) {
			GameObject.Find ("Puzzle8").GetComponent<RectTransform> ().anchoredPosition = new Vector3 (1244, -920, 0);
		} else if (Inventory.PuzzleGet [8] == true) {
			GameObject.Find ("Puzzle9").GetComponent<RectTransform> ().anchoredPosition = new Vector3 (1544, -935, 0);
		}
		PuzzleEnd.SetActive (false);
		MoblieControl.SetActive (true);
		Player.transform.position = new Vector3 (190, 8.7f, 0);
		Player.SetActive (true);
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
