using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderTriggerOn : MonoBehaviour
{
    public bool this_trigger;

    private GameObject obj;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            switch (this_trigger)
            {
                case true:
                    {
                        GetComponent<BoxCollider2D>().isTrigger = true;
                    }
                    break;

                case false:
                    {
                        obj = collision.gameObject;
                        StartCoroutine(TriggerSetActive(true, 0f));
                        StartCoroutine(TriggerSetActive(false, 1f));
                    }
                    break;
            }
        }
    }

    IEnumerator TriggerSetActive(bool is_true, float delay)
    {
        yield return new WaitForSeconds(delay);

        obj.GetComponent<BoxCollider2D>().isTrigger = is_true;
    }
}
