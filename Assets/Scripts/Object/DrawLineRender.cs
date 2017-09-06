using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawLineRender: MonoBehaviour
{
    LineRenderer line;

    Transform tr;
    public Transform objtr;

	void Start ()
    {
        line = GetComponent<LineRenderer>();
        tr = GetComponent<Transform>();
        line.sortingOrder = -2;
	}
	
	// Update is called once per frame
	void Update ()
    {
        line.SetPosition(0, tr.position);
        line.SetPosition(1, objtr.position);
	}
}
