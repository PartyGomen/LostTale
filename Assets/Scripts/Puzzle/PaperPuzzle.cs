using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PaperPuzzle : MonoBehaviour
{
    public PaperManager paper_mgr;

    SpriteRenderer spriterender;

    public Sprite[] sprites;

    RaycastHit2D hit;

    Vector3 pos;

    public int idx;

	void Start ()
    {
        spriterender = GetComponent<SpriteRenderer>();	
	}
	
	void Update ()
    {
        spriterender.sprite = sprites[idx];

        if(!IsPointerOverUIObject())
        {
            if (Input.GetMouseButtonDown(0))
            {
                pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

                hit = Physics2D.Raycast(pos, Vector2.zero, Mathf.Infinity);

                if (hit)
                {
                    if (hit.collider.gameObject == this.gameObject)
                    {
                        idx++;

                        if (idx >= sprites.Length)
                        {
                            idx = 0;
                        }

                        paper_mgr.CheckClear();
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
