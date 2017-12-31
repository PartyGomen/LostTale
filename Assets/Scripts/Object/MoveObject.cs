using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MoveObject : MonoBehaviour {

	public float MinPosition;
	public float MaxPosition;

	private GameObject target;
	public Vector3 pos;
    Vector3 offset;

    public float startPos;
    public float endPos;
    public float multiply;

    private float diff;

    AudioSource rockAudio;

    bool isDragging;

    private void Start()
    {
        rockAudio = GetComponent<AudioSource>();
    }

    void FixedUpdate()
    {
        if (!IsPointerOverUIObject())
        {
            if(Input.GetMouseButtonDown(0))
            {
                startPos = this.transform.position.x;

                CastRay();

                if(target == this.gameObject)
                {
                    isDragging = true;
                    offset = this.transform.position - pos;
                }
            }

            if (Input.GetMouseButton(0) && isDragging)
            {
                pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

                pos = new Vector3(Mathf.Clamp(pos.x, MinPosition, MaxPosition), pos.y, 0);

                diff = this.transform.position.x - pos.x;

                transform.Translate(Vector2.left * diff * multiply * Time.deltaTime);

                this.transform.position = new Vector3(Mathf.Clamp(this.transform.position.x, MinPosition, MaxPosition), this.transform.position.y, this.transform.position.z);

                //돌 소리 부분
                endPos = this.transform.position.x;

                if (0.5f < Mathf.Abs(startPos - endPos))
                {
                    if (rockAudio && !rockAudio.isPlaying)
                    {
                        startPos = this.transform.position.x;
                        rockAudio.Play();

                    }
                }

                //돌 소리 부분
            }

            if(Input.GetMouseButtonUp(0))
            {
                isDragging = false;
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