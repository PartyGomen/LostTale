using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jiksaw : MonoBehaviour
{
    RaycastHit2D[] ray = new RaycastHit2D[4];   //4방향 충돌체 검사
    RaycastHit2D hit; //마우스 레이캐스트
 
    public bool[] move = new bool[4];  //true일때 이동 가능

    Vector3 pos;
    
	void Update ()
    {
        ray[0] = Physics2D.Raycast(new Vector2(this.transform.position.x + 0.55f, this.transform.position.y), Vector2.right, 0.1f);
        ray[1] = Physics2D.Raycast(new Vector2(this.transform.position.x - 0.55f, this.transform.position.y), Vector2.left, 0.1f);
        ray[2] = Physics2D.Raycast(new Vector2(this.transform.position.x, this.transform.position.y + 0.55f), Vector2.up, 0.1f);
        ray[3] = Physics2D.Raycast(new Vector2(this.transform.position.x, this.transform.position.y - 0.55f), Vector2.down, 0.1f);

        if (ray[0])
        {
            if (ray[0].collider.gameObject != this.gameObject)
            {
                move[0] = true;
            }

            else
                move[0] = false;
        }

        if (ray[1])
        {
            if (ray[1].collider.gameObject != this.gameObject)
            {
                move[1] = true;
            }

            else
                move[1] = false;
        }

        if (ray[2])
        {
            if (ray[2].collider.gameObject != this.gameObject)
            {
                move[2] = true;
            }

            else
                move[2] = false;
        }

        if (ray[3])
        {
            if (ray[3].collider.gameObject != this.gameObject)
            {
                move[3] = true;
            }

            else
                move[3] = false;
        }

        if(Input.GetMouseButtonDown(0))
        {
            pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            hit = Physics2D.Raycast(pos, Vector2.zero, Mathf.Infinity);

            if(hit)
            {
                if(hit.collider.gameObject == this.gameObject)
                {
                    if (!move[0])
                        this.transform.Translate(Vector2.right * 1);
                    else if (!move[1])
                        this.transform.Translate(Vector2.left * 1);
                    else if (!move[2])
                        this.transform.Translate(Vector2.up * 1);
                    else if (!move[3])
                        this.transform.Translate(Vector2.down * 1);

                    for(int i = 0; i<4; i++)
                    {
                        move[i] = false;
                    }
                }
            }
        }
    }
}
