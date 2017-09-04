using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PelicanObj : MonoBehaviour
{
    public int weight;

    PelicanMgr pelmgr;

	void Start ()
    {
        pelmgr = GameObject.Find("Pel").GetComponent<PelicanMgr>();
	}

    private void OnTriggerEnter2D(Collider2D coll)
    {
        if(coll.gameObject.name == "Pelican1")
        {
            pelmgr.Object1AddWeight(weight);
            this.gameObject.SetActive(false);
            //this.transform.SetParent(coll.transform);
        }

        else if(coll.gameObject.name == "Pelican2")
        {
            pelmgr.Object2AddWeight(weight);
            this.gameObject.SetActive(false);
            //this.transform.SetParent(coll.transform);
        }
    }

    private void OnTriggerExit2D(Collider2D coll)
    {
        if (coll.gameObject.name == "Pelican1")
        {
            pelmgr.Object1SubWeight(weight);
            this.transform.SetParent(null);
        }

        else if (coll.gameObject.name == "Pelican2")
        {
            pelmgr.Object2SubWeight(weight);
            this.transform.SetParent(null);
        }
    }
}
