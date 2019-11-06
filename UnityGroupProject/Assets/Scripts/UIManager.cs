using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static int lifeCount = 3;

    public Text lifeCounter;

    void Awake()
    {
        LifeUI();
    }

    public void LifeUI()
    {
        lifeCounter.text = "Ilość żyć: " + lifeCount;
    }
}
