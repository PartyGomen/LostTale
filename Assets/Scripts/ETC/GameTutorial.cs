using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class GameTutorial : MonoBehaviour
{
    public enum TUTORIAL_TYPE
    {
        HAND,
        JUMP,
        PARTICLE,
        RUN,
        NONE
    }

    public Player[] player = new Player[4];

    public GameObject[] page_button = new GameObject[2];
    public GameObject[] hand_image = new GameObject[4];
    public GameObject[] tutorial_object = new GameObject[3];
    public GameObject drag_image;
    public GameObject start_button;
    public GameObject pull;

    public Image[] next_imgae;

    public Image panel;

    private int four_way = 0;
    private int tutorial_idx = 0;

    private float alpha;
    private float[] time_check = new float[4];
    public float fade_time;

    private bool[] change = new bool[4];
    private bool add;
    private bool stop = true;

    private void Start()
    {
        StartCoroutine(Fade(true, 0f));
        Invoke("StopToFalse", 1f);
    }

    // Update is called once per frame
    void Update ()
    {
        alpha = Mathf.Clamp(alpha, 0.2f, 1.0f);

        for(int i = 0; i < next_imgae.Length; i++)
        {
            next_imgae[i].color = new Color(1, 1, 1, alpha);
        }

        if (add)
        {
            alpha += Time.deltaTime;

            if (alpha >= 1.0f)
                add = false;
        }
        else
        {
            alpha -= Time.deltaTime;

            if (alpha <= 0.2f)
                add = true;
        }

        switch (tutorial_idx)
        {
            case 0:
                {
                    time_check[0] += Time.deltaTime;

                    if (time_check[0] > 1.0f)
                    {
                        for (int i = 0; i < 2; i++)
                        {
                            change[i] = true;

                            ChangeHandImage(i, true);
                        }

                        time_check[0] = 0.0f;

                        time_check[1] += Time.deltaTime;

                        if (time_check[1] < 1f)
                        {
                            for (int i = 0; i < 2; i++)
                            {
                                player[i].Button_Jump_press();
                            }
                        }

                        else
                        {
                            time_check[1] = 0.0f;
                        }
                    }

                    else
                    {
                        player[0].Button_Jump_release();
                    }

                    if (change[0] == true)
                    {
                        time_check[2] += Time.deltaTime;

                        if (time_check[2] >= 0.2f)
                        {
                            change[0] = false;
                            ChangeHandImage(0, false);
                            time_check[2] = 0.0f;
                        }
                    }

                    if (change[1] == true)
                    {
                        time_check[3] += Time.deltaTime;

                        if (time_check[3] >= 0.5f)
                        {
                            change[1] = false;
                            ChangeHandImage(1, false);
                            time_check[3] = 0.0f;
                        }
                    }
                }
                break;

            case 1:
                {
                    time_check[0] += Time.deltaTime;

                    if (time_check[0] > 1.0f)
                    {
                        time_check[0] = 0.0f;

                        for (int i = 2; i < 4; i++)
                        {
                            change[i] = true;

                            ChangeHandImage(i, true);
                        }
                    }

                    if (change[2] == true)
                    {
                        time_check[2] += Time.deltaTime;

                        if (time_check[2] >= 0.5f)
                        {
                            change[2] = false;
                            ChangeHandImage(2, false);
                            time_check[2] = 0.0f;
                        }
                    }

                    if (change[3] == true)
                    {
                        time_check[3] += Time.deltaTime;

                        if(time_check[3] < 0.5f)
                        {
                            switch (four_way)
                            {
                                case 0:
                                    hand_image[3].transform.Translate(Vector2.right * 2 * Time.deltaTime);
                                    pull.transform.Translate(Vector2.right * 2 * Time.deltaTime);
                                    break;

                                case 1:
                                    hand_image[3].transform.Translate(Vector2.down * 2 * Time.deltaTime);
                                    pull.transform.Translate(Vector2.down * 2 * Time.deltaTime);
                                    break;

                                case 2:
                                    hand_image[3].transform.Translate(Vector2.left * 2 * Time.deltaTime);
                                    pull.transform.Translate(Vector2.left * 2 * Time.deltaTime);
                                    break;

                                case 3:
                                    hand_image[3].transform.Translate(Vector2.up * 2 * Time.deltaTime);
                                    pull.transform.Translate(Vector2.up * 2 * Time.deltaTime);
                                    break;

                            }
                        }

                        if (time_check[3] >= 0.5f)
                        {
                            time_check[3] = 0.0f;
                            change[3] = false;
                            ChangeHandImage(3, false);
                            hand_image[3].transform.position = new Vector3(3.6f, -3, 0);
                            pull.transform.position = new Vector3(3.5f, 1, 0);

                            four_way++;

                            if (four_way > 3)
                                four_way = 0;

                            switch (four_way)
                            {
                                case 0:
                                    {
                                        ChangeDragImage(new Vector3(4.2f, -1.8f, 0), new Vector3(0, 0, 180));
                                    }
                                    break;
                                case 1:
                                    {
                                        ChangeDragImage(new Vector3(3.5f, -2.5f, 0), new Vector3(0, 0, 90));
                                    }
                                    break;
                                case 2:
                                    {
                                        ChangeDragImage(new Vector3(2.9f, -1.8f, 0), new Vector3(0,0,0));
                                    }
                                    break;
                                case 3:
                                    {
                                        ChangeDragImage(new Vector3(3.5f, -1.1f, 0), new Vector3(0, 0, 270));
                                    }
                                    break;
                            }
                        }
                    }
                }
                break;

            case 2:
                {
                    for (int i = 2; i < 4; i++)
                    {
                        player[i].Button_Right_press();
                        player[i].transform.localScale = new Vector3(1.5f, 1.5f, 1);

                    }
                }
                break;
        }
    }

    public void StartFade()
    {
        StartCoroutine(Fade(false, 0));
        StartCoroutine(Fade(true, 1));
    }

    void ChangeDragImage(Vector3 _pos, Vector3 _angle)
    {
        drag_image.transform.position = _pos;
        drag_image.transform.eulerAngles = _angle;
    }

    public void TutorialEnd()
    {
        StartCoroutine(Fade(false, 0f));
        Invoke("StartStage", 1f);
    }

    void ChangeHandImage(int _idx, bool _true)
    {
        if (_true)
        {
            hand_image[_idx].transform.eulerAngles = new Vector3(0, 0, 0);
            hand_image[_idx].transform.localScale = new Vector3(0.8f, 0.8f, 1);
        }

        else
        {
            hand_image[_idx].transform.eulerAngles = new Vector3(0, 0, -30);
            hand_image[_idx].transform.localScale = new Vector3(1, 1, 1);
        }
    }

    void SetActiveObject()
    {
        for(int i = 0; i <tutorial_object.Length; i++)
        {
            if (i == tutorial_idx)
                tutorial_object[i].SetActive(true);

            else
                tutorial_object[i].SetActive(false);
        }

        switch (tutorial_idx)
        {
            case 0:
                {
                    page_button[0].SetActive(false);
                }
                break;

            case 1:
                {
                    page_button[0].SetActive(true);
                    page_button[1].SetActive(true);
                    start_button.SetActive(true);
                }
                break;

            case 2:
                {
                    start_button.SetActive(false);
               //     page_button[1].SetActive(false);

                    for (int i = 2; i < 4; i++)
                        player[i].is_dead = false;

                    player[2].gameObject.transform.position = new Vector3(-6, 2.5f, 0);
                    player[3].gameObject.transform.position = new Vector3(-6, -2.5f, 0);
                }
                break;
        }
    }

    void StartStage()
    {
        SceneManager.LoadScene(6);
    }

    public void PageMove(bool _next)
    {

        if (stop)
            return;

        stop = true;

        if (_next)
            tutorial_idx++;

        else
            tutorial_idx--;

		if (tutorial_idx == 3) {
			TutorialEnd ();
		}
        StartFade();
        
        Invoke("SetActiveObject", 1f);
        Invoke("StopToFalse", 2f);
    }

    void StopToFalse()
    {
        stop = false;
    }

    IEnumerator Fade(bool is_in, float delay)
    {
        yield return new WaitForSeconds(delay);

        if (is_in)
        {
            float t = 1.0f;

            while (t >= 0)
            {
                t -= (Time.deltaTime / fade_time);

                panel.color = new Color(0, 0, 0, t);

                yield return null;
            }

            panel.gameObject.SetActive(false);
        }

        else
        {
            panel.gameObject.SetActive(true);

            float t = 0.0f;

            while (t < 1)
            {
                t += (Time.deltaTime / fade_time);

                panel.color = new Color(0, 0, 0, t);

                yield return null;
            }
        }
    }

    bool IsPointerOverUIObject()
    {
        // Referencing this code for GraphicRaycaster 
        // https://gist.github.com/stramit/ead7ca1f432f3c0f181f
        // the ray cast appears to require only eventData.position.
        PointerEventData eventDataCurrentPosition
            = new PointerEventData(EventSystem.current);
        eventDataCurrentPosition.position
            = new Vector2(Input.mousePosition.x, Input.mousePosition.y);

        List<RaycastResult> results = new List<RaycastResult>();
        EventSystem.current.RaycastAll(eventDataCurrentPosition, results);
        return results.Count > 0;
    }
}
