using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1Movement : MonoBehaviour
{ 

    public float speed = 3;
    public bool moveLeft = true;
    public Transform wykrywacz;
    Vector2 kierunek = new Vector2(1, 0);


// Update is called once per frame
    public void FixedUpdate()
      {
        
        RaycastHit2D Podloga = Physics2D.Raycast(wykrywacz.position, Vector2.down, 1);
        RaycastHit2D WykryjGracza = Physics2D.Raycast(wykrywacz.position, kierunek, 3);


        


        if (Podloga.collider == true)
        {
            if (!Podloga.collider.CompareTag("Player"))
                {
                transform.Translate(Vector2.left * speed * Time.deltaTime);
            }

        }
        else 
        {
            if (moveLeft == true)
            {
                transform.eulerAngles = new Vector3(0, -180, 0);
                moveLeft = false;
                kierunek = new Vector2(-1, 0);
            }
            else
            {
                transform.eulerAngles = new Vector3(0, 0, 0);
                moveLeft = true;
                kierunek = new Vector2(1, 0);
            }


        }



    }



}