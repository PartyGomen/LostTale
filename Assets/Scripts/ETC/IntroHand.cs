using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroHand : MonoBehaviour
{
    private SpriteRenderer[] hands;
    private Transform handImage;

    public delegate IEnumerator Fadedelegate();
    public Fadedelegate fadeDelegateHandler;

    void Start ()
    {
        hands = GetComponentsInChildren<SpriteRenderer>(true);
        handImage = hands[0].GetComponent<Transform>();

        StartCoroutine(Touch());
	}

    private IEnumerator Fade()
    {
        float alpha = 0;
        handImage.eulerAngles = new Vector3(0, 0, -30);
        hands[1].gameObject.SetActive(false);

        while (alpha <= 1)
        {
            for (int i = 0; i < hands.Length; i++)
            {
                hands[i].color = new Color(1, 1, 1, alpha);
            }

            alpha += Time.deltaTime;

            yield return null;
        }
    }

    public IEnumerator Touch()
    {
        yield return StartCoroutine(Fade());

        while(true)
        {
            handImage.eulerAngles = new Vector3(0, 0, 0);
            hands[1].gameObject.SetActive(true);

            yield return new WaitForSeconds(0.5f);

            handImage.eulerAngles = new Vector3(0, 0, -30);
            hands[1].gameObject.SetActive(false);

            yield return new WaitForSeconds(0.5f);
        }
    }
}
