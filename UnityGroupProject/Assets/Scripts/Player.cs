using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Canvas canvas;
    public void Death()
    {
        UIManager.lifeCount -= 1;
        canvas.GetComponent<UIManager>().SetUI();
        Debug.Log("Tu giniesz. WOW");
        Debug.Log("Pozostało " + UIManager.lifeCount + " żyć.");

        //animacja - miganie czy coś
    }
}
