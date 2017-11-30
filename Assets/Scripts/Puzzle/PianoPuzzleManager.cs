using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PianoPuzzleManager : MonoBehaviour
{
    [HideInInspector]
    public string[] answer = new string[4];

    int index_number = 0;

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
        if(answer[0] == "C" && answer[1] == "A" && answer[2] == "G" && answer[3] == "E")
        {
            Debug.Log("Clear");
        }
    }

    void ResetKey()
    {
        index_number = 0;

        for (int i = 0; i < answer.Length; i++)
        {
            answer[i] = "";
        }
    }
}
