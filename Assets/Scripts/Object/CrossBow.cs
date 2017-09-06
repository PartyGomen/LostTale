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

	// Use this for initialization
	void Start ()
    {
        tr = this.transform.position;	
	}
	
	// Update is called once per frame
	void Update ()
    {
        t += Time.deltaTime;
        
        if (t > coolTime)
        {
            t = 0f;

            if(leftShot)
                Instantiate(arrow, new Vector3(tr.x - 1, tr.y, tr.z), this.transform.rotation);
           
            else
                Instantiate(arrow, new Vector3(tr.x + 1, tr.y, tr.z), this.transform.rotation);
        }
	}
}
