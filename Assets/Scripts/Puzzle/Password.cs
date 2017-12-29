using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Password : MonoBehaviour {

    int one, two, three, four;
    public Text[] num = new Text[4];
    public int[] answer = new int[4];

    public GameObject obj;
    public Sprite unlock_sprite;
    public GameObject password_object;
    private CameraFollow cam_follow;

    public AudioSource click_sound;

    private Player player;

    private bool is_clear;

	void Start ()
    {
        cam_follow = Camera.main.GetComponent<CameraFollow>();
        one = 0;
        two = 0;
        three = 0;
        four = 0;

        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }
	
	void Update ()
    {
        num[0].text = one.ToString();
        num[1].text = two.ToString();
        num[2].text = three.ToString();
        num[3].text = four.ToString();
    }

    void CheckCorret()
    {
        if (one == answer[0] && two == answer[1] && three == answer[2] && four == answer[3] && !is_clear)
        {
            cam_follow.FadeCoroutine(false, 0f);
            cam_follow.FadeCoroutine(true, 1f);
            cam_follow.CheckPuzzleOrPlayer(false);
            Invoke("AfterClear", 1f);
            password_object.GetComponent<SpriteRenderer>().sprite = unlock_sprite;
            obj.SetActive(true);
            player.saveZoneidx = 2;

            if (Inventory.PuzzleGet[1] == false)
                GetComponent<PuzzleClear>().Clear();
        }
    }

    void AfterClear()
    {
        GameObject Go = GameObject.Find("PassWordPanel");
        Go.SetActive(false);
    }

    void SoundPlay()
    {
        click_sound.Play();
    }

    public void Off()
    {
        GameObject go = GameObject.Find("PassWordPanel");
        if(go != null)
            go.SetActive(false);
        one = 0;
        two = 0;
        three = 0;
        four = 0;
    }

    public void AddOne ()
    {
        SoundPlay();

        one++;
        if (one > 9)
            one = 0;

        CheckCorret();
    }

    public void SubOne()
    {
        SoundPlay();

        one--;
        if (one < 0)
            one = 9;

        CheckCorret();
    }

    public void AddTwo()
    {
        SoundPlay();

        two++;
        if (two > 9)
            two = 0;

        CheckCorret();
    }

    public void SubTwo()
    {
        SoundPlay();

        two--;
        if (two < 0)
            two = 9;

        CheckCorret();
    }

    public void AddThree()
    {
        SoundPlay();

        three++;
        if (three > 9)
            three = 0;

        CheckCorret();
    }

    public void SubThree()
    {
        SoundPlay();

        three--;
        if (three < 0)
            three = 9;

        CheckCorret();
    }

    public void AddFour()
    {
        SoundPlay();

        four++;
        if (four > 9)
            four = 0;

        CheckCorret();
    }

    public void SubFour()
    {
        SoundPlay();

        four--;
        if (four < 0)
            four = 9;

        CheckCorret();
    }
}
