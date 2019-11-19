using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy1Movement : MonoBehaviour
{
    public float speed = 3;
    public float run = 1;
    public bool moveLeft = true;
    public Transform detector;
    public Transform eyes;
    public Vector2 kierunek = new Vector2(-1, 0);

    Rigidbody2D rb;
    Animator am;

    private void Awake()
    {
        am = gameObject.GetComponent<Animator>();
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.contacts.Length > 0)
        {
            if (collision.gameObject.tag == "Player")
            {
                ContactPoint2D contact = collision.contacts[0];
                if (Vector2.Dot(contact.normal, Vector2.down) > 0.5)
                {
                    scoreScr.scoreVal += 100;
                    //trzeba go zatrzymać, nie wiem jak
                    //i przechodzi przez ściany
                    am.SetBool("isDead", true);
                    Destroy(gameObject, 1.3f);
                }
                else
                {
                    collision.gameObject.GetComponent<Player>().Death();
                }
            }
            else
            {
                ContactPoint2D contact = collision.contacts[0];
                if (Vector2.Dot(contact.normal, Vector2.left) > 0.5)
                {
                    transform.eulerAngles = new Vector2(0, -180);
                    moveLeft = false;
                }
                else if (Vector2.Dot(contact.normal, Vector2.right) > 0.5)
                {
                    transform.eulerAngles = new Vector2(0, 0);
                    moveLeft = true;
                }
            }

        }
    }
    

   

    public void FixedUpdate()
      {
        
        RaycastHit2D Podloga = Physics2D.Raycast(detector.position, Vector2.down, 1);
        RaycastHit2D Wykryj = Physics2D.Raycast(eyes.position, kierunek, 3);
      
        if (Wykryj.collider == true)
        {
            if(Wykryj.collider.CompareTag("Player"))
            {
                run = 3;
            }
        }
        else
        {
            run = 1;
        }


        if (Podloga.collider == true)
        {
            if (!Podloga.collider.CompareTag("Player"))
            {
                transform.Translate(Vector2.left * speed * run * Time.deltaTime);
            }
        }
        else 
        {
            if (moveLeft == true)
            {
                transform.eulerAngles = new Vector2(0, -180);
                moveLeft = false;
                kierunek = new Vector2(1, 0);
            }
            else
            {
                transform.eulerAngles = new Vector2(0, 0);
                moveLeft = true;
                kierunek = new Vector2(-1, 0);
            }

        }

    }



}