using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TideManager : MonoBehaviour
{
    public GameObject star;
    public GameObject moon;

    Transform[] spots;

    public Tide tide;

    public int starspot;

    void Start ()
    {
        starspot = Random.Range(1, 9);

        spots = GetComponentsInChildren<Transform>();
        tide = GameObject.Find("Tide").GetComponent<Tide>();

        star.transform.position = spots[starspot].position;

        if(starspot == 1 || starspot == 5)
        {
            spots[9].gameObject.name = "rising";
            spots[13].gameObject.name = "rising";
            spots[11].gameObject.name = "edd";
            spots[15].gameObject.name = "edd";

            int[] rot = new int[6] { -45, -90, -135, 135, 90, 45 };

            moon.transform.eulerAngles = new Vector3(0,0,rot[Random.Range(0, rot.Length)]);
        }

        else if(starspot == 2 || starspot == 6)
        {
            spots[10].gameObject.name = "rising";
            spots[14].gameObject.name = "rising";
            spots[12].gameObject.name = "edd";
            spots[16].gameObject.name = "edd";

            int[] rot = new int[6] { 0, -90, -135, -180, 90, 45 };

            moon.transform.eulerAngles = new Vector3(0, 0, rot[Random.Range(0, rot.Length)]);
        }

        else if(starspot == 3 || starspot == 7)
        {
            spots[11].gameObject.name = "rising";
            spots[15].gameObject.name = "rising";
            spots[13].gameObject.name = "edd";
            spots[9].gameObject.name = "edd";

            int[] rot = new int[6] { 0, -45, -135, -180, 135, 45 };

            moon.transform.eulerAngles = new Vector3(0, 0, rot[Random.Range(0, rot.Length)]);
        }

        else if(starspot == 4 || starspot == 8)
        {
            spots[12].gameObject.name = "rising";
            spots[16].gameObject.name = "rising";
            spots[14].gameObject.name = "edd";
            spots[10].gameObject.name = "edd";

            int[] rot = new int[6] { 0, -45, -90, -180, 135, 90 };

            moon.transform.eulerAngles = new Vector3(0, 0, rot[Random.Range(0, rot.Length)]);
        }

        tide.z = (int)moon.transform.eulerAngles.z;
        tide.gameObject.SetActive(false);
	}
}
