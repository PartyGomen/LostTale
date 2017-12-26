using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameTutorial : MonoBehaviour
{
    public Player[] player = new Player[2];

    private float[] time_check = new float[2];

	// Update is called once per frame
	void Update ()
    {
        time_check[0] += Time.deltaTime;

        if (time_check[0] > 1.0f)
        {
            time_check[0] = 0.0f;

            time_check[1] += Time.deltaTime;

            if (time_check[1] < 1f)
            {
                for(int i = 0; i < 2; i++)
                {
                    player[i].Button_Jump_press();
                }
            }

            else
            {
                time_check[1] = 0.0f;
            }
        }

        else
        {
            player[0].Button_Jump_release();
        }
    }
}
