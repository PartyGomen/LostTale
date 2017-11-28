using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleClear : MonoBehaviour
{
    public GameObject piece_object;

    public void Clear()
    {
        piece_object.SetActive(true);
    }
}
