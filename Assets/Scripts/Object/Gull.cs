using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gull : MonoBehaviour
{
    public Transform[] go;

    MovingObj moveobj;

	// Use this for initialization
	void Start ()
    {
        go = GetComponentsInChildren<Transform>();
        moveobj = GetComponent<MovingObj>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        this.transform.Rotate(new Vector3(0, 0, 30) * Time.deltaTime);

        for(int i = 1; i < go.Length; i++)
        {
            go[i].transform.Rotate(new Vector3(0, 0, -30) * Time.deltaTime);
        }

        if(moveobj.isright)
        {
            for (int i = 1; i < go.Length; i++)
            {
                go[i].transform.localScale = new Vector3(-1, 1, 1);
            }
        }
        else
        {
            for (int i = 1; i < go.Length; i++)
            {
                go[i].transform.localScale = new Vector3(1, 1, 1);
            }
        }
    }
}
