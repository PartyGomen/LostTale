using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pendulum : MonoBehaviour {

    LineRenderer linerenderer;
    public GameObject obj;
    Vector2 distance;
    Vector3 holdPoint;
    Ray ray;

	// Use this for initialization
	void Start ()
    {
        linerenderer = GetComponent<LineRenderer>();
        linerenderer.sortingOrder = -1;
        ray = new Ray(obj.transform.position, Vector3.zero);
	}
	
	// Update is called once per frame
	void Update ()
    {
        distance = -(this.transform.position - obj.transform.position);
        ray.direction = distance;
        holdPoint = ray.GetPoint(distance.magnitude);
        linerenderer.SetPosition(0, holdPoint);
        linerenderer.SetPosition(1, this.transform.position);
	}
}
