using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PasswordObj : MonoBehaviour
{
    public GameObject Panel;

    public Sprite[] sprites = new Sprite[2];

    void OnTriggerEnter2D(Collider2D coll)
    {
        if(coll.CompareTag("Player"))
        {
            Panel.SetActive(true);
            GameObject Go = GameObject.Find("MobileControls");
            Go.SetActive(false);
        }
    }
}
