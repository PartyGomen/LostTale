using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PuzzlePiece : MonoBehaviour
{
    public int piece_number;

    private float RotateSpeed = 5f;
    private float Radius = 0.5f;
    private float distance;
    private float _angle;
    private float scale_and_alpha = 1.0f;

    private Vector2 _centre;
    private Vector3 mouse_pos;
    private Vector3 thispos;

    private RaycastHit2D hit;

    public GameObject pos;

    public UI ui_panel;

    [HideInInspector]
    public bool isclicked;

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

            if(distance < 25f)
            {
                scale_and_alpha -= Time.deltaTime / 1.5f;

                if (scale_and_alpha >= 0)
                {
                    //this.transform.localScale = new Vector3(scale_and_alpha, scale_and_alpha, 1);
                    this.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, scale_and_alpha);
                }

                else
                {
                    Inventory.PuzzleGet[piece_number] = true;

                    for (int i = 0; i < Inventory.PuzzleGet.Length; i++)
                        Debug.Log(Inventory.PuzzleGet[i]);

                    this.gameObject.SetActive(false);
                }
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
