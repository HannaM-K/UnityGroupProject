using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1Movement : MonoBehaviour
{ 

    public float speed = 3;
    public bool moveLeft = true;
    public Transform wykrywacz;


  

    // Update is called once per frame

    public void FixedUpdate()
      {
        
        RaycastHit2D Podloga = Physics2D.Raycast(wykrywacz.position, Vector2.down, 1);
       




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

            }
            else
            {
                transform.eulerAngles = new Vector3(0, 0, 0);
                moveLeft = true;

            }


        }



    }



}