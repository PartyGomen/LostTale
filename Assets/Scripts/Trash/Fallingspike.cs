using UnityEngine;
using System.Collections;

public class Fallingspike : MonoBehaviour
{

    float randomspeed;
    public float destroyy;

    void Awake()
    {
        randomspeed = Random.Range(3f, 6f);
    }

    void Update()
    {
        transform.Translate(Vector2.down * Time.deltaTime * randomspeed);
        
        if(transform.position.y <= destroyy)
        {
            Destroy(this.gameObject);
        }
    }
}
