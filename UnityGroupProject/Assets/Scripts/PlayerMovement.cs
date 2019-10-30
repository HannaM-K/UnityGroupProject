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

    void Awake()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        sr = gameObject.GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.RightArrow))
        {
            //anim
            movement = stepSize;
            isFacingRight = true;
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            //anim
            movement = -stepSize;
            isFacingRight = false;
        }
        else movement = 0;

        sr.flipX = !isFacingRight;

        if (Input.GetKeyDown(KeyCode.UpArrow) && isOnGround)
        {
            //anim
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

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Ground") isOnGround = true;
        if (collision.gameObject.tag == "Enemy" && !isOnGround) collision.gameObject.GetComponent<Enemy>().Death();
    }
    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Ground") isOnGround = false;
    }

}
