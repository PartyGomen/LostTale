using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXSound : MonoBehaviour
{
    AudioSource sfx_sound;

    GameObject player;

	public float VolumeMax;

    private float time;
    private float distance;
    public float sound_min_distance;
    public float sound_cycle_time;
    public float division_value;

    private bool is_play;

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
            if(!CheckIsPuzzle())
            {
                time = 0.0f;

				sfx_sound.volume = Mathf.Clamp(sfx_sound.volume, 0.0f, VolumeMax);

                sfx_sound.volume = 0.7f;
                sfx_sound.volume -= distance / division_value;

                sfx_sound.Play();
            }
        }
    }

    bool CheckIsPuzzle()
    {
        bool is_playing = false; ;

        CameraFollow cam_follow = Camera.main.GetComponent<CameraFollow>();

        for(int i = 0; i < cam_follow.goPuzzele.Length; i++)
        {
            if(cam_follow.goPuzzele[i] == true)
            {
                is_playing = true;
            }
        }

        return is_playing;
    }
}
