using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PianoNotes : MonoBehaviour
{
    public float fade_time;

    SpriteRenderer sprite_renderer;

	// Use this for initialization
	void Start ()
    {
        sprite_renderer = GetComponent<SpriteRenderer>();
        StartCoroutine(FadeIn());
        Destroy(this.gameObject, fade_time);
	}

    IEnumerator FadeIn()
    {
        float alpha = 1.0f;

        while (alpha >= 0)
        {
            alpha -= Time.deltaTime / fade_time;

            sprite_renderer.color = new Color(1, 1, 1, alpha);

            yield return null;
        }
    }
}
