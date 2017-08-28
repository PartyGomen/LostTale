using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisapperGround : MonoBehaviour
{
    public SpriteRenderer[] sprites;

    private void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.CompareTag("Player") && coll.contacts[0].normal.x > -1f && coll.contacts[0].normal.x < 1f && coll.contacts[0].normal.y < -0.35f)
        {
            Camera.main.orthographicSize = 8;

            for (int i = 0; i < sprites.Length; i++)
            {
                sprites[i].enabled = true;
            }
        }
    }

    private void OnCollisionExit2D(Collision2D coll)
    {
        if (coll.gameObject.CompareTag("Player"))
        {
            Camera.main.orthographicSize = 6;

            for (int i = 0; i < sprites.Length; i++)
            {
                sprites[i].enabled = false;
            }
        }
    }
}
