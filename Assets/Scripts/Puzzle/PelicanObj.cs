using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PelicanObj : MonoBehaviour
{
    public int weight;

    PelicanMgr pelmgr;

    RaycastHit2D hit;

    Vector3 startPos;
    Vector3 pos;
    Vector3 offset;

    bool isDragging;

    enum STEP
    {
        IDLE,
        DRAGGING,
        FINISHED
    };

    private STEP step = STEP.IDLE;

	void Start ()
    {
        pelmgr = GameObject.Find("Pel").GetComponent<PelicanMgr>();
        startPos = this.transform.position;
	}

    private void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            hit = Physics2D.Raycast(pos, Vector2.zero, Mathf.Infinity);

            if(hit)
            {
                if(hit.collider.gameObject == this.gameObject)
                {
                    isDragging = true;
                    offset = this.transform.position - pos;
                }
            }
        }

        if(Input.GetMouseButton(0))
        {
            pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }

        if(Input.GetMouseButtonUp(0))
        {
            isDragging = false;
        }

        switch (step)
        {
            case STEP.IDLE:
                {
                    if (isDragging)
                        step = STEP.DRAGGING;
                }
                break;

            case STEP.DRAGGING:
                {
                    if(isDragging)
                    {
                        pos.z = 0;
                        offset.z = 0;
                        this.transform.position = pos + offset;
                    }

                    else
                    {
                        step = STEP.IDLE;
                    }
                }
                break;

            case STEP.FINISHED:
                {
                    isDragging = false;
                    step = STEP.IDLE;
                    this.transform.position = startPos;
                    this.gameObject.SetActive(false);
                }
                break;
        }
    }

    void ActiveFalse()
    {
        this.gameObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D coll)
    {
        if(coll.gameObject.name == "Pelican1")
        {
            Animator anim = coll.gameObject.GetComponent<Animator>();
            anim.SetTrigger("Eat");
            pelmgr.Object1AddWeight(weight);
            step = STEP.FINISHED;
        }

        else if(coll.gameObject.name == "Pelican2")
        {
            Animator anim = coll.gameObject.GetComponent<Animator>();
            anim.SetTrigger("Eat");
            pelmgr.Object2AddWeight(weight);;
            step = STEP.FINISHED;
        }
    }
}
