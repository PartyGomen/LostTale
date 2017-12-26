using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleEndCheck : MonoBehaviour {
	public GameObject[] PuzzleInk;
	public GameObject[] checkPos = new GameObject[5];


	private bool[] Is_On = {false, false, false, false, false};
	Vector3 next_position, distance, move;

	int posIdx;

	void Update(){
		if (Is_On[0] == true) {
			MoveCenterPuzzle (0);
		}else if (Is_On[1] == true){
			MoveCenterPuzzle (1);	
		}else if (Is_On[2] == true){
			MoveCenterPuzzle (2);	
		}else if (Is_On[3] == true){
			MoveCenterPuzzle (3);	
		}else if (Is_On[4] == true){
			MoveCenterPuzzle (4);	
		}
	}

	public void MoveCenterPuzzle(int number){
		distance = checkPos [number].transform.position - GameObject.Find (PuzzleEndManager.PuzzleEnd [number]).GetComponent<Transform> ().transform.position;

		next_position = GameObject.Find (PuzzleEndManager.PuzzleEnd [number]).GetComponent<Transform> ().transform.position + distance;

		move = next_position - GameObject.Find (PuzzleEndManager.PuzzleEnd [number]).GetComponent<Transform> ().transform.position;

		float snap_speed_min = 4f * 60.0f * Time.deltaTime;
		float snap_speed_max = 5f * 60.0f * Time.deltaTime;

		if (move.magnitude < snap_speed_min)
		{
			// 이동량이 일정 이하가 되면 종료.
			// 목표위치로 이동시킨다. 
			// 종료판정은 상태변화 점검에서 실행되므로 여기에서는 위치 조정만 실행한다.
			GameObject.Find (PuzzleEndManager.PuzzleEnd [number]).GetComponent<Transform> ().transform.position = checkPos[number].transform.position;
			Is_On [number] = false;
		}

		else
		{
			// 이동 속도가 너무 빠르면 조정한다.
			if (move.magnitude > snap_speed_max)
			{
				move *= snap_speed_max / move.magnitude;
				next_position =GameObject.Find (PuzzleEndManager.PuzzleEnd [number]).GetComponent<Transform> ().transform.position + move;
			}

			GameObject.Find (PuzzleEndManager.PuzzleEnd [number]).GetComponent<Transform> ().transform.position = next_position;
		}
	}




	void OnTriggerStay2D(Collider2D other)
	{
		if (other.gameObject.tag == "MoveObject") {
			if(this.gameObject.name == "PuzzleFix1" && PuzzleEndManager.PuzzleOn1 == false){
				PuzzleEndManager.PuzzleEnd [0] = other.gameObject.name;
				Debug.Log (PuzzleEndManager.PuzzleEnd [0]);
				PuzzleInk [0].SetActive (true);
				PuzzleEndManager.PuzzleOn1 = true;
				Debug.Log ("StayIn");
				Is_On[0]  = true;
			}
			if(this.gameObject.name == "PuzzleFix2" && PuzzleEndManager.PuzzleOn2 == false){
				PuzzleEndManager.PuzzleEnd [1] = other.gameObject.name;
				Debug.Log (PuzzleEndManager.PuzzleEnd [1]);
				PuzzleInk [1].SetActive (true);
				PuzzleEndManager.PuzzleOn2 = true;
				Is_On[1]  = true;
			}
			if(this.gameObject.name == "PuzzleFix3" && PuzzleEndManager.PuzzleOn3 == false){
				PuzzleEndManager.PuzzleEnd [2] = other.gameObject.name;
				Debug.Log (PuzzleEndManager.PuzzleEnd [2]);
				PuzzleInk [2].SetActive (true);
				PuzzleEndManager.PuzzleOn3 = true;
				Is_On[2]  = true;
			}
			if(this.gameObject.name == "PuzzleFix4" && PuzzleEndManager.PuzzleOn4 == false){
				PuzzleEndManager.PuzzleEnd [3] = other.gameObject.name;
				Debug.Log (PuzzleEndManager.PuzzleEnd [3]);
				PuzzleInk [3].SetActive (true);
				PuzzleEndManager.PuzzleOn4 = true;
				Is_On[3]  = true;
			}
			if(this.gameObject.name == "PuzzleFix5" && PuzzleEndManager.PuzzleOn5 == false){
				PuzzleEndManager.PuzzleEnd [4] = other.gameObject.name;
				Debug.Log (PuzzleEndManager.PuzzleEnd [4]);
				PuzzleInk [4].SetActive (true);
				PuzzleEndManager.PuzzleOn5 = true;
				Is_On[4]  = true;
			}

		}
	}

	void OnTriggerExit2D(Collider2D other){
		if (other.gameObject.tag == "MoveObject") {
			if (this.gameObject.name == "PuzzleFix1" && PuzzleEndManager.PuzzleOn1 == true) {
				PuzzleEndManager.PuzzleEnd [0] = "";
				PuzzleInk [0].SetActive (false);
				PuzzleEndManager.PuzzleOn1 = false;
				Is_On [0] = false;
			}
			if (this.gameObject.name == "PuzzleFix2" && PuzzleEndManager.PuzzleOn2 == true) {
				PuzzleEndManager.PuzzleEnd [1] = "";
				PuzzleInk [1].SetActive (false);
				PuzzleEndManager.PuzzleOn2 = false;
				Is_On [1] = false;
			}
			if (this.gameObject.name == "PuzzleFix3" && PuzzleEndManager.PuzzleOn3 == true) {
				PuzzleEndManager.PuzzleEnd [2] = "";
				PuzzleInk [2].SetActive (false);
				PuzzleEndManager.PuzzleOn3 = false;
				Is_On [2] = false;
			}
			if (this.gameObject.name == "PuzzleFix4" && PuzzleEndManager.PuzzleOn4 == true) {
				PuzzleEndManager.PuzzleEnd [3] = "";
				PuzzleInk [3].SetActive (false);
				PuzzleEndManager.PuzzleOn4 = false;
				Is_On [3] = false;
			}
			if (this.gameObject.name == "PuzzleFix5" && PuzzleEndManager.PuzzleOn5 == true) {
				PuzzleEndManager.PuzzleEnd [4] = "";
				PuzzleInk [4].SetActive (false);
				PuzzleEndManager.PuzzleOn5 = false;
				Is_On [4] = false;
			}
		}

	}
}
