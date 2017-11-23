using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Mirror : MonoBehaviour
{
    public Laser laser;

    Vector3 pos;

    RaycastHit2D hit2d;

    public int check_count;
    int rot = 0;
    public int[] answer_count;
    public int index_number;

    private void Start()
    {
        rot = (int)this.transform.eulerAngles.z;
    }

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
                        check_count++;

                        if (check_count > 4)
                            check_count = 0;

                        rot += 90;
                        this.transform.eulerAngles = new Vector3(0, 0, rot);

                        for(int i = 0; i < answer_count.Length; i++)
                        {
                            if(answer_count[i] == check_count)
                            {
                                laser.reflected[index_number] = true;
                            }

                            else
                            {
                                laser.reflected[index_number + i] = false;
                            }
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
