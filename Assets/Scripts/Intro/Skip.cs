using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Skip : MonoBehaviour
{
    public AudioSource click_sound;

    private bool clicked;

    public void SkipIntro()
    {
        if (clicked)
            return;

        clicked = true;
        click_sound.Play();

        SceneManager.LoadScene(3);
    }
}
