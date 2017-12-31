using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CoconutTree : MonoBehaviour
{
    Vector3 objPos;

    public float minY;
    public float maxY;
    public float multiply;

    private float diff;
    private float end_pos;
    private float start_pos;

    bool isDragging;
	
	// Update is called once per frame
	void Update ()
    {
        if (!IsPointerOverUIObject())
        {
            if (Input.GetMouseButtonDown(0))
            {
                objPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

                RaycastHit2D hit = Physics2D.Raycast(objPos, Vector2.zero, Mathf.Infinity);

                if (hit == true)
                {
                    if (hit.collider.gameObject == this.gameObject)
                    {
                        isDragging = true;

                        start_pos = this.transform.position.y;
                    }
                }
            }

            if (Input.GetMouseButton(0) && isDragging == true)
            {
                objPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

                objPos = new Vector3(objPos.x, Mathf.Clamp(objPos.y, minY, maxY), 0);

                diff = this.transform.position.y - objPos.y;

                transform.Translate(Vector2.down * diff * multiply * Time.deltaTime);

                this.transform.position = new Vector3(this.transform.position.x, Mathf.Clamp(this.transform.position.y, minY, maxY), this.transform.position.z);

                end_pos = this.transform.position.y;

                if (0.5f < Mathf.Abs(start_pos - end_pos))
                {
                    if (GetComponent<AudioSource>().isPlaying == false)
                    {
                        GetComponent<AudioSource>().Play();

                        start_pos = this.transform.position.y;
                    }
                }
            }

			if (Input.GetMouseButtonUp (0)) 
			{
				isDragging = false;
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
