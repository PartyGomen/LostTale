using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowPuzzle : MonoBehaviour
{
	public GameObject Control;
	public GameObject PuzzleScreen;
	public static bool puzzleOn = false;
	public static bool puzzleClear = false;
    public GameObject Bridge;

	void OnTriggerEnter2D(Collider2D other)
	{
        if (other.gameObject.CompareTag("Player"))
        {
            Control.SetActive(false);
            puzzleOn = true;
            this.gameObject.GetComponent<SpriteRenderer>().enabled = false;
            this.gameObject.GetComponent<CircleCollider2D>().enabled = false;
            Bridge.SetActive (true);
        }
    }
}