using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chandelier : MonoBehaviour
{
    public GameObject particle;

    AudioSource drop_audio;

    RaycastHit2D hit;

    Vector3 pos;

    Rigidbody2D rb2d;

    Animator anim;

    int count;

	public AudioClip[] ChandelierSound;


    void Start ()
    {
        drop_audio = GetComponent<AudioSource>();
        rb2d = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
	}
	
	void Update ()
    {
	    if(Input.GetMouseButtonDown(0))
        {
            pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            hit = Physics2D.Raycast(pos, Vector2.zero, Mathf.Infinity);

            if(hit)
            {
                if (hit.collider.gameObject == this.gameObject)
                {
					this.GetComponent<AudioSource> ().clip = ChandelierSound [1];
					this.GetComponent<AudioSource> ().Play ();
                    count++;
                }
            }
        }

        if(count == 2)
        {
			Debug.Log ("Hi");
            rb2d.bodyType = RigidbodyType2D.Dynamic;
			this.GetComponent<AudioSource> ().Play ();
            if(particle != null)
                particle.SetActive(false);
			count++;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(!collision.gameObject.CompareTag("Player"))
        {
			this.GetComponent<AudioSource> ().clip = ChandelierSound [0];
            drop_audio.Play();
            rb2d.bodyType = RigidbodyType2D.Static;
            anim.SetBool("IsBroken", true);
            CameraShake shake = Camera.main.GetComponent<CameraShake>();
            shake.ShakeCamera(0.1f, 0.2f);
            Destroy(this);
        }
    }
}
