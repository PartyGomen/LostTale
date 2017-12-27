using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrossBow : MonoBehaviour
{
    GameObject player;
    public GameObject arrow;

    public bool leftShot;

    float distance;

    Vector3 tr;

    Animator anim;

    AudioSource cannon_audio;

	// Use this for initialization
	void Start ()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        tr = this.transform.position;
        cannon_audio = GetComponent<AudioSource>();
        anim = GetComponent<Animator>();
        anim.SetTrigger("Check");
	}


	// Update is called once per frame
	void Update ()
    {
        distance = Vector3.Distance(this.transform.position, player.transform.position);

        if (!anim.GetCurrentAnimatorStateInfo(0).IsName("Cannon_Shot"))
        {
            if (leftShot)
                Instantiate(arrow, new Vector3(tr.x - 1, tr.y, tr.z), this.transform.rotation);

            else
                Instantiate(arrow, new Vector3(tr.x + 1, tr.y, tr.z), this.transform.rotation);

            anim.SetTrigger("Check");

            cannon_audio.volume = 1.0f;
            cannon_audio.volume -= distance / 20.0f;

            if (distance < 20f && !CheckIsPuzzle())
            {
                cannon_audio.Play();
            }
        }
    }

    bool CheckIsPuzzle()
    {
        bool is_playing = false; ;

        CameraFollow cam_follow = Camera.main.GetComponent<CameraFollow>();

        for (int i = 0; i < cam_follow.goPuzzele.Length; i++)
        {
            if (cam_follow.goPuzzele[i] == true)
            {
                is_playing = true;
            }
        }

        return is_playing;
    }
}
