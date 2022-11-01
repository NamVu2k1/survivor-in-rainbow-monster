using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class UIController : MonoBehaviour
{
    public Text Time_txt;
    float ValueTime = 45;
    public static UIController instance;
    public Transform Panel;
    public Image TimeMove_slider;


    private void Awake()
    {
        instance = this;
    }
    public void UpdateTimer(float value)
    {
        ValueTime -= Time.deltaTime;
        Time_txt.text = GetTimeAsString(ValueTime);
        TimeMove_slider.fillAmount = value;
        
    }
    string GetTimeAsString(float t)
    {
        string mins = Mathf.FloorToInt(t / 60).ToString();
        if (int.Parse(mins) < 10)
            mins = "0" + mins;
        string secs = ((int)(t % 60)).ToString();
        if (int.Parse(secs) < 10)
            secs = "0" + secs;
        if (t > 0)
            return mins + ":" + secs;
        else
            return "00:00";

    }
}
