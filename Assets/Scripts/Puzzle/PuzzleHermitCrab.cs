using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleHermitCrab : MonoBehaviour
{
    enum STEP
    {
        IDLE,
        DRAGGING,
        FINISHED
    };

    STEP step = STEP.IDLE;

    bool isDragging;

    public int boolIndex;

    float sanpDistance = 0.5f;

    Animator anim;

    Vector3 mousePos;
    Vector3 offset;

    public GameObject finishedPos;

    RaycastHit2D hit;

    public PuzzleHermitCrabManager puzzleMgr;

    void Start ()
    {
        anim = GetComponent<Animator>();
	}

	// Update is called once per frame
	void Update ()
    {
	    if(Input.GetMouseButtonDown(0))
        {
            mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            hit = Physics2D.Raycast(mousePos, Vector2.zero, 0f);

            if(hit)
            {
                if(hit.collider.gameObject == this.gameObject)
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
            if(isDragging)
            {
                isDragging = false;
                anim.SetBool("IsOut", false);
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
                    if(isDragging)
                    {
                        mousePos.z = 0f;
                        offset.z = 0f;
                        this.transform.position = mousePos + offset;
                    }

                    else
                    {
                        if(IsSnap())
                        {
                            step = STEP.FINISHED;
                            puzzleMgr.check[boolIndex] = true;
                            puzzleMgr.CheckEnd();
                            this.GetComponent<SpriteRenderer>().sortingOrder = -5;
                            this.GetComponent<CircleCollider2D>().enabled = false;
                        }

                        else
                        {
                            step = STEP.IDLE;
                        }
                    }
                }
                break;
            case STEP.FINISHED:
                {
                    Vector3 next_position, distance, move;

                    // 속도감이 느껴지는 움직임이 되도록 한다.

                    distance = finishedPos.transform.position - this.transform.position;

                    // 다음 장소＝현재 장소와 목표위치의 중간지점.
                    distance *= 0.25f * (60.0f * Time.deltaTime);

                    next_position = this.transform.position + distance;

                    move = next_position - this.transform.position;

                    float snap_speed_min = 0.01f * 60.0f * Time.deltaTime;
                    float snap_speed_max = 0.8f * 60.0f * Time.deltaTime;

                    if (move.magnitude < snap_speed_min)
                    {

                        // 이동량이 일정 이하가 되면 종료.
                        // 목표위치로 이동시킨다. 
                        // 종료판정은 상태변화 점검에서 실행되므로 여기에서는 위치 조정만 실행한다.
                        // 
                        this.transform.position = finishedPos.transform.position;

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

        if(Vector3.Distance(this.transform.position, finishedPos.transform.position) < sanpDistance)
        {
            result = true;
        }

        return (result);
    }
}
