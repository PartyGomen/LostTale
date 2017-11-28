﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Password : MonoBehaviour {

    int one, two, three, four;
    public Text[] num = new Text[4];
    public int[] answer = new int[4];

    public GameObject obj;
    public GameObject control;

    PasswordObj passwordObj;

	void Start ()
    {
        one = 0;
        two = 0;
        three = 0;
        four = 0;
	}
	
	void Update ()
    {
        num[0].text = one.ToString();
        num[1].text = two.ToString();
        num[2].text = three.ToString();
        num[3].text = four.ToString();

        passwordObj = GameObject.Find("PassWordObj").GetComponent<PasswordObj>();
    }

    void CheckCorret()
    {
        if (one == answer[0] && two == answer[1] && three == answer[2] && four == answer[3])
        {
			//Inventory.GetPuzzle2 ();
            GameObject Go = GameObject.Find("PassWordPanel");
            Go.SetActive(false);
            passwordObj.GetComponent<SpriteRenderer>().sprite = passwordObj.sprites[1];
            passwordObj.GetComponent<BoxCollider2D>().enabled = false;
            control.SetActive(true);
            obj.SetActive(true);
            GetComponent<PuzzleClear>().Clear();
        }
    }

    public void Off()
    {
        GameObject go = GameObject.Find("PassWordPanel");
        if(go != null)
            go.SetActive(false);
        one = 0;
        two = 0;
        three = 0;
        four = 0;
        control.SetActive(true);
    }

    public void AddOne ()
    {
        one++;
        if (one > 9)
            one = 0;

        CheckCorret();
    }

    public void SubOne()
    {
        one--;
        if (one < 0)
            one = 9;

        CheckCorret();
    }

    public void AddTwo()
    {
        two++;
        if (two > 9)
            two = 0;

        CheckCorret();
    }

    public void SubTwo()
    {
        two--;
        if (two < 0)
            two = 9;

        CheckCorret();
    }

    public void AddThree()
    {
        three++;
        if (three > 9)
            three = 0;

        CheckCorret();
    }

    public void SubThree()
    {
        three--;
        if (three < 0)
            three = 9;

        CheckCorret();
    }

    public void AddFour()
    {
        four++;
        if (four > 9)
            four = 0;

        CheckCorret();
    }

    public void SubFour()
    {
        four--;
        if (four < 0)
            four = 9;

        CheckCorret();
    }
}
