using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public float speed = 1000f;
    public float jump_power = 8.5f;
    private float jump_force_count;

    //[HideInInspector]
    public bool grounded;
    private bool btn_left_bool;
    private bool btn_right_bool;
    private bool btn_jump_bool;
    [HideInInspector]
    public bool player_looks_right;
    public bool is_dead;
    [HideInInspector]
    public bool is_elevator;

    private Rigidbody2D rb2d;
    [HideInInspector]
    public Animator anim;
    private Vector3 my_sprite_originalscale;
    //public AudioSource groundAudio;
    public AudioSource jump_audio;
    public AudioSource death_audio;

    public Transform[] save_zone;

    //[HideInInspector]
    public int saveZoneidx = 0;

    void Start()
    {
        rb2d = gameObject.GetComponent<Rigidbody2D>();
        anim = gameObject.GetComponent<Animator>();
        player_looks_right = true;
        my_sprite_originalscale = transform.localScale;
    }

    void Update()
    {
        if (is_dead == true)
            return;

        if(!is_elevator)
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
        if (is_dead == true)
            return;

        if (btn_left_bool == true && btn_right_bool == false)
        {
            if (player_looks_right == true)
            {
                player_looks_right = false;
                transform.localScale = new Vector3(-my_sprite_originalscale.x, my_sprite_originalscale.y, my_sprite_originalscale.z);
            }

            rb2d.AddForce(Vector2.left * speed * Time.deltaTime);
        }

        else if (btn_left_bool == false && btn_right_bool == true)
        {
            if (player_looks_right == false)
            {
                player_looks_right = true;
                transform.localScale = my_sprite_originalscale;
            }

            rb2d.AddForce(Vector2.right * speed * Time.deltaTime);
        }

        if (btn_jump_bool == true && jump_force_count > 0)
        {
            rb2d.velocity = new Vector2(rb2d.velocity.x, jump_power);
            jump_force_count -= 0.1f * Time.deltaTime;
        }


        //땅에 있을때 중력1, 그렇지 않으면 중력2
        if (grounded == true)
        {
            rb2d.gravityScale = 1f;
        }
        else
        {
            if (rb2d.gravityScale != 2.5f)
            {
                rb2d.gravityScale = 2.5f;
            }
        }
    }

    public void Button_Left_press()
    {
        btn_left_bool = true;
    }

    public void Button_Left_release()
    {
        btn_left_bool = false;
    }

    public void Button_Right_press()
    {
        btn_right_bool = true;
    }

    public void Button_Right_release()
    {
        btn_right_bool = false;
    }

    public void Button_Jump_press()
    {
        btn_jump_bool = true;

        //땅에 있을때 점프
        if (grounded || is_elevator)
        {
            jump_force_count = 0.02f;
            rb2d.velocity = new Vector2(rb2d.velocity.x, 0f) + new Vector2(transform.up.x, transform.up.y) * jump_power;
            grounded = false;
            jump_audio.Play();
            //점프 두번
        }
    }

    public void Button_Jump_release()
    {
        jump_force_count = 0f;
        btn_jump_bool = false;
    }

    IEnumerator PlayerDied()
    {
        yield return new WaitForSeconds(1f);

        ResetPlayer();
        this.transform.position = save_zone[saveZoneidx].position;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Enemy") && !is_dead)
        {
            is_dead = true;
            death_audio.Play();
            anim.SetTrigger("Die");
            StartCoroutine(PlayerDied());
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy") && !is_dead)
        {
            is_dead = true;
            death_audio.Play();
            anim.SetTrigger("Die");
            StartCoroutine(PlayerDied());
        }
    }

    private void ResetPlayer()
    {
        is_dead = false;
        transform.localScale = new Vector3(1, 1, 1);
        player_looks_right = true;
        anim.Play("Player_Idle");
        Button_Jump_release();
        Button_Right_release();
        Button_Left_release();
    }
}