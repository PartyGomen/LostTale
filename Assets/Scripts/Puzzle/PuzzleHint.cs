using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleHint : MonoBehaviour
{
    private int hint_count = 3;
    public GameObject[] hint_image = null;
    private bool is_hinted;

	// Use this for initialization
	void Start ()
    {
        if (PlayerPrefs.HasKey("Hint"))
            CountLoad();
	}
	
    public void CountSave()
    {
        PlayerPrefs.SetInt("Hint", hint_count);
    }

    void CountLoad()
    {
        hint_count = PlayerPrefs.GetInt("Hint");
    }

    public void ShowHint(int _idx)
    {
        hint_image[_idx].SetActive(true);
    }

    public void AddHint()
    {
        hint_count += 3;
    }
}
