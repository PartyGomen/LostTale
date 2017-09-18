using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tide : MonoBehaviour
{
    public int z;

    public GameObject moon;

    Quaternion target;
	
    public void Left()
    {
        z += 45;

        if (z > 360)
            z -= 360;

        StartCoroutine(RotateObj());
    }

    public void Right()
    {
        z -= 45;

        if (z < -180)
            z += 360;

        StartCoroutine(RotateObj());
    }

    IEnumerator RotateObj()
    {
        float t = 0.0f;

        while (t < 3f)
        {
            t += Time.deltaTime;

            target = Quaternion.Euler(0, 0, z);

            moon.transform.rotation = Quaternion.Slerp(moon.transform.rotation, target, Time.deltaTime * 1.5f);

            yield return null;
        }
    }
}
