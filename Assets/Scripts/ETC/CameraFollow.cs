using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour
{
    ScreenTransitionImageEffect screeneffect;

    public GameObject followTargetOBJ;
    public GameObject control;
    public GameObject backBtn;

    public float fadeTime;
    public float followSpeed;
    public float[] minxy = new float[2];
    public float[] maxxy = new float[2];

    public bool[] goPuzzele;
    bool isPuzzle;

    public Vector3[] puzzlePos;

    private void Start()
    {
        control.SetActive(false);

        screeneffect = GetComponent<ScreenTransitionImageEffect>();

        StartCoroutine(ScreenEffectStart());
    }

    IEnumerator ScreenEffectStart()
    {
        float t = 1.0f;

        while (t >= 0)
        {
            t -= Time.deltaTime / fadeTime;

            screeneffect.maskValue = t;

            yield return null;
        }

        Destroy(screeneffect);
        control.SetActive(true);
    }

    void FixedUpdate()
    { 
        if(!isPuzzle)
        {
            if (ShowPuzzle.puzzleOn == false)
            {
                Vector3 NewPosition = Vector3.Lerp(this.transform.position, followTargetOBJ.transform.position, followSpeed * Time.deltaTime);
                NewPosition = new Vector3(Mathf.Clamp(NewPosition.x, minxy[0], maxxy[0]), Mathf.Clamp(NewPosition.y, minxy[1], maxxy[1]), NewPosition.z);
                this.transform.position = new Vector3(NewPosition.x, NewPosition.y, this.transform.position.z);
            }
            else if (ShowPuzzle.puzzleOn == true)
            {
                this.transform.position = new Vector3(-27.73f, 0f, -10);
            }

            if (ShowPuzzle.puzzleClear == true)
            {
                Transform tr = GameObject.FindWithTag("Player").GetComponent<Transform>();

                this.transform.position = new Vector3(tr.position.x, tr.position.y, -10);
                control.SetActive(true);
                ShowPuzzle.puzzleOn = false;
                ShowPuzzle.puzzleClear = false;
            }
        }
    }

    public void CheckPuzzle()
    {
        isPuzzle = true;
        control.SetActive(false);
        backBtn.SetActive(true);

        for (int i = 0; i < goPuzzele.Length; i++)
        {
            if(goPuzzele[i] == true)
            {
                this.transform.position = puzzlePos[i];
            }
        }
    }

    public void CheckPlayer()
    {
        isPuzzle = false;

        Transform tr = GameObject.FindWithTag("Player").GetComponent<Transform>();

        this.transform.position = new Vector3(tr.position.x, tr.position.y, -10);

        control.SetActive(true);
        backBtn.SetActive(false);
    }
}
