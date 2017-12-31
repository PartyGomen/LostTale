using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PianoKey : MonoBehaviour
{
    public string key;

    SpriteRenderer sprite;

    public GameObject[] notes;
	public GameObject PianoManager;

    int random_value;

    float time;
    float random_x;
    float random_y;

    RaycastHit2D hit;

    Vector3 mouse_pos;

    public PianoPuzzleManager piano_manager;
	//public AudioClip[] PianoSound;


	//public static bool IsOpenPuzzle = false;

    void Start ()
    {
        sprite = GetComponent<SpriteRenderer>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        //if (GameObject.Find("Main Camera").GetComponent<Transform>().transform.localPosition.x == 30.0f && IsOpenPuzzle == false)
        //{
        //    GameObject.Find("Main Camera").GetComponent<AudioSource>().volume = 0.25f;
        //    IsOpenPuzzle = true;
        //}
        //else if (GameObject.Find("Main Camera").GetComponent<Transform>().transform.localPosition.x != 30.0f && IsOpenPuzzle == true)
        //{
        //    GameObject.Find("Main Camera").GetComponent<AudioSource>().volume = 0.5f;
        //    IsOpenPuzzle = false;
        //}

        if (Input.GetMouseButtonDown(0))
        {
            mouse_pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            hit = Physics2D.Raycast(mouse_pos, Vector2.zero, Mathf.Infinity);

            if(hit)
            {
                if(hit.collider.gameObject == this.gameObject)
                {
                    GetComponent<AudioSource>().Play();

					//if (key == "C") {
					//	PianoManager.GetComponent<AudioSource> ().clip = PianoSound [0];
					//	PianoManager.GetComponent<AudioSource> ().volume = 1.0f;
					//	PianoManager.GetComponent<AudioSource> ().Play ();
					//}else if(key == "D"){
					//	PianoManager.GetComponent<AudioSource> ().clip = PianoSound [1];
					//	PianoManager.GetComponent<AudioSource> ().volume = 1.0f;
					//	PianoManager.GetComponent<AudioSource> ().Play ();
					//}else if(key == "E"){
					//	PianoManager.GetComponent<AudioSource> ().clip = PianoSound [2];
					//	PianoManager.GetComponent<AudioSource> ().volume = 1.0f;
					//	PianoManager.GetComponent<AudioSource> ().Play ();
					//}else if(key == "F"){
					//	PianoManager.GetComponent<AudioSource> ().clip = PianoSound [3];
					//	PianoManager.GetComponent<AudioSource> ().volume = 1.0f;
					//	PianoManager.GetComponent<AudioSource> ().Play ();

					//}else if(key == "G"){
					//	PianoManager.GetComponent<AudioSource> ().clip = PianoSound [4];
					//	PianoManager.GetComponent<AudioSource> ().volume = 1.0f;
					//	PianoManager.GetComponent<AudioSource> ().Play ();
					//}else if(key == "A"){
					//	PianoManager.GetComponent<AudioSource> ().clip = PianoSound [5];
					//	PianoManager.GetComponent<AudioSource> ().volume = 1.0f;
					//	PianoManager.GetComponent<AudioSource> ().Play ();
					//}else if(key == "B"){
					//	PianoManager.GetComponent<AudioSource> ().clip = PianoSound [6];
					//	PianoManager.GetComponent<AudioSource> ().volume = 0.2f;
					//	PianoManager.GetComponent<AudioSource> ().Play ();
					//}


                    sprite.color = new Color32(200, 200, 200, 255);
                    Invoke("ColorBack", 0.2f);
                    random_value = Random.Range(0, notes.Length);
                    random_x = Random.Range(20.0f, 40.0f);
                    random_y = Random.Range(-25.0f, -35.0f);
                    Instantiate(notes[random_value], new Vector3(random_x, random_y, 0), Quaternion.identity);
                    piano_manager.EnterKey(key);
                }
            }
        }
	}

    void ColorBack()
    {
        sprite.color = new Color(1, 1, 1, 1);
    }

    bool IsPointerOverUIObject()
    {
        // Referencing this code for GraphicRaycaster 
        // https://gist.github.com/stramit/ead7ca1f432f3c0f181f
        // the ray cast appears to require only eventData.position.
        PointerEventData eventDataCurrentPosition
            = new PointerEventData(EventSystem.current);
        eventDataCurrentPosition.position
            = new Vector2(Input.mousePosition.x, Input.mousePosition.y);

        List<RaycastResult> results = new List<RaycastResult>();
        EventSystem.current.RaycastAll(eventDataCurrentPosition, results);
        return results.Count > 0;
    }
}
