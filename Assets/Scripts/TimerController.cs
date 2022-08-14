using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerController : MonoBehaviour
{
    public Text timerText;
    private Timer timer;
    // Start is called before the first frame update
    void Start()
    {
        timerText.text = "02:00";
        timer = Timer.createTimer("GameTime");
        // Start timing with 120s
        timer.startTiming(120, true, OnComplete, OnProcess);
    }

    // Update is called once per frame
    void Update()
    {
    }

    void OnComplete()
    {

    }

    // 计时器的进程
    void OnProcess(float p)
    {
        Debug.Log(FormatTime(p));
        if(timerText!=null){
            timerText.text = FormatTime(p);
        }
    }

    public static string FormatTime(float seconds)
    {
        TimeSpan ts = new TimeSpan(0, 0, Convert.ToInt32(seconds));
        string str = "";
        if (ts.Hours > 0)
        {
            str = ts.Hours.ToString("00") + ":" + ts.Minutes.ToString("00") + ":" + ts.Seconds.ToString("00");
        }
        if (ts.Hours == 0 && ts.Minutes > 0)
        {
            str = ts.Minutes.ToString("00") + ":" + ts.Seconds.ToString("00");
        }
        if (ts.Hours == 0 && ts.Minutes == 0)
        {
            str = "00:" + ts.Seconds.ToString("00");
        }
        return str;
    }
}