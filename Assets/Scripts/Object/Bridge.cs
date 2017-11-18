using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Bridge : MonoBehaviour
{
    public GameObject Obj;

    HingeJoint2D hinge;

    Vector3 pos;
    Vector3 startPos;
    Vector3 endPos;

    float distance;

    bool isClicked;
    [HideInInspector]
    public bool is_clear;

	void Start ()
    {
        hinge = GetComponent<HingeJoint2D>();
	}
	
	void Update ()
    {
        if (!IsPointerOverUIObject())
        {
            if (Input.GetMouseButtonDown(0))
            {
                pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

                RaycastHit2D hit = Physics2D.Raycast(pos, Vector2.zero, Mathf.Infinity);

                if(hit == true)
                {
                    if (hit.collider.name == "PaddleObj")
                    {
                        startPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                        isClicked = true;
                    }
                }
            }

            if (Input.GetMouseButtonUp(0) && isClicked == true)
            {
                endPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

                distance = startPos.x - endPos.x;

                if (distance > 1f)
                {
                    is_clear = true;
                    hinge.useMotor = true;
                    this.enabled = false;
                }
            }
        }
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
