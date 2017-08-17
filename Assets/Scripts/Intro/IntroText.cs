using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroText : MonoBehaviour
{
    [TextArea]
    public string[] str;    //텍스트 모음
    public Sprite[] img;    //이미지 모음

    int stridx = 0; //텍스트 인덱스
    int imgidx = 0; //이미지 인덱스 (하나로 통일해도 상관없지만 혹시 몰라 나눔)

    Dialogue dialogue;  //스크립트 연결

	void Start ()
    {
        dialogue = GameObject.Find("Dialogue").GetComponent<Dialogue>();

        //시작하자마자 인트로 시작하게
        dialogue.StartSay(str[stridx], img[imgidx]);
        stridx++;
        imgidx++;
    }
	
	void Update ()
    {
	    if(Input.GetMouseButtonDown(0))
        {
            if(dialogue.isTyping == true)   //타이핑 중이라면 스킵
            {
                dialogue.SkipTyping();
            }
            
            else  //아니라면 다음 거 출력
            {
                if (dialogue.librayImg.gameObject.activeSelf == true) //도서관 씬 켜져있으면 끄기
                    dialogue.librayImg.gameObject.SetActive(false);

                if (dialogue.fairyPanel.activeSelf == true) //동화 파넬 켜져있으면 끄기
                    dialogue.fairyPanel.SetActive(false);

                dialogue.StartSay(str[stridx], img[imgidx]);
                stridx++;
                imgidx++;

                if(imgidx == 3) //통화씬에서 동화 캐릭터 담은 판 출력
                {
                    dialogue.fairyPanel.SetActive(true);
                    dialogue.StartCoroutine(dialogue.FadeFairy());
                }

                if(imgidx == 4) //도서관씬에서 도서관 이미지 출력(도서관 이미지는 크므로 따로 사용)
                {
                    dialogue.librayImg.gameObject.SetActive(true);
                    dialogue.StartCoroutine(dialogue.LibaryCamera());
                }
            }
        }
	}
}
