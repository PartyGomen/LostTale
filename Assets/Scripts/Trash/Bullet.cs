using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour
{
    public float speed;
    public float destroyt;

    public bool isright;

	void FixedUpdate ()
    {
        if (isright == false)
        {
            transform.Translate(Vector2.left * speed * Time.deltaTime);
            Destroy(this, destroyt);
        }

        if (isright == true)
        {
            transform.Translate(Vector2.right * speed * Time.deltaTime);
            Destroy(this, destroyt);
        }
	}
}
