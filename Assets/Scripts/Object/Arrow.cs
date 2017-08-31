using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    Rigidbody2D rb2d;

    private void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.P))
        {
            //StartCoroutine(RotateObj());
            rb2d.AddForce(new Vector3(500, 0, 0));
        }
    }

    IEnumerator RotateObj()
    {
        this.transform.rotation = Quaternion.Euler(0, 0, 45);

        yield return new WaitForSeconds(0.5f);

        this.transform.rotation = Quaternion.Euler(0, 0, -45);
    }
}
