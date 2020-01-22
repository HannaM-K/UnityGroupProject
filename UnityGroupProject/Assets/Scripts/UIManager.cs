using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public static int timeCount;
    private int interval;
    private float nextUpdate;

    public static int lifeCount = 3;
    public GameObject player;
    public Text lifeCounter;
    public Text timeCounter;
    public GameObject gameOverCanvas;
    public GameObject pauseCanvas;

    public AudioListener audioListener;
    AudioSource bgAudio;
    void Awake()
    {
        InitVariables();
        bgAudio = gameObject.GetComponent<AudioSource>();

        if (SettingsMenu.IsSoundOn) AudioListener.volume = 1;
        else AudioListener.volume = 0;
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
        lifeCounter.text = "x" + lifeCount;
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
                //Debug.Log("Koniec gry. Czas się skończył.");
                //Application.Quit();
                bgAudio.Stop();
                gameOverCanvas.SetActive(true);
                Time.timeScale = 0f;
            }
        }
        if (lifeCount == 0)
        {
           bgAudio.Stop();
           gameOverCanvas.SetActive(true);
           Time.timeScale = 0f;
        }
        if (Input.GetKeyDown(KeyCode.Escape) && !gameOverCanvas.activeSelf)
        {
            if (pauseCanvas.activeSelf)
            {
                Time.timeScale = 1f;
                pauseCanvas.SetActive(false);
                player.SetActive(true);
            }
            else if (!pauseCanvas.activeSelf)
            {
                Time.timeScale = 0f;
                pauseCanvas.SetActive(true);
                player.SetActive(false);
            }
        }
            
    }
    public void LoadMenu()
    {
        Time.timeScale = 1f;
        Debug.Log("Powrot do menu.");
        SceneManager.LoadScene("Menu_Scene");
        InitVariables();
    }

    public void RestartGame()
    {
        Time.timeScale = 1f;
        Debug.Log("Reload scene.");
        Debug.Log("timeScale: " + Time.timeScale);
        SceneManager.LoadScene("Main_Scene");
        InitVariables();
    }
}
