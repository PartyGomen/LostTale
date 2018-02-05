using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JiksawMgr : MonoBehaviour
{
    public Jiksaw[] jiksawObj;

    public float[] distance = new float[5];

    public GameObject[] pos_check = new GameObject[5];

    private bool[] bool_clear = new bool[5];
    private bool is_clear;

    Vector3 pos;
    RaycastHit2D hit;

    private Player player;
    public Image[] clearImage = new Image[2];

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
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
                    StartCoroutine(ClearFade());

                    CameraFollow cam_follow = Camera.main.GetComponent<CameraFollow>();

                    cam_follow.FadeCoroutine(false, 1f);
                    cam_follow.FadeCoroutine(true, 2f);
                    cam_follow.CheckPuzzleOrPlayer(false);

                    player.saveZoneidx = 4;

					// 퍼즐 저장기능 해제  (Inventory.PuzzleGet[8] == false)
                    if (Inventory.PuzzleGet[8] == true)
                        GetComponent<PuzzleClear>().Clear();
                }
            }
        }
    }

    IEnumerator ClearFade()
    {
        float t = 0.0f;

        clearImage[0].gameObject.SetActive(true);
        clearImage[1].gameObject.SetActive(true);

        while (t < 1)
        {
            t += Time.deltaTime;

            clearImage[0].color = new Color(1, 1, 1, t);
            clearImage[1].color = new Color(1, 1, 1, t);

            yield return null;
        }
    }
}
