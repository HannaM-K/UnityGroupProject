using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    private int timeCount;
    private int interval;
    private float nextUpdate;

    public static int lifeCount = 3;
    public Player player;
    public Text lifeCounter;
    public Text timeCounter;

    void Awake()
    {
        nextUpdate = 0;
        timeCount = 500;
        interval = 1;
        timeCounter.text = (timeCount).ToString();
        SetLifeCounter();
    }

    public void SetLifeCounter()
    {
        lifeCounter.text = "Ilość żyć: " + lifeCount;
    }

    public void Update()
    {
        if (Time.time >= nextUpdate)
        {
            nextUpdate += interval;
            if (timeCount >= 0)
            {
                timeCounter.text = (timeCount--).ToString();
            }
            else
            {
                //tutaj jakieś zakończenie gry
                Application.Quit();
            }
        }
    }
}
