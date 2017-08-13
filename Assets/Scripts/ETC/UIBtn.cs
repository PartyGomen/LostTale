using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIBtn : MonoBehaviour
{
    Button[] btns = new Button[4];

    public GameObject inventory;

	void Start ()
    {
        btns = GetComponentsInChildren<Button>();
       
        btns[0].onClick.AddListener(() => Click());
        btns[1].onClick.AddListener(() => Click2());
        btns[2].onClick.AddListener(() => Click3());
        btns[3].onClick.AddListener(() => Click4());
    }

    void Click()
    {
        inventory.SetActive(true);
    }

    void Click2()
    {
        Debug.Log("2");
    }

    void Click3()
    {
        Debug.Log("3");
    }

    void Click4()
    {
        Debug.Log("4");
    }
}
