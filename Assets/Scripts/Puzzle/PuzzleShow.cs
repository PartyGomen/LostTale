using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleShow : MonoBehaviour
{
    public int puzzleIdx;

    RaycastHit2D hit;

    Vector3 pos;

    CameraFollow cam;

    float distance;

    GameObject target;

    void Start()
    {
        cam = Camera.main.GetComponent<CameraFollow>();
        target = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        distance = Vector3.Distance(target.transform.position, this.gameObject.transform.position);

        if (Input.GetMouseButtonDown(0) && distance < 6.5)
        {
            pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            hit = Physics2D.Raycast(pos, Vector2.zero, Mathf.Infinity);

            if (hit)
            {
                if (hit.collider.gameObject == this.gameObject)
                {
                    for (int i = 0; i < cam.goPuzzele.Length; i++)
                    {
                        cam.goPuzzele[i] = false;
                    }

                    cam.goPuzzele[puzzleIdx] = true;
                    cam.CheckPuzzle();
                }
            }
        }
    }
}
