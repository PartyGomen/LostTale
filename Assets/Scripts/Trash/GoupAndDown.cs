using UnityEngine;
using System.Collections;

public class GoupAndDown : MonoBehaviour {

    public bool isup;
    public float speed;
    public float maxhigh;
    public float maxlow;
    public GameObject gameob;

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.CompareTag("Player") && isup == true)
        {
            StartCoroutine(Goup());
        }

        else if (coll.CompareTag("Player") && isup == false)
        {
            StartCoroutine(Godown());
        }
    }

    IEnumerator Goup()
    {
        while(true)
        {
            gameob.transform.Translate(Vector2.up * speed * Time.deltaTime, Space.World);
            yield return new WaitForSeconds(0.1f);
        }
    }

    IEnumerator Godown()
    {
        while(true)
        {
            gameob.transform.Translate(Vector2.down * speed * Time.deltaTime, Space.World);
            yield return new WaitForSeconds(0.1f);
        }
    }

    void Update()
    {
        if (isup == false)
        {
            if (gameob.transform.position.y < maxlow)
            {
                Destroy(gameob.gameObject);
                Destroy(this.gameObject);
            }
        }

        else if (isup == true)
        {
            if (gameob.transform.position.y > maxhigh)
            {
                Destroy(gameob.gameObject);
                Destroy(this.gameObject);
            }
        }
    }
}
