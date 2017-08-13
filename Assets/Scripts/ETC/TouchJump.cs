using UnityEngine;
using System.Collections;

public class TouchJump : MonoBehaviour
{
    public Player player;

    public void OnPress_IE()
    {
        player.Button_Jump_press();
    }

    public void OnRelease_IE()
    {
        player.Button_Jump_release();
    }


}
