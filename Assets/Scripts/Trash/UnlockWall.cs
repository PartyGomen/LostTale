using UnityEngine;
using System.Collections;

public class UnlockWall : MonoBehaviour {

    public GameObject gameob;
    public AudioSource keyaudio;

    void OnTriggerEnter2D(Collider2D coll)
    {
        if(coll.CompareTag("Player"))
        {
            Destroy(this.gameObject);
            Destroy(gameob);
            keyaudio.Play();
        }
    }


}
