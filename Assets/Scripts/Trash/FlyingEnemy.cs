using UnityEngine;
using System.Collections;

public class FlyingEnemy : MonoBehaviour {

    public GameObject target;
    private Vector3 positionscale;
    private Vector3 enemyscale;
    private Player player;
    

    public bool isright;
    private bool awake;
    public float speed;

	void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player");
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        isright = true;
        enemyscale = transform.localScale;
	}

    void Update()
    {
        if(transform.position.x > target.transform.position.x)
        {
            isright = true;
            transform.localScale = new Vector3(-enemyscale.x, enemyscale.y, enemyscale.z);
        }

        else
        {
            isright = false;
            transform.localScale = new Vector3(enemyscale.x, enemyscale.y, enemyscale.z);
        }
    }

    void FixedUpdate()
    {
        this.GetComponent<Rigidbody2D>().velocity = Vector2.zero;

        if (awake == true)
        {
            transform.position = Vector3.MoveTowards(this.transform.position, target.transform.position, speed * Time.deltaTime);
        }

        if(isright == true && player.PlayerLooksRight == true)
        {
            awake = false;
        }

        else if(isright == false && player.PlayerLooksRight == false)
        {
            awake = false;
        }
        
        else
        {
            awake = true;
        }
    }
}
