using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PuzzleShow : MonoBehaviour
{
    [HideInInspector]
    public bool is_clicked;

    public int puzzleIdx;
    public int hint_idx;

    RaycastHit2D hit;

    Vector3 pos;

    CameraFollow cam;

    public float distance;
    public float max_distance;

    GameObject target;

    public PuzzleHint puzzle_hint;

    void Start()
    {
        cam = Camera.main.GetComponent<CameraFollow>();
        target = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        distance = Vector3.Distance(target.transform.position, this.gameObject.transform.position);

        if(!IsPointerOverUIObject())
        {
            if (Input.GetMouseButtonDown(0) && distance < max_distance)
            {
                pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

                hit = Physics2D.Raycast(pos, Vector2.zero, Mathf.Infinity);

                if (hit)
                {
                    if (hit.collider.gameObject == this.gameObject)
                    {
                        cam.goPuzzele[puzzleIdx] = true;
                        cam.CheckPuzzleOrPlayer(true);
                        cam.FadeCoroutine(false, 0f);
                        cam.FadeCoroutine(true, 1f);
                        puzzle_hint.hint_index = hint_idx;
                        is_clicked = true;
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
