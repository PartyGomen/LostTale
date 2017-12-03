using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PasswordObj : MonoBehaviour
{
    public GameObject Panel;

	private GameObject target;
	public GameObject Null;
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

        if (Input.GetMouseButtonDown (0) && distance < 6.5)
        {
			CastRay ();
			if (target == this.gameObject)
            {
                Invoke("PanelOn", 1f);
			}
		}
	}

    void PanelOn()
    {
        Panel.SetActive(true);
    }

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
