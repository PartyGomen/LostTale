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
    public GameObject siso;
    GameObject[] fishes;
    

	void Start ()
    {
        startGo1Pos = go1.transform.position;
        startGo2Pos = go2.transform.position;

        fishes = GameObject.FindGameObjectsWithTag("Fish");
    }
	
	void Update ()
    {
        if (Input.GetMouseButtonDown(0))
        {
            pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            RaycastHit2D hit = Physics2D.Raycast(pos, Vector2.zero, Mathf.Infinity);

            if(hit == true)
            {
                if (hit.collider.tag == "Pelican")
                {
                    Spit();
                    ResetWeight();
                }
            }
        }
    }

    private void FixedUpdate()
    {
        if (weight2 > weight1)
        {
            go1.transform.position = Vector3.Lerp(go1.transform.position, new Vector3(25, -25.5f, 0), 1 * Time.deltaTime);
            go2.transform.position = Vector3.Lerp(go2.transform.position, new Vector3(35, -29.5f, 0), 1 * Time.deltaTime);
            siso.transform.rotation = Quaternion.Lerp(siso.transform.rotation, Quaternion.Euler(0, 0, -20), 1 * Time.deltaTime);
        }

        else if (weight1 > weight2)
        {
            go1.transform.position = Vector3.Lerp(go1.transform.position, new Vector3(25, -29.5f, 0), 1 * Time.deltaTime);
            go2.transform.position = Vector3.Lerp(go2.transform.position, new Vector3(35, -25.5f, 0), 1 * Time.deltaTime);
            siso.transform.rotation = Quaternion.Lerp(siso.transform.rotation, Quaternion.Euler(0, 0, 20), 1 * Time.deltaTime);
        }

        else
        {
            go1.transform.position = Vector3.Lerp(go1.transform.position, startGo1Pos, 1 * Time.deltaTime);
            go2.transform.position = Vector3.Lerp(go2.transform.position, startGo2Pos, 1 * Time.deltaTime);
            siso.transform.rotation = Quaternion.Lerp(siso.transform.rotation, Quaternion.Euler(0,0,0), 1 * Time.deltaTime);

            float distance = Mathf.Abs(go1.transform.position.y - go2.transform.position.y);
            
            if(distance < 0.1f && (weight1 + weight2 == 16))
            {
                Debug.Log("클리어");
            }
        }
    }

    public void Object1AddWeight(int i)
    {
        weight1 += i;
    }

    public void Object2AddWeight(int i)
    {
        weight2 += i;
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
                fishes[i].gameObject.transform.position = new Vector3(25.5f, -34.5f, 0);
            }

            else if(i == 2 || i == 3)
            {
                fishes[i].gameObject.transform.position = new Vector3(34.5f, -34.5f, 0);
            }

            else
            {
                fishes[i].gameObject.transform.position = new Vector3(29.5f, -34.5f, 0);
            }
        }
    }

    void Spit()
    {
        GameObject[] pelicans = GameObject.FindGameObjectsWithTag("Pelican");
        
        for(int i = 0; i < pelicans.Length; i++)
        {
            Animator anim = pelicans[i].GetComponent<Animator>();

            if (weight2 > 0 && i == 0)
                anim.SetTrigger("Eat");

            else if (weight1 > 0 && i == 1)
                anim.SetTrigger("Eat");
        }
    }
}
