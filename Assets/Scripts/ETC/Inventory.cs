using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public GameObject go;

    public void OffInven()
    {
        go.SetActive(false);
    }
	
}
