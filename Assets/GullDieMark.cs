using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GullDieMark : MonoBehaviour
{
	void Update ()
    {
        this.transform.Rotate(new Vector3(0, 0, 30) * Time.deltaTime);
    }
}
