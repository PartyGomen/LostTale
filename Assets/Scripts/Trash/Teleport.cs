using UnityEngine;
using System.Collections;

public class Teleport : MonoBehaviour {

    public GameObject telpo;

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.CompareTag("Player"))
        {
            this.gameObject.SetActive(false);
            telpo.SetActive(false);

            coll.transform.position = telpo.transform.position;

            Invoke("teleport", 1f);
        }
    }
 

    void teleport()
    {
        this.gameObject.SetActive(true);
        telpo.SetActive(true);
    }
}
