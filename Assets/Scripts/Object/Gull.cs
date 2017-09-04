using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gull : MonoBehaviour
{
    public Transform[] go;

	// Use this for initialization
	void Start ()
    {
        go = GetComponentsInChildren<Transform>();	
	}
	
	// Update is called once per frame
	void Update ()
    {
        this.transform.Rotate(new Vector3(0, 0, 30) * Time.deltaTime);

        for(int i = 1; i < go.Length; i++)
        {
            go[i].transform.Rotate(new Vector3(0, 0, -30) * Time.deltaTime);
        }
    }
}
