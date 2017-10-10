using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleMoveObject : MonoBehaviour {

	public GameObject Crab1;
	public GameObject Crab2;
	public GameObject Crab3;
	public GameObject Crab4;
	public GameObject Crab5;



	private GameObject target = null;
	public Vector2 pos;

	public Animator Ani1;
	public Animator Ani2;
	public Animator Ani3;
	public Animator Ani4;
	public Animator Ani5;
	//private string name = null;

	public bool DragOn1 = true;
	public bool DragOn2 = true;
	public bool DragOn3 = true;
	public bool DragOn4 = true;
	public bool DragOn5 = true;

	public GameObject Null;

    //추가
    bool isDragging;
    bool[] crabs = new bool[5];

    //private void Update()
    //{
    //    if (Input.GetMouseButton(0))
    //    {
    //        CastRay();

    //        if (target.name == "1")
    //        {
    //            isDragging = true;
    //            crabs[0] = true;
    //        }

    //        if (isDragging && crabs[0])
    //        {
    //            Crab1.transform.position = pos;
    //        }
    //    }

    //    if (Input.GetMouseButtonUp(0))
    //    {
    //        isDragging = false;
    //    }
    //}

    // Update is called once per frame
    void FixedUpdate()
    {

        if (Input.GetMouseButtonUp(0))
        {
            Ani1.SetBool("IsOut", false);
            Ani2.SetBool("IsOut", false);
            Ani3.SetBool("IsOut", false);
            Ani4.SetBool("IsOut", false);
            Ani5.SetBool("IsOut", false);
            DragOn1 = true;
            DragOn2 = true;
            DragOn3 = true;
            DragOn4 = true;
            DragOn5 = true;
        }

        /*if (Input.GetMouseButtonUp (0)) {
			Ani1.SetBool ("IsOut", false);
		}else if(this.gameObject.name.Equals("2")){
			Ani2.SetBool ("IsOut", false);
		}else if(this.gameObject.name.Equals("3")){
			Ani3.SetBool ("IsOut", false);
		}else if(this.gameObject.name.Equals("4")){
			Ani4.SetBool ("IsOut", false);
		}else if(this.gameObject.name.Equals("5")){
			Ani5.SetBool ("IsOut", false);
		}*/

        if (Input.GetMouseButton(0))
        {
            CastRay();
            if (target.name == "1" && DragOn1 == true)
            {
                Ani1.SetBool("IsOut", true);
                Crab1.transform.position = pos;
                DragOn2 = false;
                DragOn3 = false;
                DragOn4 = false;
                DragOn5 = false;
            }
            else if (target.name == "2" && DragOn2 == true)
            {
                Ani2.SetBool("IsOut", true);
                Crab2.transform.position = pos;
                DragOn1 = false;
                DragOn3 = false;
                DragOn4 = false;
                DragOn5 = false;
            }
            else if (target.name == "3" && DragOn3 == true)
            {
                Ani3.SetBool("IsOut", true);
                Crab3.transform.position = pos;
                DragOn1 = false;
                DragOn2 = false;
                DragOn4 = false;
                DragOn5 = false;
            }
            else if (target.name == "4" && DragOn4 == true)
            {
                Ani4.SetBool("IsOut", true);
                Crab4.transform.position = pos;
                DragOn1 = false;
                DragOn2 = false;
                DragOn3 = false;
                DragOn5 = false;
            }
            else if (target.name == "5" && DragOn5 == true)
            {
                Ani5.SetBool("IsOut", true);
                Crab5.transform.position = pos;
                DragOn1 = false;
                DragOn2 = false;
                DragOn3 = false;
                DragOn4 = false;
            }
        }
    }

    void CastRay(){
		target = null;
		pos = Camera.main.ScreenToWorldPoint (Input.mousePosition);
		RaycastHit2D hit = Physics2D.Raycast (pos, Vector2.zero, 0f);

		if (hit.collider != null) {

			target = hit.collider.gameObject;
			//Debug.Log (target.name);
		} else {
			target = Null;
		}
	}
}
