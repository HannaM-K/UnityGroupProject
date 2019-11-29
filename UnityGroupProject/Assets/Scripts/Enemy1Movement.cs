﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy1Movement : MonoBehaviour
{
    public float speed = 3;
    public float run = 1;
    private bool zycie = true;
    public bool moveLeft = true;
    public Transform detector;
    public Transform eyes;
    public Vector2 kierunek = new Vector2(-1, 0);

    void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.contacts.Length > 0)
        {




            if (collision.gameObject.tag == "Player")
            {
                ContactPoint2D contact = collision.contacts[0];
                if (Vector2.Dot(contact.normal, Vector2.down) > 0.5)
                {
                    zycie = false;
                    //@@@ANIMACJA@@@
                    scoreScr.scoreVal += 100;
                    Destroy(gameObject);
                }
                else
                {
                    collision.gameObject.GetComponent<Player>().Death();
                    run = 1;
                }
            }
            else
            //if (collision.contacts[0].normal == Vector2.left || collision.contacts[0].normal == Vector2.right)
            {


                Zmiana();

            }

        }

    }






    public void Update()
    {

        RaycastHit2D Podloga = Physics2D.Raycast(detector.position, Vector2.down, 0.5f);
        RaycastHit2D Wykryj = Physics2D.Raycast(eyes.position, kierunek, 3);

        if (Wykryj.collider == true)
        {
            if (Wykryj.collider.CompareTag("Player"))
            {
                run = 2;
            }
        }
        else
        {
            run = 1;
        }


        if (Podloga.collider == true)
        {

            Idz();
            
        }
        else
        {
            Zmiana();

        }

    }

    public void Zmiana()
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

    public void Idz()
    {
        if (zycie == true)
        {
            transform.Translate(Vector2.left * speed * run * Time.deltaTime);
        }
    }


}