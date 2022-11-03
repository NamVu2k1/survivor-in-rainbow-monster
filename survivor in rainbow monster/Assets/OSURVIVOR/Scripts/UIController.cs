using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class UIController : MonoBehaviour
{
    public static UIController instance;
    public Text Time_txt;
    float ValueTime = 45;   
    public Transform Panel;
    public Image TimeMove_slider;
    public GameObject WinUI;
    public GameObject LoseUI;

    private void Awake()
    {
        instance = this;

    }
    private void Start()
    {
        WinUI.SetActive(false);
        LoseUI.SetActive(false);
    }
    public void PassLevel()
    {
        WinUI.SetActive(true);
        WinUI.transform.localScale = new Vector3(0, 0, 0);
        WinUI.transform.DOScale(1, 1f).SetEase(Ease.OutBack);
    }
    public void Lose()
    {
        LoseUI.SetActive(true);
        LoseUI.transform.localScale = new Vector3(0, 0, 0);
        LoseUI.transform.DOScale(1, 1f).SetEase(Ease.OutBack);
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
