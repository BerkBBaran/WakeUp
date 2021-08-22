using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TimerDisplay : MonoBehaviour
{
    public TextMeshProUGUI timerText;
 
    public void UpdateTime(int timeLeft)
    {
        int minsLeft = timeLeft / 60;
        int secsLeft = timeLeft - (minsLeft * 60);
        string secsPiece = secsLeft.ToString();
        if(secsLeft < 10)
        {
            secsPiece = "0" + secsPiece;
        }
        timerText.text = "0" + minsLeft.ToString() + ":" + secsPiece;
    }
}
