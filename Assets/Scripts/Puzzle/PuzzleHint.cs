using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PuzzleHint : MonoBehaviour
{
    private int hint_count = 3;
    [HideInInspector]
    public int hint_index;

    public Image img;
    public Sprite[] hint_img = null;
    public Text hint_count_text;

    private CameraFollow cam_follow;

    public GameObject show_hint_btn;
    public GameObject hint_obj;

    private bool[] is_hinted = new bool[9];
    private bool is_unlock;

    private string save_hint_string = "";

	void Start ()
    {
        cam_follow = Camera.main.GetComponent<CameraFollow>();

        if (PlayerPrefs.HasKey("Hint"))
            CountLoad();

        if (PlayerPrefs.HasKey("PurchaseHint"))
            HintLoad();

        TextCount();
    }
	
    public void HintSave()
    {
        save_hint_string = "";

        for(int i= 0; i < is_hinted.Length; i++)
        {
            save_hint_string = save_hint_string + is_hinted[i] + ",";
        }

        PlayerPrefs.SetString("PurchaseHint", save_hint_string);
    }

    public void HintLoad()
    {
        string[] hint_string = PlayerPrefs.GetString("PurchaseHint").Split(',');

        for(int i = 0;  i < is_hinted.Length; i++)
        {
            is_hinted[i] = bool.Parse(hint_string[i]);
        }
    }

    public void CountSave()     //힌트 갯수 저장
    {
        PlayerPrefs.SetInt("Hint", hint_count);
    }

    void CountLoad()        //힌트 갯수 불러오기
    {
        hint_count = PlayerPrefs.GetInt("Hint");
    }

    public void TextCount()    //힌트 갯수 텍스트 변경
    {
        hint_count_text.text = hint_count.ToString();
    }

    public void ShowHint()  //힌트 구매 후 힌트 보여주기
    {
        show_hint_btn.SetActive(false);
        is_hinted[hint_index] = true;
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
        CountSave();
        HintSave();
    }

    public void UnlockedHintShow()  //힌트를 구매했을때 바로 보여주기
    {
        for (int i = 0; i < cam_follow.goPuzzele.Length; i++)
        {
            if (cam_follow.goPuzzele[i] == true)
            {
                img.sprite = hint_img[i];
                break;
            }
        }

        img.color = new Color(1, 1, 1, 1);
    }

    public void ClickBulb()     //전구를 눌렀을때 구매를 보여주냐, 힌트를 보여주냐를 구분
    {
        if(is_hinted[hint_index] == false)  //Puzzle Show에서 힌트 인덱스를 넘겨받고 그게 풀렸는지 안풀렸는지를 판단!
        {
            show_hint_btn.SetActive(true);
        }

        else
        {
            UnlockedHintShow();
        }
    }

    public void ShowHintObject()
    {
        hint_obj.SetActive(true);
    }

    public void HideHint()      //힌트 숨기기
    {
        img.color = new Color(1, 1, 1, 0);
        hint_obj.SetActive(false);
    }

    public void AddHint()       //힌트 구매
    {
        hint_count += 3;
    }
}
