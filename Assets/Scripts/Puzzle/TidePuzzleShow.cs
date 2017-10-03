﻿using System.Collections;
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

	    if(Input.GetMouseButtonDown(0) && distance < 6.5)
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
                    cam.CheckPuzzle();
                    tideBtn.SetActive(true);
                    tideMgr.StopAllCoroutines();
                }
            }
        }
	}
}