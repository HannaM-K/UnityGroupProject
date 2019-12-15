using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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
        InitVariables();
    }
    public void InitVariables()
    {
        nextUpdate = 0;
        timeCount = 500;
        interval = 1;
        lifeCount = 3;
        scoreScr.scoreVal = 0;
        coinScoreScr.coinAmount = 0;
        timeCounter.text = (timeCount).ToString();
        SetLifeCounter();
    }

    public static void SubstractLife()
    {
        if (lifeCount - 1 >= 0)
        {
            lifeCount--;
        }
    }

    public void SetLifeCounter()
    {
        lifeCounter.text = "Ilość żyć: " + lifeCount;
    }

    public void Update()
    {
        if (Time.timeSinceLevelLoad >= nextUpdate)
        {
            Debug.Log(Time.time);
            nextUpdate += interval;
            if (timeCount >= 0)
            {
                timeCounter.text = (timeCount--).ToString();
            }
            else
            {
                //tutaj jakieś zakończenie gry
                Debug.Log("Koniec gry. Czas się skończył.");
                Application.Quit();
            }
        }
        if (Input.GetKeyDown(KeyCode.Escape) || lifeCount == 0)
        {
            LoadMenu();
        }
    }
    void LoadMenu()
    {
        Debug.Log("Powrot do menu.");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        InitVariables();
    }
}
