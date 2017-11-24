using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXSound : MonoBehaviour
{
    AudioSource sfx_sound;

    GameObject player;

    float time;
    float distance;
    public float sound_min_distance;
    public float sound_cycle_time;
    public float division_value;

	// Use this for initialization
	void Start ()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        sfx_sound = GetComponent<AudioSource>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        SFXSoundPlay();
    }

    void SFXSoundPlay()
    {
        distance = Vector2.Distance(player.transform.position, this.transform.position);
        time += Time.deltaTime;

        if (distance < sound_min_distance && time >= sound_cycle_time)
        {
            time = 0.0f;

            sfx_sound.volume = 1.0f;
            sfx_sound.volume -= distance / division_value;

            sfx_sound.Play();
        }
    }
}
