using UnityEngine;
using System.Collections;

public class GroundCheck : MonoBehaviour {

    private Player player;

	void Start ()
    {
        player = gameObject.GetComponentInParent<Player>();
	}

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.CompareTag("Ground"))
        {
            player.grounded = true;
        }

        if (coll.CompareTag("Elevator"))
        {
            player.is_elevator = true;
            player.anim.SetBool("Grounded", true);
        }
    }

    void OnTriggerStay2D(Collider2D coll)
    {
        if (coll.CompareTag("Ground"))
            player.grounded = true;
    }

    void OnTriggerExit2D(Collider2D coll)
    {
        if (coll.CompareTag("Ground"))
        {
            player.grounded = false;
        }

        if(coll.CompareTag("Elevator"))
        {
            player.is_elevator = false;
            player.anim.SetBool("Grounded", false);
        }
    }
}
