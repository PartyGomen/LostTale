using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TideManager : MonoBehaviour
{
    public GameObject star; //별 오브젝트
    public GameObject moonObj; //달 오브젝트
    public GameObject moonParent; //달 부모 오브젝트

    public Moon moon;

    Transform[] spots;  //별 위치 + 달 위치

    public Tide tide;

    public int starspot;
    int z;

    void Start ()
    {
        starspot = Random.Range(1, 9);

        spots = GetComponentsInChildren<Transform>();
        tide = GameObject.Find("TideBtn").GetComponent<Tide>();

        star.transform.position = spots[starspot].position;

        if(starspot == 1 || starspot == 5)
        {
            spots[9].gameObject.name = "rising";
            spots[13].gameObject.name = "rising";
            spots[11].gameObject.name = "edd";
            spots[15].gameObject.name = "edd";

            int[] rot = new int[6] { -45, -90, -135, 135, 90, 45 };

            moonObj.transform.eulerAngles = new Vector3(0,0,rot[Random.Range(0, rot.Length)]);
        }

        else if(starspot == 2 || starspot == 6)
        {
            spots[10].gameObject.name = "rising";
            spots[14].gameObject.name = "rising";
            spots[12].gameObject.name = "edd";
            spots[16].gameObject.name = "edd";

            int[] rot = new int[6] { 0, -90, -135, -180, 90, 45 };

            moonObj.transform.eulerAngles = new Vector3(0, 0, rot[Random.Range(0, rot.Length)]);
        }

        else if(starspot == 3 || starspot == 7)
        {
            spots[11].gameObject.name = "rising";
            spots[15].gameObject.name = "rising";
            spots[13].gameObject.name = "edd";
            spots[9].gameObject.name = "edd";

            int[] rot = new int[6] { 0, -45, -135, -180, 135, 45 };

            moonObj.transform.eulerAngles = new Vector3(0, 0, rot[Random.Range(0, rot.Length)]);
        }

        else if(starspot == 4 || starspot == 8)
        {
            spots[12].gameObject.name = "rising";
            spots[16].gameObject.name = "rising";
            spots[14].gameObject.name = "edd";
            spots[10].gameObject.name = "edd";

            int[] rot = new int[6] { 0, -45, -90, -180, 135, 90 };

            moonObj.transform.eulerAngles = new Vector3(0, 0, rot[Random.Range(0, rot.Length)]);
        }

        z = (int)moon.transform.eulerAngles.z;
        tide.z = (int)moon.transform.eulerAngles.z;
        tide.gameObject.SetActive(false);
	}

    IEnumerator FirstWaterPosChange()
    {
        while (0.01f <= Mathf.Abs(moon.waterObj[0].transform.position.y - moon.waterYPos[0]))
        {
            yield return null;

            moon.waterObj[0].transform.position = Vector3.Lerp(moon.waterObj[0].transform.position, new Vector2(moon.waterObj[0].transform.position.x, moon.waterYPos[0]), 0.7f * Time.deltaTime);
        }
    }

    IEnumerator SecondWaterPosChange()
    {
        while (0.01f <= Mathf.Abs(moon.waterObj[1].transform.position.y - moon.waterYPos[1]))
        {
            yield return null;

            moon.waterObj[1].transform.position = Vector3.Lerp(moon.waterObj[1].transform.position, new Vector2(moon.waterObj[1].transform.position.x, moon.waterYPos[1]), 0.7f * Time.deltaTime);
        }
    }

    public void WaterChange()
    {
        if (Camera.main.GetComponent<CameraFollow>().goPuzzele[0] == true)
        {
            StartCoroutine(FirstWaterPosChange());
            StartCoroutine(SecondWaterPosChange());

            GameObject.Find("TideBtn").SetActive(false);
        }
    }
}
