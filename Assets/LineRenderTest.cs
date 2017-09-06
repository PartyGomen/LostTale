using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawLine: MonoBehaviour
{
    LineRenderer line;

    Transform tr;
    public Transform objtr;

	void Start ()
    {
        line = GetComponent<LineRenderer>();
        tr = GetComponent<Transform>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        line.SetPosition(0, tr.position);
        line.SetPosition(1, objtr.position);
	}
}
