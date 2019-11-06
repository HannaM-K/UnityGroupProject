using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDeath : MonoBehaviour
{

    void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.contacts.Length > 0)
        {
            if(collision.gameObject.tag == "Player"){
                ContactPoint2D contact = collision.contacts[0];
                if (Vector2.Dot(contact.normal, Vector2.down) > 0.5)
                {
                    Destroy(gameObject);
                }
                else
                {
                    Debug.Log("Tu giniesz. WOW");
                }
            }

        }
    }
    /*
    void OnCollision2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            Destroy(transform.parent.gameObject);
        }
    }
    */
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
