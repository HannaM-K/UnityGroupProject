﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Sprite defaultSprite;
    public Sprite shellSprite;

    //jak będzie trzeba to zmienić
    public float stepSize = 5;
    public float jumpPower = 12;

    public float specialAttackTime = 4;
    public float specialAttackSpeedMultiplier = 2;
    public float specialAttackCooldown = 8; //w sekundach

    float movement;
    bool jumped;

    public static bool specialAttackMode = false;
    bool startedSpecialAttack = false;

    float timeStamp;

    //publiczne tylko do podglądu przy testach
    public bool isFacingRight = true;
    public bool isOnGround = true;

    //dzwieki
    //public AudioSource PlayerAudioSource;
    //public AudioSource SpecialAttackSource;

    public AudioClip jumpingSound;
    public AudioClip spAttackSound;

    AudioSource audios;
    Rigidbody2D rb;
    SpriteRenderer sr;
    Animator am;
    public Animator amUIAttack;
    


    void Awake()
    {
        timeStamp = -specialAttackCooldown; //żeby na starcie wynosił 0
        rb = gameObject.GetComponent<Rigidbody2D>();
        sr = gameObject.GetComponent<SpriteRenderer>();
        am = gameObject.GetComponent<Animator>();
        audios = gameObject.GetComponent<AudioSource>();
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

        if (Input.GetKey(KeyCode.RightControl) && Time.time > timeStamp + specialAttackCooldown)
        {
            specialAttackMode = true;
            audios.PlayOneShot(spAttackSound);
        }
    }

    void FixedUpdate()
    {
        rb.velocity = new Vector2(movement, rb.velocity.y);

        if (specialAttackMode)
        {
            if (startedSpecialAttack == false)
            {
                gameObject.GetComponent<BoxCollider2D>().size = new Vector2(0.28f, 0.20f);

                jumpPower = 8;
                jumped = true;
                
                startedSpecialAttack = true;
                am.SetBool("startedAttacking", true);

                amUIAttack.Play("specialAttackUsed");

                sr.sprite = shellSprite;
                Invoke("StopSpecialAttack", specialAttackTime);
            }
            rb.velocity = new Vector2(rb.velocity.x * specialAttackSpeedMultiplier, rb.velocity.y);
        }

        if (jumped)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpPower);
            if (!audios.isPlaying) audios.PlayOneShot(jumpingSound);
            jumped = false;
        }

    }

    void StopSpecialAttack()
    {
        if (startedSpecialAttack == true)
        {
            gameObject.GetComponent<BoxCollider2D>().size = new Vector2(0.32f, 0.64f);
            am.SetBool("startedAttacking", false);
            audios.PlayOneShot(spAttackSound);
            amUIAttack.Play("specialAttackCooldown");
            jumpPower = 12;
            sr.sprite = defaultSprite;
            specialAttackMode = false;

            startedSpecialAttack = false;

            timeStamp = Time.time;
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