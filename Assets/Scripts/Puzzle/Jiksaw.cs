using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jiksaw : MonoBehaviour
{
    RaycastHit2D[] ray = new RaycastHit2D[4];   //4방향 충돌체 검사
 
    public bool[] move = new bool[4];  //true일때 이동 가능

    private void Start()
    {
        CheckRay();   
    }

    public void CheckRay ()
    {
        ray[0] = Physics2D.Raycast(new Vector2(this.transform.position.x + 1.9f, this.transform.position.y), Vector2.right, 0.1f);
        ray[1] = Physics2D.Raycast(new Vector2(this.transform.position.x - 1.9f, this.transform.position.y), Vector2.left, 0.1f);
        ray[2] = Physics2D.Raycast(new Vector2(this.transform.position.x, this.transform.position.y + 1.8f), Vector2.up, 0.1f);
        ray[3] = Physics2D.Raycast(new Vector2(this.transform.position.x, this.transform.position.y - 1.8f), Vector2.down, 0.1f);

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
    }
}
