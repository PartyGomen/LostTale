using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rock : MonoBehaviour {

    public GameObject dropobj;

    public float t = 2f;

	void Update ()
    {
        t -= Time.deltaTime;

        if(t <= 0)
        {
            GameObject drop = (GameObject)Instantiate(dropobj, this.transform.position, Quaternion.identity);

            Destroy(drop, 2f);

            t = 2f;
        }
	}
}
