using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dialogue : MonoBehaviour
{
    private string saystring;   //넘겨 받는 스트링

    private Sprite showimage;   //넘겨 받는 이미지

    [Range(0.0f, 1.0f)]
    public float delay; //텍스트 딜레이 간격
    float fairydelay = 0.08f;   //3컷에서 동화 주인공 페이드 간격
    float a;    //페이드인 판 알파
    float[] fairya = new float[4];  //동화 주인공 알파
    float handa;    //손 알파
    public float fadetime;  //페이드판 페이드 시간

    public Text txt;    //텍스트 출력

    public Image image; //인트로 배경
    public Image fadeImage; //페이드 판 이미지
    public Image[] fairy;   //동화 주인공 이미지
    public Image hand;  //손 이미지

    public GameObject fairyPanel;   //3컷 동화 주인공 담는 파넬

    public RectTransform librayImg; //도서관 씬 이미지
    Vector3 startPosition = new Vector3(0, 490, 0); //도서관 씬 처음 위치
    Vector3 endPosition = new Vector3(0, -290, 0);  //도서관 씬 마지막 위치

    public bool isTyping;   //타이핑 중인가?

    public IntroHand introHand;
    private delegate IEnumerator handDelegate();
    private handDelegate handDelegateHandler;

    public void StartSay(string str, Sprite img)    //텍스트 출력 시작
    {
        saystring = str;    //넘겨 받은거 다 넣어줌
        showimage = img;    //동일

        image.sprite = showimage;   //이미지 바꿈

        StartCoroutine(FadeIn());
        StartCoroutine(Say());
    }

    public IEnumerator Say()    //텍스트 출력하는 코루틴
    {
        handDelegateHandler = introHand.Touch;
        StopCoroutine(handDelegateHandler());
        introHand.gameObject.SetActive(false);

        isTyping = true;

        txt.text = string.Empty;

        foreach(char c in saystring)
        { 
            txt.text += c;

            yield return new WaitForSeconds(delay);
        }

        isTyping = false;

        introHand.gameObject.SetActive(true);
        StartCoroutine(handDelegateHandler());
    }

    public void SkipTyping()    //텍스트 다 나오기 전 스킵 함수
    {
        StopAllCoroutines();

        txt.text = saystring;

        introHand.gameObject.SetActive(true);
        StartCoroutine(handDelegateHandler());

        fadeImage.color = new Color(0, 0, 0, 0);

        isTyping = false;

        if(librayImg.gameObject.activeSelf == true)
        {
            librayImg.anchoredPosition = endPosition;
        }

        if(fairyPanel.activeSelf == true)
        {
            for (int i = 0; i < 4; i++)
            {
                fairy[i].color = new Color(1, 1, 1, 0.5f);
            }

            hand.color = new Color(1, 1, 1, 1);
        }
    }

    public IEnumerator LibaryCamera()   //도서관 씬 카메라 이동 코루틴
    {
        float timeOfTravel = 5.0f; //time after object reach a target place 
        float currentTime = 0; // actual floting time 
        float normalizedValue;

        while (currentTime <= timeOfTravel)
        {
            currentTime += Time.deltaTime;
            normalizedValue = currentTime / timeOfTravel; // we normalize our time 


            librayImg.anchoredPosition = Vector3.Lerp(startPosition, endPosition, normalizedValue);

            yield return null;
        }
    }

    public IEnumerator FadeFairy()  //동화 주인공 페이드 코루틴
    {
        while (fairya[0] <= 1)
        {
            fairya[0] += 0.1f;
            fairy[0].color = new Color(1, 1, 1, fairya[0]);

            yield return new WaitForSeconds(fairydelay);
        }

        while (fairya[1] <= 1)
        {
            fairya[1] += 0.1f;
            fairy[1].color = new Color(1, 1, 1, fairya[1]);

            yield return new WaitForSeconds(fairydelay);
        }

        while (fairya[2] <= 1)
        {
            fairya[2] += 0.1f;
            fairy[2].color = new Color(1, 1, 1, fairya[2]);

            yield return new WaitForSeconds(fairydelay);
        }

        while (fairya[3] <= 1)
        {
            fairya[3] += 0.1f;
            fairy[3].color = new Color(1, 1, 1, fairya[3]);

            yield return new WaitForSeconds(fairydelay);
        }

        for (int i = 0; i < 4; i++)
        {
            fairy[i].color = new Color(1, 1, 1, 0.5f);
        }

        while (handa <= 1)
        {
            handa += 0.1f;
            hand.color = new Color(1, 1, 1, handa);

            yield return new WaitForSeconds(fairydelay);
        }
    }

    IEnumerator FadeOut()   //페이드 아웃도 구현했지만 쓰지 않습니다
    {
        float t = 0.0f;

        while (t <= 1)
        {
            t += Time.deltaTime / fadetime;

            fadeImage.color = new Color(0, 0, 0, t);

            yield return null;
        }
    }

    IEnumerator FadeIn()    //인트로 이미지 바꿀때마다 페이드 코루틴
    {
        float t = 1.0f;

        while(t >= 0)
        {
            t -= Time.deltaTime / fadetime;

            fadeImage.color = new Color(0, 0, 0, t);

            yield return null;
        }
    }
}
