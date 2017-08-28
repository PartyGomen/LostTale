using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public static GameObject[] piece = new GameObject[9];

    public Image[] pieceImg = new Image[9];

    [TextArea]
    public string[] pieceStr = new string[9];

    public GameObject go;

    public void OffInven()
    {
        go.SetActive(false);
    }
}
