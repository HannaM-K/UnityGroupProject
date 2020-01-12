using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndMenu : MonoBehaviour
{
    public Text coinAmount;
    public Text gameScore;
    public Text timeLeft;
    public Text endScore;
    public int endScoreNumber;

    // Start is called before the first frame update
    void Start()
    {
        endScoreNumber = (coinScoreScr.coinAmount * 200) + scoreScr.scoreVal + (UIManager.timeCount * 5);
        coinAmount.text = "Monety: " + coinScoreScr.coinAmount.ToString() +  "* 200 =" + coinScoreScr.coinAmount*200;
        gameScore.text = "Poziom: " + scoreScr.scoreVal;
        timeLeft.text = "Czas: " + UIManager.timeCount.ToString() + " * 5 = " + UIManager.timeCount*5;
        endScore.text = "Wynik końcowy: " + endScoreNumber;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
