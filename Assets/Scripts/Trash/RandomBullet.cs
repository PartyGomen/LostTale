using UnityEngine;
using System.Collections;

public class RandomBullet : MonoBehaviour {

    public Transform[] spots;
    public GameObject missile;

    private float randomspeed;

	void Start ()
    {
        StartCoroutine(Bullet());
        
	}
	
	void Update ()
    {
        randomspeed = Random.Range(2f, 4f);
    }

    IEnumerator Bullet ()
    {
        while(true)
        {
            yield return new WaitForSeconds(0.7f);
            GameObject Bullet = (GameObject)Instantiate(missile, spots[Random.Range(0,4)].position, Quaternion.identity);
            Bullet.GetComponent<Rigidbody2D>().velocity = Vector2.left * randomspeed;
            Destroy(Bullet, 15f);
        }
    }
}
