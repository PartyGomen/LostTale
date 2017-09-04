using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PelicanMgr : MonoBehaviour
{
    Vector3 pos;
    Vector3 go1Pos;
    Vector3 go2Pos;
    Vector3 startGo1Pos;
    Vector3 startGo2Pos;

    public int weight1;
    public int weight2;

    public GameObject go1;
    public GameObject go2;
    GameObject[] fishes;
    

	void Start ()
    {
        startGo1Pos = go1.transform.position;
        startGo2Pos = go2.transform.position;

        fishes = GameObject.FindGameObjectsWithTag("Fish");
    }
	
	void Update ()
    {
        if (Input.GetMouseButton(0))
        {
            pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            RaycastHit2D hit = Physics2D.Raycast(pos, Vector2.zero, Mathf.Infinity);

            if(hit == true)
            {
                if (hit.collider.tag == "Fish")
                {
                    pos.z = 0;
                    hit.collider.transform.position = pos;
                }
            }
        }
    }

    private void FixedUpdate()
    {
        if (weight2 > weight1)
        {
            go1.transform.Translate(Vector2.up * 1 * Time.deltaTime);
            go2.transform.Translate(Vector2.down * 1 * Time.deltaTime);
        }

        else if (weight1 > weight2)
        {
            go2.transform.Translate(Vector2.up * 1 * Time.deltaTime);
            go1.transform.Translate(Vector2.down * 1 * Time.deltaTime);
        }

        else
        {
            Vector3 lerpPos = Vector3.Lerp(go1.transform.position, startGo1Pos, 1 * Time.deltaTime);
            Vector3 lerpPos2 = Vector3.Lerp(go2.transform.position, startGo2Pos, 1 * Time.deltaTime);

            go1.transform.position = lerpPos;
            go2.transform.position = lerpPos2;

            float distance = go1.transform.position.y - go2.transform.position.y;
            
            if(distance < 0.01f && (weight1 + weight2 == 16))
            {
                Debug.Log("클리어");
            }
        }

        go1Pos = go1.transform.position;
        go1Pos.y = Mathf.Clamp(go1Pos.y, 16.0f, 20.0f);


        go2Pos = go2.transform.position;
        go2Pos.y = Mathf.Clamp(go2Pos.y, 16.0f, 20.0f);

        go1.transform.position = new Vector3(go1Pos.x, go1Pos.y, go1Pos.z);
        go2.transform.position = new Vector3(go2Pos.x, go2Pos.y, go2Pos.z);
    }

    public void Object1AddWeight(int i)
    {
        weight1 += i;
    }

    public void Object2AddWeight(int i)
    {
        weight2 += i;
    }

    public void Object1SubWeight(int i)
    {
        weight1 -= i;
    }

    public void Object2SubWeight(int i)
    {
        weight2 -= i;
    }

    void ResetWeight()
    {
        weight1 = 0;
        weight2 = 0;

        for(int i = 0; i < fishes.Length; i++)
        {
            fishes[i].SetActive(true);

            if(i == 0 || i == 1)
            {
                fishes[i].gameObject.transform.position = new Vector3(0, 0, 0);
            }

            else if(i == 2 || i == 3)
            {
                fishes[i].gameObject.transform.position = new Vector3(0, 0, 0);
            }

            else
            {
                fishes[i].gameObject.transform.position = new Vector3(0, 0, 0);
            }
        }
    }
}
