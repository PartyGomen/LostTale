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
    public GameObject back_btn;
	public Vector2 pos;

    GameObject player;

    float distance;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update ()
    {
        distance = Vector3.Distance(player.transform.position, this.gameObject.transform.position);

        if (Input.GetMouseButtonDown (0) && distance < 6.5) {
			CastRay ();
			if (target.name == "PassWordObj")
            {
                back_btn.SetActive(true);
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
		} else {
			target = Null;
		}
	}
}
