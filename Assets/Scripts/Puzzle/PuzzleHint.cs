using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PuzzleHint : MonoBehaviour
{
    private int hint_count = 3;
    [HideInInspector]
    public int hint_index;

    private Image img;
    public Sprite[] hint_img = null;
    public Text hint_count_text;

    private CameraFollow cam_follow;

    public GameObject show_hint_btn;

    //public GameObject[] hint_image = null;
    private bool[] is_hinted = new bool[9]; //이거 어찌해야할까...
    private bool is_unlock;

	// Use this for initialization
	void Start ()
    {
        cam_follow = Camera.main.GetComponent<CameraFollow>();
        img = GetComponent<Image>();

        if (PlayerPrefs.HasKey("Hint"))
            CountLoad();
	}
	
    public void CountSave()
    {
        PlayerPrefs.SetInt("Hint", hint_count);
    }

    void CountLoad()
    {
        hint_count = PlayerPrefs.GetInt("Hint");
    }

    void TextCount()
    {
        hint_count_text.text = hint_count.ToString();
    }

    public void ShowHint()
    {
        hint_count -= 1;
        TextCount();

        for(int i = 0; i < cam_follow.goPuzzele.Length; i++)
        {
            if(cam_follow.goPuzzele[i] == true)
            {
                img.sprite = hint_img[i];
                break;
            }
        }

        img.color = new Color(1, 1, 1, 1);
    }

    public void ClickBulb()
    {
        //0번을 풀었어 -> 0번 푼게 저장이 되지 -> 그 다음껀 1번이지 -> 상관없지
        //인덱스를 받기,
        if(is_hinted[hint_index] == false)
        {
            show_hint_btn.SetActive(true);
        }

        else
        {
            ShowHint();
        }
    }

    public void HideHint()
    {
        img.color = new Color(1, 1, 1, 0);
        img.sprite = null;
    }

    public void AddHint()
    {
        hint_count += 3;
    }
}
