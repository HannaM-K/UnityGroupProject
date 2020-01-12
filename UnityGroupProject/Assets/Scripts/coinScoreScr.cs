using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class coinScoreScr : MonoBehaviour
{
    Text coinText;
    public static int coinAmount;

    void Start()
    {
        coinText = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        coinText.text = "Monety: " + coinAmount.ToString();
    }
}
