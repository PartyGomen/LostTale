using UnityEngine;
using System.Collections;

public class MovingObj : MonoBehaviour {

    Vector3 pos;

    public float leftmax;
    public float rightmax;
    public float speed;

    public bool isright;
    public bool changeScale;

    public float angle;

    private void Start()
    {
        pos = this.transform.localScale;
    }

    void Update()
    {
        Move();
    }

	void Move ()
    {
        if(this.transform.position.x < leftmax)
        {
            isright = true;

            if(changeScale)
                this.transform.localScale = pos;
        }
        else if(this.transform.position.x > rightmax)
        {
            isright = false;

            if(changeScale)
                this.transform.localScale = new Vector3(-pos.x, pos.y, pos.z);
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
