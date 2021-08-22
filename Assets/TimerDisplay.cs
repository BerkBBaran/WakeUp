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
        timerText.text ="0"+ minsLeft.ToString() + ":" + secsLeft.ToString();
    }
}
