using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TidePuzzleShow : MonoBehaviour
{
    TideManager tideMgr;
    public GameObject tideBtn;

    RaycastHit2D hit;

    Vector3 pos;

    CameraFollow cam;

    float distance;
    public float playerDistance;

    public bool is_get_puzzle;

    GameObject target;

	void Start ()
    {
        cam = Camera.main.GetComponent<CameraFollow>();
        target = GameObject.FindGameObjectWithTag("Player");
        tideMgr = GameObject.Find("TideManager").GetComponent<TideManager>();

    }
	
	void Update ()
    {
        distance = Vector3.Distance(target.transform.position, this.gameObject.transform.position);

	    if(Input.GetMouseButtonDown(0) && distance < playerDistance)
        {
            pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            hit = Physics2D.Raycast(pos, Vector2.zero, Mathf.Infinity);

            if(hit)
            {
                if(hit.collider.gameObject == this.gameObject)
                {
                    for (int i = 0; i < cam.goPuzzele.Length; i++)
                    {
                        cam.goPuzzele[i] = false;
                    }

                    cam.goPuzzele[0] = true;
                    cam.FadeCoroutine(false, 0f);
                    cam.CheckPuzzleOrPlayer(true);
                    cam.FadeCoroutine(true, 1f);
                    Invoke("TideBtnSetActive", 1f);
                    tideMgr.StopAllCoroutines();

                    if(is_get_puzzle)
                    {
                        tideMgr.get_puzzle = true;
                    }

                    else
                    {
                        tideMgr.get_puzzle = false;
                    }
                }
            }
        }
	}

    void TideBtnSetActive()
    {
        tideBtn.SetActive(true);
    }
}
