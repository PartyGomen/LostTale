﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PuzzleHermitCrab : MonoBehaviour
{
    enum STEP
    {
        IDLE,
        DRAGGING,
        SNAPPING
    };

    STEP step = STEP.IDLE;

    bool isDragging;

    public int[] bool_index;
    private int for_index = 0;
    int posIdx;

    float sanpDistance = 1f;

    Animator anim;

    Vector3 mousePos;
    Vector3 offset;

    public GameObject[] finish_pos;
    public GameObject[] checkPos = new GameObject[5];

    RaycastHit2D hit;

    public PuzzleHermitCrabManager puzzleMgr;

    void Start ()
    {
        anim = GetComponent<Animator>();
	}

	// Update is called once per frame
	void Update ()
    {
        if(!IsPointerOverUIObject())
        {
            if (Input.GetMouseButtonDown(0))
            {
                mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

                hit = Physics2D.Raycast(mousePos, Vector2.zero, 0f);

                if (hit)
                {
                    if (hit.collider.gameObject == this.gameObject)
                    {
                        isDragging = true;
                        anim.SetBool("IsOut", true);
                        offset = transform.position - mousePos;
                    }
                }
            }

            if (Input.GetMouseButton(0))
                mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            if (Input.GetMouseButtonUp(0))
            {
                if (isDragging)
                {
                    isDragging = false;
                    anim.SetBool("IsOut", false);
                }
            }
        }

        switch (step)
        {
            case STEP.IDLE:
                {
                    if(isDragging)
                    {
                        step = STEP.DRAGGING;
                    }
                }
                break;

            case STEP.DRAGGING:
                {
                    puzzleMgr.check[bool_index[for_index]] = false;

                    if (isDragging)
                    {
                        mousePos.z = 0f;
                        offset.z = 0f;
                        this.transform.position = mousePos + offset;
                    }

                    else
                    {
                        if(IsSnap())
                        {
                            step = STEP.SNAPPING;
                        }

                        else
                        {
                            step = STEP.IDLE;
                        }
                    }
                }
                break;

            case STEP.SNAPPING:
                {
                    Vector3 next_position, distance, move;

                    // 속도감이 느껴지는 움직임이 되도록 한다.
                    distance = checkPos[posIdx].transform.position - this.transform.position;

                    // 다음 장소＝현재 장소와 목표위치의 중간지점.
                    distance *= 0.25f * (60.0f * Time.deltaTime);
					move = distance;

                    next_position = this.transform.position + distance;
					

                    float snap_speed_min = 0.01f * 60.0f * Time.deltaTime;
                    float snap_speed_max = 0.8f * 60.0f * Time.deltaTime;

                    if (move.magnitude < snap_speed_min)
                    {
                        this.transform.position = checkPos[posIdx].transform.position;

                        step = STEP.IDLE;

                        IsFinish();

                        if(IsFinish())
                        {
                            puzzleMgr.check[bool_index[for_index]] = true;
                            puzzleMgr.CheckEnd();
                        }
                    }

                    else
                    {
                        // 이동 속도가 너무 빠르면 조정한다.
                        if (move.magnitude > snap_speed_max)
                        {

                            move *= snap_speed_max / move.magnitude;

                            next_position = this.transform.position + move;
                        }

                        this.transform.position = next_position;
                    }
                    
                }
                break;
        }

	}

    bool IsSnap()
    {
        bool result = false;

        for(int i = 0; i < checkPos.Length; i++)
        {
            if (Vector3.Distance(this.transform.position, checkPos[i].transform.position) < sanpDistance)
            {
                result = true;
                posIdx = i;
            }
        }

        return (result);
    }

    bool IsFinish()
    {
        bool result = false;

        for(int i = 0; i < finish_pos.Length; i++)
        {
            if(Vector3.Distance(this.transform.position, finish_pos[i].transform.position) < 1f)
            {
                for_index = i;
                result = true;
            }
        }

        return result;
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
