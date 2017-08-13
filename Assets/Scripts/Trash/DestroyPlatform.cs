using UnityEngine;
using System.Collections;

public class DestroyPlatform : MonoBehaviour {

    public float delayt;
 
    void OnCollisionEnter2D(Collision2D coll)
    {
        if(coll.collider.CompareTag("Player"))
        {
            StartCoroutine(PlatformDestroy());
        }
    }

    IEnumerator PlatformDestroy()
    {
        yield return new WaitForSeconds(delayt);
        Destroy(this.gameObject);
    }
}
