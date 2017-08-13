using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MoveObject : MonoBehaviour {

	public float MinPosition;
	public float MaxPosition;

	private GameObject target;
	public Vector2 pos;

    public float startPos;
    public float endPos;

    AudioSource rockAudio;

    private void Start()
    {
        rockAudio = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (!IsPointerOverUIObject())
        {
            if(Input.GetMouseButtonDown(0))
            {
                startPos = this.transform.position.x;
            }

            if (Input.GetMouseButton(0))
            {
                CastRay();
                if (target == this.gameObject)
                {
                    pos.x = Mathf.Clamp(pos.x, MinPosition, MaxPosition);
                    pos.y = this.transform.position.y;
                    //	pos = new Vector2(Mathf.Clamp ( MinPosition.transform.position.x, MaxPosition.transform.position.x), MinPosition.transform.position.y);
                    this.gameObject.transform.position = pos;
                    endPos = this.transform.position.x;

                    if (0.2f < Mathf.Abs(startPos - endPos))
                    {
                        if (!rockAudio.isPlaying)
                        {
                            rockAudio.Play();
                        }
                        startPos = this.transform.position.x;
                    }
                }
            }
        }
    }

    void CastRay()
    {
        target = null;
        pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(pos, Vector2.zero, 0f);

        if (hit.collider != null)
        {
            target = hit.collider.gameObject;
        }
    }

    bool IsPointerOverUIObject()
    {
        // Referencing this code for GraphicRaycaster 
        // https://gist.github.com/stramit/ead7ca1f432f3c0f181f
        // the ray cast appears to require only eventData.position.
        PointerEventData eventDataCurrentPosition = new PointerEventData(EventSystem.current);
        eventDataCurrentPosition.position = new Vector2(Input.mousePosition.x, Input.mousePosition.y);

        List<RaycastResult> results = new List<RaycastResult>();
        EventSystem.current.RaycastAll(eventDataCurrentPosition, results);
        return results.Count > 0;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.transform.SetParent(this.transform);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.transform.SetParent(null);
        }
    }
}