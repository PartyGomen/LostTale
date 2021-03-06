﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TidePuzzleShow : MonoBehaviour
{
    public PuzzleHint puzzle_hint;

    TideManager tideMgr;
    public GameObject tideBtn;

    RaycastHit2D hit;

    Vector3 pos;

    CameraFollow cam;

    float distance;
    public float playerDistance;

    public int hint_idx;

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

        if(!IsPointerOverUIObject())
        {
            if (Input.GetMouseButtonDown(0) && distance < playerDistance)
            {
                pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

                hit = Physics2D.Raycast(pos, Vector2.zero, Mathf.Infinity);

                if (hit)
                {
                    if (hit.collider.gameObject == this.gameObject)
                    {
                        for (int i = 0; i < cam.goPuzzele.Length; i++)
                        {
                            cam.goPuzzele[i] = false;
                        }

                        cam.goPuzzele[0] = true;
                        cam.FadeCoroutine(false, 0f);
                        cam.CheckPuzzleOrPlayer(true);
                        cam.FadeCoroutine(true, 1f);
                        puzzle_hint.hint_index = hint_idx;
                        Invoke("TideBtnSetActive", 1f);
                        tideMgr.StopAllCoroutines();

                        if (is_get_puzzle)
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
	}

    void TideBtnSetActive()
    {
        tideBtn.SetActive(true);
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
