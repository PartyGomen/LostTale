using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PelicanObj : MonoBehaviour
{
    public int weight;

    PelicanMgr pelmgr;

    RaycastHit2D hit;

    Vector3 pos;

	void Start ()
    {
        pelmgr = GameObject.Find("Pel").GetComponent<PelicanMgr>();
	}

    private void Update()
    {
        if(Input.GetMouseButton(0))
        {
            pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            hit = Physics2D.Raycast(pos, Vector2.zero, Mathf.Infinity);

            if(hit)
            {
                if(hit.collider.gameObject == this.gameObject)
                {
                    pos.z = 0;
                    this.transform.position = pos;
                }
            }
        }
    }

    void ActiveFalse()
    {
        this.gameObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D coll)
    {
        if(coll.gameObject.name == "Pelican1")
        {
            Animator anim = coll.gameObject.GetComponent<Animator>();
            anim.SetTrigger("Eat");
            pelmgr.Object1AddWeight(weight);
            this.gameObject.SetActive(false);
        }

        else if(coll.gameObject.name == "Pelican2")
        {
            Animator anim = coll.gameObject.GetComponent<Animator>();
            anim.SetTrigger("Eat");
            pelmgr.Object2AddWeight(weight);
            this.gameObject.SetActive(false);
        }
    }
}
