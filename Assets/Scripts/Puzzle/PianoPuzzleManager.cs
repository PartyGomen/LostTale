using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PianoPuzzleManager : MonoBehaviour
{
    [HideInInspector]
    public string[] answer = new string[4];
    [HideInInspector]
    public int index_number = 0;

    private bool is_clear = false;

    private Player player;

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
            CameraFollow cam_follow = Camera.main.GetComponent<CameraFollow>();
            cam_follow.FadeCoroutine(false, 0f);
            cam_follow.FadeCoroutine(true, 1f);
            cam_follow.CheckPuzzleOrPlayer(false);
            player.saveZoneidx = 2;

            if (Inventory.PuzzleGet[6] == false)
                GetComponent<PuzzleClear>().Clear();
        }
    }

    public void ResetKey()
    {
        if (is_clear)
            return;

        index_number = 0;
    }
}
