using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewChessManager : MonoBehaviour {
	public GameObject Black_Knight;
	private GameObject target = null;
	public Vector2 pos;

	public GameObject Null;

	bool[, ] Position = new bool[6, 6] {{false, true, false, true, true, false}, {false, true, false, true, false, true}, {true, true, true, false, true, false}, {true, false, false, false, false, true}, {false, false, false, true, false, false}, {false, false, false, true, false, false}};
	public Vector2 NowPosition;


	public GameObject[] PossibleImage;
	public GameObject CheckMateImage;

	private int count = 0 ;

	private float SettingX;
	private float SettingY;

	private int PosX;
	private int PosY;

	private Player player;

    public GameObject clearImage;

	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonUp (0)) {
			CastRay ();
			if(target.name == "Black_Knight"){
				CheckPossible ();
			}

			if (target.name == "Possible1") {
				MovePossibleArea ("Possible1");
			}else if(target.name == "Possible2"){
				MovePossibleArea ("Possible2");
			}else if(target.name == "Possible3"){
				MovePossibleArea ("Possible3");
			}else if(target.name == "Possible4"){
				MovePossibleArea ("Possible4");
			}else if(target.name == "Possible5"){
				MovePossibleArea ("Possible5");
			}else if(target.name == "Possible6"){
				MovePossibleArea ("Possible6");
			}else if(target.name == "Possible7"){
				MovePossibleArea ("Possible7");
			}else if(target.name == "Possible8"){
				MovePossibleArea ("Possible8");
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

	public void CheckPossible(){
		if(NowPosition.x + 2  <= 6){
			if(NowPosition.y - 1 >= 1){
				if (Position [(int)NowPosition.x + 1, (int)NowPosition.y - 2] == false) {
					count = 0;
					PossibleImageSetting ((int)NowPosition.x + 1, (int)NowPosition.y - 2, count);
				}
			}
			if(NowPosition.y + 1 <= 6){
				if (Position [(int)NowPosition.x + 1, (int)NowPosition.y] == false) {
					count = 1;
					PossibleImageSetting ((int)NowPosition.x + 1, (int)NowPosition.y, count);
				}
			}
		}
		if(NowPosition.x - 2 >= 1){
			if(NowPosition.y - 1 >= 1){
				if (Position [(int)NowPosition.x - 3, (int)NowPosition.y - 2] == false) {
					count = 2;
					PossibleImageSetting ((int)NowPosition.x - 3, (int)NowPosition.y - 2, count);
				}
			}
			if(NowPosition.y + 1 <= 6){
				if (Position [(int)NowPosition.x - 3, (int)NowPosition.y] == false) {
					count = 3;
					PossibleImageSetting ((int)NowPosition.x - 3, (int)NowPosition.y, count);
				}
			}
		}
		if(NowPosition.x + 1  <= 6){
			if(NowPosition.y - 2 >= 1){
				if (Position [(int)NowPosition.x, (int)NowPosition.y - 3] == false) {
					count = 4;
					PossibleImageSetting ((int)NowPosition.x, (int)NowPosition.y - 3, count);
				}
			}
			if(NowPosition.y + 2 <= 6){
				if (Position [(int)NowPosition.x, (int)NowPosition.y + 1] == false) {
					count = 5;
					PossibleImageSetting ((int)NowPosition.x, (int)NowPosition.y + 1, count);
				}
			}
		}
		if(NowPosition.x - 1  >= 1){
			if(NowPosition.y - 2 >= 1){
				if (Position [(int)NowPosition.x - 2, (int)NowPosition.y - 3] == false) {
					count = 6;
					PossibleImageSetting ((int)NowPosition.x - 2, (int)NowPosition.y - 3, count);
				}
			}
			if(NowPosition.y + 2 <= 6){
				if (Position [(int)NowPosition.x - 2, (int)NowPosition.y + 1] == false) {
					count = 7;
					PossibleImageSetting ((int)NowPosition.x - 2, (int)NowPosition.y + 1, count);
				}
			}
		}
	}
	public void PossibleImageSetting(int x, int y, int count){
		if (x == 0) {
			SettingY = -26.66f;
		} else if (x == 1) {
			SettingY = -27.99f;
		} else if (x == 2) {
			SettingY = -29.33f;
		} else if (x == 3) {
			SettingY = -30.66f;
		} else if (x == 4) {
			SettingY = -32f;
		} else if (x == 5) {
			SettingY = -33.33f;
		}

		if (y == 0) {
			SettingX = 26.66f;
		}else if (y == 1){
			SettingX = 27.99f;
		}else if (y == 2){
			SettingX = 29.32f;
		}else if (y == 3){
			SettingX = 30.66f;
		}else if (y == 4){
			SettingX = 32.01f;
		}else if (y == 5){
			SettingX = 33.35f;
		}

		if(count == 0){
			PossibleImage [0].SetActive (true);
			PossibleImage [0].transform.localPosition = new Vector3 (SettingX, SettingY, 0);
		}else if(count == 1){
			PossibleImage [1].SetActive (true);
			PossibleImage [1].transform.localPosition = new Vector3 (SettingX, SettingY, 0);
		}else if(count == 2){
			PossibleImage [2].SetActive (true);
			PossibleImage [2].transform.localPosition = new Vector3 (SettingX, SettingY, 0);
		}else if(count == 3){
			PossibleImage [3].SetActive (true);
			PossibleImage [3].transform.localPosition = new Vector3 (SettingX, SettingY, 0);
		}else if(count == 4){
			PossibleImage [4].SetActive (true);
			PossibleImage [4].transform.localPosition = new Vector3 (SettingX, SettingY, 0);
		}else if(count == 5){
			PossibleImage [5].SetActive (true);
			PossibleImage [5].transform.localPosition = new Vector3 (SettingX, SettingY, 0);
		}else if(count == 6){
			PossibleImage [6].SetActive (true);
			PossibleImage [6].transform.localPosition = new Vector3 (SettingX, SettingY, 0);
		}else if(count == 7){
			PossibleImage [7].SetActive (true);
			PossibleImage [7].transform.localPosition = new Vector3 (SettingX, SettingY, 0);
		}
	}

	public void MovePossibleArea(string Name){
		SettingX = GameObject.Find(Name).GetComponent<Transform>().localPosition.x;
		SettingY = GameObject.Find(Name).GetComponent<Transform>().localPosition.y;

		if (SettingY == -26.66f) {
			PosX = 1;
		} else if (SettingY == -27.99f) {
			PosX = 2;
		} else if (SettingY == -29.33f) {
			PosX = 3;
		} else if (SettingY == -30.66f) {
			PosX = 4;
		} else if (SettingY == -32f) {
			PosX = 5;
		} else if (SettingY == -33.33f) {
			PosX = 6;
		}

		if (SettingX == 26.66f) {
			PosY = 1;
		}else if (SettingX == 27.99f){
			PosY = 2;
		}else if (SettingX == 29.32f){
			PosY = 3;
		}else if (SettingX == 30.66f){
			PosY = 4;
		}else if (SettingX == 32.01f){
			PosY = 5;
		}else if (SettingX == 33.35f){
			PosY = 6;
		}
			MoveKnight (PosX-1, PosY-1);
			NowPosition = new Vector2 (PosX, PosY);
		for (int i = 0; i < 8; i++) {
			PossibleImage [i].SetActive (false);
		}
	}

	public void MoveKnight(int x, int y){
		if (x == 0) {
			SettingY = -26.66f;
		} else if (x == 1) {
			SettingY = -27.99f;
		} else if (x == 2) {
			SettingY = -29.33f;
		} else if (x == 3) {
			SettingY = -30.6f;
		} else if (x == 4) {
			SettingY = -32f;
		} else if (x == 5) {
			SettingY = -33.33f;
		}

		if (y == 0) {
			SettingX = 26.7f;
		}else if (y == 1){
			SettingX = 27.99f;
		}else if (y == 2){
			SettingX = 29.32f;
		}else if (y == 3){
			SettingX = 30.7f;
		}else if (y == 4){
			SettingX = 32.01f;
		}else if (y == 5){
			SettingX = 33.35f;
		}
		this.GetComponent<AudioSource> ().Play ();
		Black_Knight.transform.localPosition = new Vector3 (SettingX, SettingY, 0);

		if(SettingX == 29.32f && SettingY == -27.99f){
			CheckMateImage.SetActive (true);
			Black_Knight.GetComponent<BoxCollider2D> ().enabled = false;

            clearImage.SetActive(true);
			CameraFollow cam_follow = Camera.main.GetComponent<CameraFollow>();

			cam_follow.FadeCoroutine(false, 0f);
			cam_follow.FadeCoroutine(true, 1f);
			cam_follow.CheckPuzzleOrPlayer(false);

			// 퍼즐 저장기능 해제  (Inventory.PuzzleGet[7] == false)
			if (Inventory.PuzzleGet[7] == true){
				GetComponent<PuzzleClear>().Clear();
			}
			player.saveZoneidx = 3;
		}
	}
}
