using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour
{
    public GameObject FollowTargetOBJ;
    public float FollowSpeed;
    public float[] minxy = new float[2];
    public float[] maxxy = new float[2];
	public GameObject Control;

    void FixedUpdate()
    {
         //Vector3 PositionBefore = this.transform.position;

		if (ShowPuzzle.puzzleOn == false)
        {
			Vector3 NewPosition = Vector3.Lerp (this.transform.position, FollowTargetOBJ.transform.position, FollowSpeed * Time.deltaTime);
			NewPosition = new Vector3 (Mathf.Clamp (NewPosition.x, minxy [0], maxxy [0]), Mathf.Clamp (NewPosition.y, minxy [1], maxxy [1]), NewPosition.z);
			this.transform.position = new Vector3 (NewPosition.x, NewPosition.y, this.transform.position.z);    
		}
        else if (ShowPuzzle.puzzleOn == true)
        {
			this.transform.position = new Vector3 (-27.73f, 0f, -10);
		}
        
		if (ShowPuzzle.puzzleClear == true)
        {
            Transform tr = GameObject.FindWithTag("Player").GetComponent<Transform>();

			this.transform.position = new Vector3(tr.position.x, tr.position.y, -10);
			Control.SetActive (true);
			ShowPuzzle.puzzleOn = false;
			ShowPuzzle.puzzleClear = false;
		}
    }
}
