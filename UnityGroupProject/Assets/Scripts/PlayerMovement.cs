using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Sprite defaultSprite;
    public Sprite shellSprite;
    //więcej klatek animacji/dym

    //jak będzie trzeba to zmienić
    public float stepSize = 5;
    public float jumpPower = 12;
    public float specialAttackTime = 3;
    public float specialAttackSpeedMultiplier = 2;
    public float specialAttackJumpMultiplier = 0.5f;

    float movement;
    bool jumped;
    public static bool specialAttack = false;
    bool startSpecialAttack = false;

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


        if (Input.GetKey(KeyCode.UpArrow) && isOnGround)
        {
            jumped = true;
        }

        if (Input.GetKey(KeyCode.RightControl))
        {
            specialAttack = true;
        }
    }

    void FixedUpdate()
    {
        rb.velocity = new Vector2(movement, rb.velocity.y);

        if (specialAttack)
        {
            if (startSpecialAttack == false)
            {
                
                gameObject.GetComponent<BoxCollider2D>().size = new Vector2(0.28f, 0.20f);
                jumpPower = 8;
                jumped = true; // added a little jump here
                startSpecialAttack = true;
                am.SetBool("startedAttacking", true);
                sr.sprite = shellSprite;
                Invoke("StopSpecialAttack", 5);
            }
            rb.velocity = new Vector2(rb.velocity.x * specialAttackSpeedMultiplier, rb.velocity.y);
            
        }

        if (jumped)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpPower);
            jumped = false;
        }

    }

    void StopSpecialAttack()
    {
        if (startSpecialAttack == true)
        {
            gameObject.GetComponent<BoxCollider2D>().size = new Vector2(0.32f, 0.64f);
            startSpecialAttack = false;
        }
        am.SetBool("startedAttacking", false);
        jumpPower = 12;
        sr.sprite = defaultSprite;
        specialAttack = false;
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