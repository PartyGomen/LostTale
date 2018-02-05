using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CameraFollow : MonoBehaviour
{
    ScreenTransitionImageEffect screeneffect;

    public GameObject followTargetOBJ;
    public GameObject control;
    public GameObject arrowController;
    public GameObject backBtn;
    public GameObject bulb_object;
    public GameObject[] block_btn = new GameObject[2];
    public Image[] success = new Image[2];

    public float fadeTime;
    public float followSpeed;
    public float[] minxy = new float[2];
    public float[] maxxy = new float[2];

    public bool[] goPuzzele;
    bool isPuzzle;

    public Vector3[] puzzlePos;

    public Image panel;
   
	public int Stage;

    private void Start()
    {
        control.SetActive(false);
        arrowController.SetActive(false);

        screeneffect = GetComponent<ScreenTransitionImageEffect>();

        StartCoroutine(ScreenEffectStart());
        StartCoroutine(Fade(true, 0f));
    }

    IEnumerator Fade(bool is_in, float delay)
    {
        yield return new WaitForSeconds(delay);

        if(is_in)
        {
            float t = 1.0f;

            while (t >= 0)
            {
                t -= (Time.deltaTime / fadeTime);

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
                t += (Time.deltaTime / fadeTime);

                panel.color = new Color(0, 0, 0, t);

                yield return null;
            }
        }
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

        //Destroy(screeneffect);
		if (Stage !=1){
            arrowController.SetActive(true);
            control.SetActive(true);
        }
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
        }
    }
    
    public void CheckPuzzleOrPlayer(bool is_puzzle)
    {
        if (is_puzzle)
        {
            control.SetActive(false);
            arrowController.SetActive(false);
            Invoke("CheckPuzzle", 1f);
        }
        else
            Invoke("CheckPlayer", 2f);
    }

    public void CheckPuzzle()
    {
        isPuzzle = true;
        control.SetActive(false);
        arrowController.SetActive(false);
        backBtn.SetActive(true);
		bulb_object.SetActive(true);

        for (int i = 0; i < goPuzzele.Length; i++)
        {
            if(goPuzzele[i] == true)
            {
                this.transform.position = puzzlePos[i];
            }
        }

        for(int i = 0; i < block_btn.Length; i++)
        {
            block_btn[i].SetActive(false);
        }
    }

    public void CheckPlayer()
    {
        isPuzzle = false;

        for (int i = 0; i < goPuzzele.Length; i++)
        {
            goPuzzele[i] = false;
        }

        Transform tr = GameObject.FindWithTag("Player").GetComponent<Transform>();

        this.transform.position = new Vector3(tr.position.x, tr.position.y, -10);

		control.SetActive (true);
        arrowController.SetActive(true);
        backBtn.SetActive(false);
        bulb_object.SetActive(false);

        for (int i = 0; i < success.Length; i++)
        {
            success[i].gameObject.SetActive(false);
        }

        for (int i = 0; i < block_btn.Length; i++)
        {
            block_btn[i].SetActive(true);
        }
    }

    public void FadeCoroutine(bool fade_in, float delay_time)
    {
        StartCoroutine(Fade(fade_in, delay_time));
    }
}
