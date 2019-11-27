using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //jak będzie trzeba to zmienić
    public float stepSize = 5;
    public float jumpPower = 12;

    float movement;
    bool jumped;

    //publiczne tylko do podglądu przy testach
    public bool isFacingRight = true;
    public bool isOnGround = true;

    Rigidbody2D rb;
    SpriteRenderer sr;
    Animator am;

    void Awake()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        sr = gameObject.GetComponent<SpriteRenderer>();
        am = gameObject.GetComponent<Animator>();
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.RightArrow))
        {
            am.SetBool("isWalking", true);
            movement = stepSize;
            isFacingRight = true;
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            am.SetBool("isWalking", true);
            movement = -stepSize;
            isFacingRight = false;
        }
        else
        {
            am.SetBool("isWalking", false);
            movement = 0;
        }

        sr.flipX = !isFacingRight;


        if (Input.GetKeyDown(KeyCode.UpArrow) && isOnGround)
        {
            jumped = true;
        }
    }

    //w FixedUpdate Rigidbody
    void FixedUpdate()
    {
        rb.velocity = new Vector2(movement, rb.velocity.y);

        if (jumped)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpPower);
            jumped = false;
        }

    }


    void OnCollisionStay2D(Collision2D collision)
        {
            if (collision.contacts.Length > 0)
            {
                ContactPoint2D contact = collision.contacts[0];
                if (Vector2.Dot(contact.normal, Vector2.up) > 0.5)
                {
                    isOnGround = true;
                    am.SetBool("isJumping", false);
                }

            }
        }
    void OnCollisionExit2D(Collision2D collision)
        {
            am.SetBool("isJumping", true);
            isOnGround = false;
        }

    }