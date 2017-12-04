using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Mirror : MonoBehaviour
{
    public Laser laser;

    Vector3 pos;

    RaycastHit2D hit2d;

    int rot = 0;

    //생각해보자
    public int[] answer_number;
    public int[] idx_number;
    public int check_number;
        
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
                        check_number++;

                        if (check_number > 4)
                            check_number = 1;

                        rot += 90;
                        this.transform.eulerAngles = new Vector3(0, 0, rot);

                        for(int i = 0; i < answer_number.Length; i ++)
                        {
                            if(answer_number[i] == check_number)
                            {
                                laser.reflected[idx_number[i]] = true;
                            }

                            else
                            {
                                laser.reflected[idx_number[i]] = false;
                            }
                        }

                        laser.CheckClear();
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
