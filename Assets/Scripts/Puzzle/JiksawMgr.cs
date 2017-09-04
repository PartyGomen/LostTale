using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JiksawMgr : MonoBehaviour
{
    public Jiksaw[] jiksawObj;

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
                if (hit.collider.gameObject.name == "JikSaw")
                {
                    Jiksaw jik = hit.collider.gameObject.GetComponent<Jiksaw>();

                    if (!jik.move[0])
                        hit.collider.gameObject.transform.Translate(Vector2.right * 1);
                    else if (!jik.move[1])
                        hit.collider.gameObject.transform.Translate(Vector2.left * 1);
                    else if (!jik.move[2])
                        hit.collider.gameObject.transform.Translate(Vector2.up * 1);
                    else if (!jik.move[3])
                        hit.collider.gameObject.transform.Translate(Vector2.down * 1);

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
