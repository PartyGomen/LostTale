using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Mirror : MonoBehaviour
{
    Vector3 pos;

    RaycastHit2D hit2d;

    int rot = 0;
	
	// Update is called once per frame
	void Update ()
    {
        if(!IsPointerOverUIObject())
        {
            if (Input.GetMouseButtonDown(0))
            {
                pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

                hit2d = Physics2D.Raycast(pos, Vector2.zero, Mathf.Infinity);

                if(hit2d)
                {
                    if (hit2d.collider.gameObject == this.gameObject)
                    {
                        rot += 90;
                        this.transform.eulerAngles = new Vector3(0, 0, rot);
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
