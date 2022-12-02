using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CountDown : MonoBehaviour
{
    public float currentTime;
    public bool countdownStart;
    public bool countdownFinish;
    TMP_Text countdownText;

    // Start is called before the first frame update
    void Start()
    {
        countdownText = GameObject.FindGameObjectWithTag("Countdown").GetComponent<TMP_Text>();
        countdownText.text = "";
    }

    // Update is called once per frame
    void Update()
    {
        if (countdownStart && currentTime > 0)
        {
            currentTime -= Time.deltaTime;
            countdownText.text = "Time: " + currentTime.ToString("F2");
        }
            
        if (currentTime <= 0)
        {
            currentTime = 0;
            countdownFinish = true;
            countdownText.text = "Time: " + currentTime.ToString("F2");
        }
        
        if (countdownFinish)
        {
            this.enabled = false;
        }
    }

    public void StartCountdown()
    {
        countdownStart = true;
    }
        
}
