using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PasswordObj : MonoBehaviour
{
    public GameObject Panel;
	public GameObject MobileControls;

    public Sprite[] sprites = new Sprite[2];

	private GameObject target;
	public GameObject Null;
	public Vector2 pos;


	void Update () {
		if (Input.GetMouseButtonDown (0) && ShowPuzzle.TouchAble == true) {
			CastRay ();
			if (target.name == "PassWordObj") {
				Panel.SetActive(true);
				MobileControls.SetActive(false);
			}
		}
	}

	/*

    void OnTriggerEnter2D(Collider2D coll)
    {
        if(coll.CompareTag("Player"))
        {
            Panel.SetActive(true);
            GameObject Go = GameObject.Find("MobileControls");
            Go.SetActive(false);
        }
    }

*/


	void CastRay()
	{
		target = null;
		pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		RaycastHit2D hit = Physics2D.Raycast(pos, Vector2.zero, 0f);

		if (hit.collider != null) {

			target = hit.collider.gameObject;
			Debug.Log (target.name);
		} else {
			target = Null;
		}
	}
}
