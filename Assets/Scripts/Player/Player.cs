using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public float speed = 1000f;
    public float jumppower = 8f;
    private float JumpForceCount;

    //[HideInInspector]
    public bool grounded;
    private bool Btn_Left_bool;
    private bool Btn_Right_bool;
    private bool Btn_Jump_bool;
    [HideInInspector]
    public bool PlayerLooksRight;
    private bool isdead;
    [HideInInspector]
    public bool iselevator;

    private Rigidbody2D rb2d;
    [HideInInspector]
    public Animator anim;
    private Vector3 MySpriteOriginalScale;
    //public AudioSource groundAudio;
    public AudioSource jumpAudio;

    public Transform[] saveZone;

    //[HideInInspector]
    public int saveZoneidx = 0;

    void Start()
    {
        rb2d = gameObject.GetComponent<Rigidbody2D>();
        anim = gameObject.GetComponent<Animator>();
        PlayerLooksRight = true;
        MySpriteOriginalScale = transform.localScale;
    }

    void Update()
    {
        if (isdead == true)
            return;

        if(!iselevator)
        {
            anim.SetBool("Grounded", grounded);
        }

        anim.SetFloat("Speed", Mathf.Abs(rb2d.velocity.x));

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            Button_Left_press();
        }
        if (Input.GetKeyUp(KeyCode.LeftArrow))
        {
            Button_Left_release();
        }

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            Button_Right_press();
        }
        if (Input.GetKeyUp(KeyCode.RightArrow))
        {
            Button_Right_release();
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Button_Jump_press();
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            Button_Jump_release();
        }
    }

    void FixedUpdate()
    {
        if (isdead == true)
            return;

        if (Btn_Left_bool == true && Btn_Right_bool == false)
        {
            if (PlayerLooksRight == true)
            {
                PlayerLooksRight = false;
                transform.localScale = new Vector3(-MySpriteOriginalScale.x, MySpriteOriginalScale.y, MySpriteOriginalScale.z);
            }

            this.GetComponent<Rigidbody2D>().AddForce(Vector2.left * speed * Time.deltaTime);
        }

        else if (Btn_Left_bool == false && Btn_Right_bool == true)
        {
            if (PlayerLooksRight == false)
            {
                PlayerLooksRight = true;
                transform.localScale = MySpriteOriginalScale;
            }

            this.GetComponent<Rigidbody2D>().AddForce(Vector2.right * speed * Time.deltaTime);
        }

        if (Btn_Jump_bool == true && JumpForceCount > 0)
        {
            this.GetComponent<Rigidbody2D>().velocity = new Vector2(this.GetComponent<Rigidbody2D>().velocity.x, jumppower);
            JumpForceCount -= 0.1f * Time.deltaTime;
        }


        //땅에 있을때 중력1, 그렇지 않으면 중력2
        if (grounded == true)
        {
            this.GetComponent<Rigidbody2D>().gravityScale = 1f;
        }
        else
        {
            if (this.GetComponent<Rigidbody2D>().gravityScale != 2.5f)
            {
                this.GetComponent<Rigidbody2D>().gravityScale = 2.5f;
            }
        }
    }

    public void Button_Left_press()
    {
        Btn_Left_bool = true;
    }

    public void Button_Left_release()
    {
        Btn_Left_bool = false;
    }

    public void Button_Right_press()
    {
        Btn_Right_bool = true;
    }

    public void Button_Right_release()
    {
        Btn_Right_bool = false;
    }

    public void Button_Jump_press()
    {
        Btn_Jump_bool = true;

        //땅에 있을때 점프
        if (grounded || iselevator)
        {
            JumpForceCount = 0.02f;
            this.GetComponent<Rigidbody2D>().velocity = new Vector2(this.GetComponent<Rigidbody2D>().velocity.x, 0f) + new Vector2(transform.up.x, transform.up.y) * jumppower;
            grounded = false;
            jumpAudio.Play();
            //점프 두번
        }
    }

    public void Button_Jump_release()
    {
        JumpForceCount = 0f;
        Btn_Jump_bool = false;
    }

    IEnumerator PlayerDied()
    {
        yield return new WaitForSeconds(1f);

        ResetPlayer();
        this.transform.position = saveZone[saveZoneidx].position;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Enemy") && !isdead)
        {
            isdead = true;
            anim.SetTrigger("Die");
            StartCoroutine(PlayerDied());
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy") && !isdead)
        {
            isdead = true;
            anim.SetTrigger("Die");
            StartCoroutine(PlayerDied());
        }
    }

    private void ResetPlayer()
    {
        isdead = false;
        transform.localScale = new Vector3(1, 1, 1);
        PlayerLooksRight = true;
        anim.Play("Player_Idle");
        Button_Jump_release();
        Button_Right_release();
        Button_Left_release();
    }
}