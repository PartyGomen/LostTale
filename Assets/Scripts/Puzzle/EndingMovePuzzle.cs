using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndingMovePuzzle : MonoBehaviour {
	public GameObject illustratorPanel;

	public GameObject Null;
	private GameObject target = null;

	public GameObject BackButton;


	public Vector2 pos;
	public Vector2 firstpos;
	public Vector2 offset;

	public Vector2 DownPos;
	public Vector2 UpPos;
	public float Distance;	

    public GameObject[] puzzles = new GameObject[9];
    public bool[] drags = new bool[9];


	public bool DragOn1 = false;
	public bool DragOn2 = false;
	public bool DragOn3 = false;
	public bool DragOn4 = false;
	public bool DragOn5 = false;
	public bool DragOn6 = false;
	public bool DragOn7 = false;
	public bool DragOn8 = false;
	public bool DragOn9 = false;

	public Sprite[] illustratorImage;

	Vector3 PuzzlePosition;
	void OnEnable(){
		for(int i =0 ; i < 9 ; i++){
			if(Inventory.PuzzleGet[i] == true){
				puzzles [i].SetActive (true);
			}
		}
	}

	void Update () {

		if (Input.GetMouseButtonDown(0)) {
			CastRay ();	
			offset = new Vector2 (target.transform.position.x - pos.x, target.transform.position.y - pos.y);
			DownPos = pos;

		/*	for (int i = 0; i < 9; i++) {
				PuzzlePosition = puzzles [i].GetComponent<RectTransform> ().transform.position;
				Debug.Log (PuzzlePosition);
				if (PuzzlePosition.x < 175) {
					PuzzlePosition.x = -175;
				} else if (PuzzlePosition.x > 190) {
					PuzzlePosition.x = 190;
				} else if (PuzzlePosition.y > -3.5f) {
					PuzzlePosition.y = -3.5f;
				} else if (PuzzlePosition.y < -6) {
					PuzzlePosition.y = -6;
				}
			}*/
		}

		if (Input.GetMouseButtonUp(0)) {
			UpPos = pos;
			Distance = Vector2.Distance (DownPos, UpPos);

			for (int i = 0; i < drags.Length; i++) {
				drags [i] = false;
			}

			if (Distance <= 0.4) {
				if (target.name == "Puzzle1") {
					illustratorPanel.GetComponent<Image> ().sprite = illustratorImage [0];
					illustratorPanel.SetActive (true);
					BackButton.SetActive (false);
					this.gameObject.GetComponent<EndingMovePuzzle> ().enabled = false;
				}else if (target.name == "Puzzle2"){
					illustratorPanel.GetComponent<Image> ().sprite = illustratorImage [1];
					illustratorPanel.SetActive (true);
					BackButton.SetActive (false);
					this.gameObject.GetComponent<EndingMovePuzzle> ().enabled = false;
				}else if (target.name == "Puzzle3"){
					illustratorPanel.GetComponent<Image> ().sprite = illustratorImage [2];
					illustratorPanel.SetActive (true);
					BackButton.SetActive (false);
					this.gameObject.GetComponent<EndingMovePuzzle> ().enabled = false;
				}else if (target.name == "Puzzle4"){
					illustratorPanel.GetComponent<Image> ().sprite = illustratorImage [3];
					illustratorPanel.SetActive (true);
					BackButton.SetActive (false);
					this.gameObject.GetComponent<EndingMovePuzzle> ().enabled = false;
				}else if (target.name == "Puzzle5"){
					illustratorPanel.GetComponent<Image> ().sprite = illustratorImage [4];
					illustratorPanel.SetActive (true);
					BackButton.SetActive (false);
					this.gameObject.GetComponent<EndingMovePuzzle> ().enabled = false;
				}else if (target.name == "Puzzle6"){
					illustratorPanel.GetComponent<Image> ().sprite = illustratorImage [5];
					illustratorPanel.SetActive (true);
					BackButton.SetActive (false);
					this.gameObject.GetComponent<EndingMovePuzzle> ().enabled = false;
				}else if (target.name == "Puzzle7"){
					illustratorPanel.GetComponent<Image> ().sprite = illustratorImage [6];
					illustratorPanel.SetActive (true);
					BackButton.SetActive (false);
					this.gameObject.GetComponent<EndingMovePuzzle> ().enabled = false;
				}else if (target.name == "Puzzle8"){
					illustratorPanel.GetComponent<Image> ().sprite = illustratorImage [7];
					illustratorPanel.SetActive (true);
					BackButton.SetActive (false);
					this.gameObject.GetComponent<EndingMovePuzzle> ().enabled = false;
				}else if (target.name == "Puzzle9"){
					illustratorPanel.GetComponent<Image> ().sprite = illustratorImage [8];
					illustratorPanel.SetActive (true);
					BackButton.SetActive (false);
					this.gameObject.GetComponent<EndingMovePuzzle> ().enabled = false;
				}
			}
		}


		if (Input.GetMouseButton (0)) {
			CastRay ();	
			if(target.name == "Puzzle1" && drags[0] == false) {
                DragCheck(0, true);
			}else if(target.name == "Puzzle2" && drags[1] == false){				
                DragCheck(1, true);
            }
			else if(target.name == "Puzzle3" && drags[2] == false){				
                DragCheck(2, true);
            }
			else if(target.name == "Puzzle4" && drags[3] == false){				
                DragCheck(3, true);
            }
			else if(target.name == "Puzzle5" && drags[4] == false){				
                DragCheck(4, true);
            }
			else if(target.name == "Puzzle6" && drags[5] == false){				
                DragCheck(5, true);
            }
			else if(target.name == "Puzzle7" && drags[6] == false){				
                DragCheck(6, true);
            }
			else if(target.name == "Puzzle8" && drags[7] == false){				
                DragCheck(7, true);
            }
			else if(target.name == "Puzzle9" && drags[8] == false){				
                DragCheck(8, true);
            }

		}
	}

	void CastRay(){
		target = null;
		pos = Camera.main.ScreenToWorldPoint (Input.mousePosition);
		RaycastHit2D hit = Physics2D.Raycast (pos, Vector2.zero, 0f);

		if (hit.collider != null) {
			target = hit.collider.gameObject;
		}else {

			target = Null;
		}
	}

	public void CloseillustratorPanel(){
		this.gameObject.GetComponent<EndingMovePuzzle> ().enabled = true;
		illustratorPanel.SetActive (false);
		BackButton.SetActive (true);
	}

    void DragCheck(int idx, bool puzzlepos)
    {
        if(puzzlepos)
			puzzles[idx].GetComponent<RectTransform>().transform.position = new Vector3(pos.x + offset.x, pos.y + offset.y , 0f);
		PuzzlePosition = puzzles [idx].GetComponent<RectTransform> ().anchoredPosition;

		if (PuzzlePosition.x < 175 && PuzzlePosition.y > -150) {
			puzzles [idx].GetComponent<RectTransform> ().anchoredPosition = new Vector3 (200, -150, 0);  
		} else if (PuzzlePosition.x < 175 && PuzzlePosition.y < -950) {
			puzzles [idx].GetComponent<RectTransform> ().anchoredPosition = new Vector3 (200, -950, 0);  
		} else if (PuzzlePosition.x > 1800 && PuzzlePosition.y > -150) {
			puzzles [idx].GetComponent<RectTransform> ().anchoredPosition = new Vector3 (1800, -150, 0);  
		} else if (PuzzlePosition.x > 1800 && PuzzlePosition.y < -950) {
			puzzles [idx].GetComponent<RectTransform> ().anchoredPosition = new Vector3 (1800, -950, 0);  
		} else if (PuzzlePosition.x < 175) {
			puzzles [idx].GetComponent<RectTransform> ().anchoredPosition = new Vector3 (200, PuzzlePosition.y, 0);  
		} else if (PuzzlePosition.x > 1800) {
			puzzles [idx].GetComponent<RectTransform> ().anchoredPosition = new Vector3 (1800, PuzzlePosition.y, 0);  
		} else if (PuzzlePosition.y > -150) {
			puzzles [idx].GetComponent<RectTransform> ().anchoredPosition = new Vector3 (PuzzlePosition.x, -150, 0);  
		} else if (PuzzlePosition.y < -950) {
			puzzles [idx].GetComponent<RectTransform> ().anchoredPosition = new Vector3 (PuzzlePosition.x, -950, 0);  
		} 


        for(int i = 0; i < drags.Length; i++)
        {     
			if (i == idx) {
				drags [i] = false;
			} else {
				drags[i] = true;
			}
        }
    }

}
