using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CoconutTree : MonoBehaviour
{
    Vector3 objPos;
    Vector3 pos;
    Vector3 offset;

    public float minY;
    public float maxY;

    bool isDragging;
	
	// Update is called once per frame
	void Update ()
    {
        if (!IsPointerOverUIObject())
        {

            if (Input.GetMouseButtonDown(0))
            {
                pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

                RaycastHit2D hit = Physics2D.Raycast(pos, Vector2.zero, Mathf.Infinity);

                if (hit == true)
                {
                    if (hit.collider.gameObject == this.gameObject)
                    {
                        offset = this.transform.position - pos;

                        isDragging = true;
                    }
                }
            }

            if (Input.GetMouseButton(0) && isDragging == true)
            {
                objPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                
                objPos.x = this.transform.position.x;
                objPos.y += offset.y;
                objPos.y = Mathf.Clamp(objPos.y, minY, maxY);
                objPos.z = 0;

                this.transform.position = objPos;
				this.GetComponent<AudioSource> ().Play ();
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
