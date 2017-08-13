using UnityEngine;
using System.Collections;

public class FallingPlatform : MonoBehaviour {

    public float delaytime;

    private Rigidbody2D rb2d;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.collider.CompareTag("Player"))

            if (coll.contacts[0].normal.x > -1f && coll.contacts[0].normal.x < 1f && coll.contacts[0].normal.y < -0.35f)
        {
            StartCoroutine(Platformfall());
        }
    }

    IEnumerator Platformfall()
    {
        yield return new WaitForSeconds(delaytime);
        rb2d.isKinematic = false;
        GetComponent<Collider2D>().isTrigger = true;
        Destroy(gameObject, 2f);
    }
}
