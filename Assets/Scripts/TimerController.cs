using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TimerController : MonoBehaviour
{
    public Text timerText;
    public MenuData menudata;
    private Timer timer;
    // Start is called before the first frame update
    void Start()
    {
        timerText.text = "02:00";
        timer = Timer.createTimer("GameTime");
        // Start timing with 150s
        timer.startTiming(150, true, OnComplete, OnProcess);
    }

    // Update is called once per frame
    void Update()
    {
    }

    void OnComplete()
    {
        if(menudata.difficulty<4){
            menudata.levelPass[menudata.difficulty+1] = true;
        }
        SceneManager.LoadScene("SuccessScene");
    }

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