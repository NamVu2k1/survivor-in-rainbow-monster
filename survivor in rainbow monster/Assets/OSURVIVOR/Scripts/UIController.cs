using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
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
    public GameObject PauseUI;
    public GameObject holdToMove_txt;

    private void Awake()
    {
        instance = this;

    }
    public void RestartBtn()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void HomeBtn()
    {
        SceneManager.LoadScene("OSURVIVOR/Scenes/main");
    }
    private void Start()
    {
        WinUI.SetActive(false);
        LoseUI.SetActive(false);
        PauseUI.SetActive(false);
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
    public void onPause()
    {
        Time.timeScale = 0;
        PauseUI.SetActive(true);
        PauseUI.transform.localScale = new Vector3(0, 0, 0);
        PauseUI.transform.DOScale(1, 1f).SetEase(Ease.OutBack).SetUpdate(true);
    }

    public void ClosePause()
    {
        Time.timeScale = 1;
        PauseUI.SetActive(false);
    }
    public void Play()
    {

    }
    public void HoldToMove()
    {
        holdToMove_txt.transform.DOScale(0.5f, 1f).OnComplete(() => holdToMove_txt.SetActive(false));
    }
    public void UpdateTimer(float value, float valuetime)
    {
      
        Time_txt.text = GetTimeAsString(valuetime);
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
