using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1Movement : MonoBehaviour
{ 

    public float speed = 3;
    public float run = 1;
    public bool moveLeft = true;
<<<<<<< HEAD
    public Transform detector;
    public Transform eyes;
    public Vector2 kierunek = new Vector2(-1, 0);

    // Update is called once per frame

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
=======
    public Transform wykrywacz;
    Vector2 kierunek = new Vector2(1, 0);


// Update is called once per frame
    public void FixedUpdate()
      {
        
        RaycastHit2D Podloga = Physics2D.Raycast(wykrywacz.position, Vector2.down, 1);
        RaycastHit2D WykryjGracza = Physics2D.Raycast(wykrywacz.position, kierunek, 3);


        
>>>>>>> parent of 628b187... Poprawa


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
                transform.eulerAngles = new Vector3(0, -180, 0);
                moveLeft = false;
<<<<<<< HEAD
                kierunek = new Vector2(1, 0);
=======
                kierunek = new Vector2(-1, 0);
>>>>>>> parent of 628b187... Poprawa
            }
            else
            {
                transform.eulerAngles = new Vector3(0, 0, 0);
                moveLeft = true;
<<<<<<< HEAD
                kierunek = new Vector2(-1, 0);
=======
                kierunek = new Vector2(1, 0);
>>>>>>> parent of 628b187... Poprawa
            }

        }

    }



}