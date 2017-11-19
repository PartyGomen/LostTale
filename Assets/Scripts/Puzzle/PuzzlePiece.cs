using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PuzzlePiece : MonoBehaviour
{
    private float RotateSpeed = 5f;
    private float Radius = 1f;
    private float distance;

    private Vector2 _centre;
    private Vector3 mouse_pos;
    private Vector3 thispos;
    private float _angle;

    private RaycastHit2D hit;

    public GameObject pos;

    public UI ui_panel;

    bool isclicked;

    private void Start()
    {
        _centre = transform.position;
    }

    private void Update()
    {
        if(!isclicked)
        {
            _angle += RotateSpeed * Time.deltaTime;


            var offset = new Vector2(Mathf.Sin(_angle), Mathf.Cos(_angle)) * Radius;
            transform.position = _centre + offset;
        }
        
        else
        {
            thispos = Vector3.Lerp(this.transform.position, pos.transform.position, 1 * Time.deltaTime);

            this.transform.position = thispos;

            distance = Vector3.Distance(this.transform.position, pos.transform.position);

            if(distance < 8f)
            {
                this.gameObject.SetActive(false);
            }
        }

        if(Input.GetMouseButtonDown(0) && !IsPointerOverUIObject())
        {
            mouse_pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            hit = Physics2D.Raycast(mouse_pos, Vector2.zero, Mathf.Infinity);

            if (hit == true)
            {
                if (hit.collider.gameObject == this.gameObject.gameObject)
                {
                    if(ui_panel.isOn == false)
                    {
                        ui_panel.OnCoroutine();
                        ui_panel.isOn = true;
                    }

                    isclicked = true;
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
