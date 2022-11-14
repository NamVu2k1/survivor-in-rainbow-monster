using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using DG.Tweening;
public class UIController : MonoBehaviour
{
    public static UIController instance;
    public Text TimeGameCountDown_txt;
    public float ValueTime;   
    public Image TimeMove_slider;
    public GameObject WinUI;
    public GameObject LoseUI;
    public GameObject PauseUI;
    public GameObject holdToMove_txt;
    public UnityEvent Win_Event;
    public UnityEvent Lose_Event;
    private void Awake()
    {
        instance = this;
        Win_Event.AddListener(PassLevel);
        Lose_Event.AddListener(Lose);
    }
    private void Start()
    {
        WinUI.SetActive(false);
        LoseUI.SetActive(false);
        PauseUI.SetActive(false);
    }
    private void Update()
    {
       
        if (ValueTime > 0)
        {
            ValueTime -= Time.deltaTime;
            TimeGameCountDown_txt.text = GetTimeAsString(ValueTime);
        }           
        else if( ValueTime >-1 && ValueTime <=0 )
        {
            ValueTime = -2;
            TimeGameCountDown_txt.text = GetTimeAsString(ValueTime);
        }
    }
    public void RestartBtn()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void HomeBtn()
    {
        SceneManager.LoadScene("OSURVIVOR/Scenes/main");
    }

    bool finished;
    public void PassLevel()
    {
        if (finished)
        {
            return;
        }
        finished = true;
        WinUI.SetActive(true);
        WinUI.transform.localScale = new Vector3(0, 0, 0);
        WinUI.transform.DOScale(1, 1f).SetEase(Ease.OutBack);
        Lose_Event.RemoveAllListeners();
    }
    public void Lose()
    {
        if (finished)
        {
            return;
        }
        finished = true;
        LoseUI.SetActive(true);
        LoseUI.transform.localScale = new Vector3(0, 0, 0);
        LoseUI.transform.DOScale(1, 1f).SetEase(Ease.OutBack);
        Win_Event.RemoveAllListeners();
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
    public void HoldToMove()
    {
        holdToMove_txt.transform.DOScale(0.5f, 1f).OnComplete(() => holdToMove_txt.SetActive(false));
    }
    public void UpdateTimer(float value)
    {
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
        {
            if (SceneManager.GetActiveScene().name == "OSURVIVOR/Scenes/Green Light Red Light")
            {
                ALive.instance.RemoveAll();
                return "00:00";
            }
            else
            {
                Win_Event.Invoke();
                return "00:00";
            }
           
        }

    }
}
