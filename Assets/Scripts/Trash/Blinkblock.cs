using UnityEngine;
using System.Collections;

public class Blinkblock : MonoBehaviour {

    public float timechk;
    public float returnt;
    public float blinkt;

    void Update()
    {
        timechk += Time.deltaTime;

        if(timechk > blinkt)
        {
            this.gameObject.SetActive(false);

            Invoke("Blink", returnt);
        }
    }

    void Blink()
    {
        this.gameObject.SetActive(true);
        timechk = 0f;
    }
}
