using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrossBow : MonoBehaviour
{
    float t;

    public GameObject arrow;
    public bool leftShot;
    public float coolTime;

    Vector3 tr;

    Animator anim;

	// Use this for initialization
	void Start ()
    {
        tr = this.transform.position;
        anim = GetComponent<Animator>();
        anim.SetTrigger("Check");
	}


	// Update is called once per frame
	void Update ()
    {
        if (!anim.GetCurrentAnimatorStateInfo(0).IsName("Cannon_Shot"))
        {
            if (leftShot)
                Instantiate(arrow, new Vector3(tr.x - 1, tr.y, tr.z), this.transform.rotation);

            else
                Instantiate(arrow, new Vector3(tr.x + 1, tr.y, tr.z), this.transform.rotation);

            anim.SetTrigger("Check");
        }
    }
}
