using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    public int usedC = 0;
    public Sprite mySprite;
 
    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Player" && usedC==0)
        {
            usedC = 1;
            Player.checkpoint = transform.position;
            this.GetComponent<SpriteRenderer>().sprite = mySprite;
        }
    }
}
