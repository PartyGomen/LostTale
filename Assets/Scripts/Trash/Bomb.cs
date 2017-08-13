using UnityEngine;
using System.Collections;

public class Bomb : MonoBehaviour
{

    Rigidbody2D rb;

    public GameObject gameob;

    public float power;
    public float speed;
    public float destroyT;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Destroy(this.gameObject, destroyT);
    }

    void Update()
    {
        gameob.transform.Rotate(0, 0, 10);
        this.transform.Translate(Vector2.left * speed * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        Jump();
    }

    void Jump()
    {
        rb.velocity = Vector3.zero;
        rb.AddForce(Vector2.up * power, ForceMode2D.Impulse);
    }
}