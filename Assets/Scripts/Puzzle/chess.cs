using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Chess : MonoBehaviour
{
    public Transform[] canMove;

    Vector3 pos;

    RaycastHit2D hit;

	// Use this for initialization
	void Start ()
    {
        canMove = GetComponentsInChildren<Transform>(true);	
	}
	
	// Update is called once per frame
	void Update ()
    {
        if(!IsPointerOverUIObject())
        {
            if (Input.GetMouseButtonDown(0))
            {
                pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

                hit = Physics2D.Raycast(pos, Vector2.zero, Mathf.Infinity);

                if (hit)
                {
                    if (hit.collider.name == "ChessPiece")
                    {
                        for (int i = 1; i < canMove.Length; i++)
                        {
                            if (canMove[i].transform.position.x > 5 || canMove[i].transform.position.y > 5)
                                continue;

                            canMove[i].gameObject.SetActive(true);
                        }
                    }

                    if (hit.collider.name == "Move")
                    {
                        this.transform.position = hit.collider.transform.position;

                        for (int i = 1; i < canMove.Length; i++)
                        {
                            canMove[i].gameObject.SetActive(false);
                        }
                    }
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
