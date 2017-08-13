using UnityEngine;
using System.Collections;

public class MovingObj : MonoBehaviour {

    public float leftmax;
    public float rightmax;
    public float speed;

    bool isright;

    public float angle;

    void Update()
    {
        Move();
    }

	void Move ()
    {
        if(this.transform.position.x < leftmax)
        {
            isright = true;
        }
        else if(this.transform.position.x > rightmax)
        {
            isright = false;
        }

        if (isright == true)
        {
            this.transform.Translate(Vector2.right * speed * Time.deltaTime, Space.World);
            this.transform.Rotate(new Vector3(0, 0, -angle) * Time.deltaTime);
        }

        else if (isright == false)
        {
            this.transform.Translate(Vector2.left * speed * Time.deltaTime, Space.World);
            this.transform.Rotate(new Vector3(0, 0, angle) * Time.deltaTime);
        }
	}
}
