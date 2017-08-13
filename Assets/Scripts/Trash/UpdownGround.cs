using UnityEngine;
using System.Collections;

public class UpdownGround : MonoBehaviour {

    public float upmax;
    public float downmax;
    public float speed;

    bool isup;

    void Update()
    {
        Move();
    }

    void Move()
    {
        if (this.transform.position.y < downmax)
        {
            isup = true;
        }
        else if (this.transform.position.y > upmax)
        {
            isup = false;
        }

        if (isup == true)
        {
            this.transform.Translate(Vector2.up * speed * Time.deltaTime, Space.World);
        }

        else if (isup == false)
        {
            this.transform.Translate(Vector2.down * speed * Time.deltaTime, Space.World);
        }
    }
}
