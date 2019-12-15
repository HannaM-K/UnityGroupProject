using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Canvas canvas;
    public static Vector2 checkpoint = new Vector2(0,0);
    void Awake()
    {
        print(transform.position);
        checkpoint = transform.position;
    }
   

    public void Death()
    {
        UIManager.SubstractLife();
        canvas.GetComponent<UIManager>().SetLifeCounter();
        transform.position = checkpoint;
        Debug.Log("Tu giniesz. WOW");
        Debug.Log("Pozostało " + UIManager.lifeCount + " żyć.");

        //animacja - miganie czy coś
    }
}
