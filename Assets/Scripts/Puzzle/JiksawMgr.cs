using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JiksawMgr : MonoBehaviour
{
    public Jiksaw[] jiksawObj;

    public float[] distance = new float[5];

    public GameObject[] pos_check = new GameObject[5];

    private bool[] bool_clear = new bool[5];
    private bool is_clear;

    Vector3 pos;
    RaycastHit2D hit;

    private void Start()
    {
        if (PlayerPrefs.HasKey(("PuzzlePiece")))
        {
            string[] puzzle_string = PlayerPrefs.GetString("PuzzlePiece").Split(',');

            is_clear = bool.Parse(puzzle_string[9]);
        }
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            hit = Physics2D.Raycast(pos, Vector2.zero, Mathf.Infinity);

            if (hit)
            { 
                if (hit.collider.gameObject.tag == "JikSaw")
                {
                    Jiksaw jik = hit.collider.gameObject.GetComponent<Jiksaw>();

                    if (!jik.move[0])
                        hit.collider.gameObject.transform.Translate(Vector2.right * 3.6f);
                    else if (!jik.move[1])
                        hit.collider.gameObject.transform.Translate(Vector2.left * 3.6f);
                    else if (!jik.move[2])
                        hit.collider.gameObject.transform.Translate(Vector2.up * 3f);
                    else if (!jik.move[3])
                        hit.collider.gameObject.transform.Translate(Vector2.down * 3f);

                    CheckBool();
                    CheckClear();
                }
            }
        }
    }

    void CheckBool()
    {
       for(int i = 0; i < jiksawObj.Length; i++)
        {
            for(int j = 0; j < 4; j++)
            {
                jiksawObj[i].move[j] = false;
                jiksawObj[i].CheckRay();
            }
        }
    }

    void CheckClear()
    {
        for(int i = 0; i < pos_check.Length; i++)
        {
            distance[i] = Vector3.Distance(jiksawObj[i].gameObject.transform.position, pos_check[i].transform.position);

            if(distance[i] < 1f)
            {
                bool_clear[i] = true;
            }

            else
            {
                bool_clear[i] = false;
            }
        }

        for(int i = 0; i < bool_clear.Length; i++)
        {
            if(bool_clear[i] != true)
            {
                return;
            }

            else
            {
                if(i == bool_clear.Length - 1 && !is_clear)
                {
                    is_clear = true;

                    CameraFollow cam_follow = Camera.main.GetComponent<CameraFollow>();

                    cam_follow.FadeCoroutine(false, 0f);
                    cam_follow.FadeCoroutine(true, 1f);
                    cam_follow.CheckPuzzleOrPlayer(false);

                    GetComponent<PuzzleClear>().Clear();
                }
            }
        }
    }
}
