using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class PlayerJoystick : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public Player player;
    private Slider slider;

    public void OnPointerEnter(PointerEventData eventData)
    {
        slider.interactable = true;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        slider.interactable = false;
        player.Button_Left_release();
        player.Button_Right_release();
        slider.value = 0.5f;
    }

    private void Start()
    {
        slider = GetComponent<Slider>();
        slider.value = 0.5f;
    }

    // Update is called once per frame
    void Update ()
    {
        if(slider.value > 0.5f)
        {
            player.Button_Right_press();
            player.Button_Left_release();
        }

        else if(slider.value < 0.5f)
        {
            player.Button_Left_press();
            player.Button_Right_release();
        }
	}
}
