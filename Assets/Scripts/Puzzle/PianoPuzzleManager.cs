using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PianoPuzzleManager : MonoBehaviour
{
    [HideInInspector]
    public string[] answer = new string[4];
    [HideInInspector]
    public int index_number = 0;

    private bool is_clear = false;

    private Player player;
    public Image[] clearImage = new Image[2];

    private void Start() 
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

    public void EnterKey(string str)
    {
        answer[index_number] = str;

        index_number++;

        if(index_number > 3)
        {
            CheckAnswer();
            index_number = 0;
        }
    }

    void CheckAnswer()
    {
        if(answer[0] == "C" && answer[1] == "A" && answer[2] == "G" && answer[3] == "E" && !is_clear)
        {
            is_clear = true;
            StartCoroutine(ClearFade());
            CameraFollow cam_follow = Camera.main.GetComponent<CameraFollow>();
            cam_follow.FadeCoroutine(false, 1f);
            cam_follow.FadeCoroutine(true, 2f);
            cam_follow.CheckPuzzleOrPlayer(false);
            player.saveZoneidx = 2;

			// 퍼즐 저장기능 해제  (Inventory.PuzzleGet[6] == false)
            if (Inventory.PuzzleGet[6] == true)
                GetComponent<PuzzleClear>().Clear();
        }
    }

    public void ResetKey()
    {
        if (is_clear)
            return;

        index_number = 0;
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
