using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float jumpPower = 10.0f;
    public bool jumping = false;
    public Sprite jump;
    public Sprite jumpEnd;

    public Animator anim;
    public SpriteRenderer sr;
    public Rigidbody2D rb;
    public BoxCollider2D bc;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("land"))
        {
            rb.gravityScale = 2;
            anim.SetBool("is_Jump", false);
            jumping = false;
        }
    }

    void Update()
    {
        if ((Input.GetMouseButton(0) || Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.Space)) && jumping == false && !GameManager.Game_over)
        {
            anim.SetBool("is_Jump", true);
            jumping = true;
            sr.sprite = jump;
            rb.velocity = Vector2.up * jumpPower;
        }

        if(Input.GetKeyDown(KeyCode.DownArrow) && jumping == true)
        {
            rb.gravityScale = 10;
        }
    }

}
