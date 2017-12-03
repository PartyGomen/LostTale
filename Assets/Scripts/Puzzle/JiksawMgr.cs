using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JiksawMgr : MonoBehaviour
{
    public Jiksaw[] jiksawObj;

    public float move_value;

    Vector3 pos;
    RaycastHit2D hit;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            hit = Physics2D.Raycast(pos, Vector2.zero, Mathf.Infinity);

            if (hit)
            { 
                if (hit.collider.gameObject.tag == "JikSaw")
                {
                    Jiksaw jik = hit.collider.gameObject.GetComponent<Jiksaw>();

                    if (!jik.move[0])
                        hit.collider.gameObject.transform.Translate(Vector2.right * 3.6f);
                    else if (!jik.move[1])
                        hit.collider.gameObject.transform.Translate(Vector2.left * 3.6f);
                    else if (!jik.move[2])
                        hit.collider.gameObject.transform.Translate(Vector2.up * 3f);
                    else if (!jik.move[3])
                        hit.collider.gameObject.transform.Translate(Vector2.down * 3f);

                    CheckBool();
                }
            }
        }
    }

    void CheckBool()
    {
       for(int i = 0; i < jiksawObj.Length; i++)
        {
            for(int j = 0; j < 4; j++)
            {
                jiksawObj[i].move[j] = false;
                jiksawObj[i].CheckRay();
            }
        }
    }
}
