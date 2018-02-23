﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GullDieMark : MonoBehaviour
{
    public float speed;

	void Update ()
    {
        this.transform.Rotate(new Vector3(0, 0, speed) * Time.deltaTime);
    }
}