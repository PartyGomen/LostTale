using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PianoNotes : MonoBehaviour
{
    public float fade_time;
    public float shakeAmount;

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

    ////음표 떨림
    //void Update()
    //{
    //    if (fade_time >= 0)
    //    {
    //        Vector2 ShakePos = Random.insideUnitCircle * shakeAmount;

    //        transform.position = new Vector3(transform.position.x + ShakePos.x, transform.position.y + ShakePos.y, transform.position.z);

    //        fade_time -= Time.deltaTime;
    //    }
    //}
}
