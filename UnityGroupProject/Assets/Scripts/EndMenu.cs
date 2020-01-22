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
    int endScoreNumber = 0;
    void Start()
    {
        endScoreNumber = (coinScoreScr.coinAmount * 200) + scoreScr.scoreVal + (UIManager.timeCount * 5);
        coinAmount.text = coinScoreScr.coinAmount.ToString();
        gameScore.text = scoreScr.scoreVal.ToString();
        timeLeft.text = UIManager.timeCount.ToString();
        endScore.text = endScoreNumber.ToString();
    }
}
