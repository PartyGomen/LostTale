using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;
using UnityEngine.UI;

public class VirtualJoyStick : MonoBehaviour, IDragHandler, IPointerUpHandler, IPointerDownHandler {
	public Player player;

	private Image bgImg;
	private Image joystickImg;
	public Vector3 inputVector;

	private void Start(){
		bgImg = GetComponent<Image> ();
		joystickImg = transform.GetChild (0).GetComponent<Image> ();
	
	}

	void Update ()
	{
		if (inputVector.x > 0) {
			player.Button_Right_press();
			player.Button_Left_release();
		} else if(inputVector.x < 0){
			player.Button_Left_press();
			player.Button_Right_release();
		}


	}

	public virtual void OnDrag(PointerEventData ped){
		Vector2 pos;
		if (RectTransformUtility.ScreenPointToLocalPointInRectangle (bgImg.rectTransform, ped.position, ped.pressEventCamera, out pos)) {
			pos.x = (pos.x / bgImg.rectTransform.sizeDelta.x);
			pos.y= (pos.y / bgImg.rectTransform.sizeDelta.y);

			inputVector = new Vector3(pos.x*2, 0 ,0);
			inputVector = (inputVector.magnitude > 1.0f) ? inputVector.normalized : inputVector;
			joystickImg.rectTransform.anchoredPosition = new Vector3 (inputVector.x * (bgImg.rectTransform.sizeDelta.x/4), 0, 0);
		}
	}

	public virtual void OnPointerDown(PointerEventData ped){
		OnDrag (ped);
	}

	public virtual void OnPointerUp(PointerEventData ped){
		inputVector = Vector3.zero;
		joystickImg.rectTransform.anchoredPosition = Vector3.zero;
		player.Button_Left_release();
		player.Button_Right_release();
	}
}
