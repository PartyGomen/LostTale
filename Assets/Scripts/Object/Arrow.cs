using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    Rigidbody2D rb2d;

    public bool leftshot;

    private void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();

        if(leftshot)
            rb2d.AddForce(new Vector3(-200, 50, 0));
        else
            rb2d.AddForce(new Vector3(200, 50, 0));
    }

    IEnumerator RotateObj()
    {
        this.transform.rotation = Quaternion.Euler(0, 0, 45);

        yield return new WaitForSeconds(0.5f);

        this.transform.rotation = Quaternion.Euler(0, 0, -45);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Ground"))
        {
            Destroy(this.gameObject);
        }
    }
}
