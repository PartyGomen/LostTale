using UnityEngine;
using System.Collections;

public class TouchArrow : MonoBehaviour
{
    public Player player;

    private bool IsPressed;
    private bool RightSide;
    private bool LeftSide;

    private int StoredTouchID;

    void Start()
    {
        IsPressed = false;
        RightSide = false;
        LeftSide = false;
    }

    void Update()
    {
        if (IsPressed == true)
        {

            if (RightSide == true && TouchCamera.DragPos[StoredTouchID].x < this.transform.position.x)
            {
                RightSide = false;
                LeftSide = true;

                player.Button_Right_release();
                player.Button_Left_press();

            }

            else if (RightSide == false && TouchCamera.DragPos[StoredTouchID].x > this.transform.position.x)
            {
                RightSide = true;
                LeftSide = false;

                player.Button_Left_release();
                player.Button_Right_press();

            }
        }
    }



    public void OnPress_IE(int TouchID)
    {
        StoredTouchID = TouchID;

        IsPressed = true;

        if (TouchCamera.inputHitPos[StoredTouchID].x < this.transform.position.x)
        {
            LeftSide = true;
            player.Button_Left_press();
        }
        else
        {
            RightSide = true;
            player.Button_Right_press();
        }

    }

    public void OnRelease_IE(int TouchID)
    {
        if (TouchCamera.inputHitPos[StoredTouchID].x < this.transform.position.x)
        {
            LeftSide = false;
            player.Button_Left_release();
        }

        else
        {
            RightSide = false;
            player.Button_Right_release();
        }

        if (RightSide == false && LeftSide == false)
        {
            IsPressed = false;
        }
    }

}
