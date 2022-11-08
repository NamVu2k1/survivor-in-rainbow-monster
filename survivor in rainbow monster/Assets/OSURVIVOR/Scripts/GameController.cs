using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class GameController : MonoBehaviour
{
    public static GameController _Controller; 
    public bool isCheck= false;
    public float timeCheck = 3;
    public float timeGameCountdown;
    public float timeMove;
    public float timeMoveCountdown;
    public bool isVictory;
    public bool isLose;
    public int FirstClick;

    public UnityEvent m_MyEvent = new UnityEvent();
    private void Awake()
    {
        _Controller = this;
        timeMoveCountdown = timeMove;
        timeGameCountdown = 45;

    }

    private void Update()
    {
        timeMoveCountdown -= Time.deltaTime;
        timeGameCountdown -= Time.deltaTime;
        if (UIController.instance)
        {
            UIController.instance.UpdateTimer(timeMoveCountdown / timeMove,timeGameCountdown);
        }
        if(Input.GetMouseButtonDown(0) && FirstClick == 0)
        {
            Playgame();
            FirstClick += 1;
        }
    }
    public void Playgame()
    {
        StartCoroutine(Turn());
    }
    IEnumerator Turn()
    {
       
        while (true)
        {
            
            timeMove = Random.Range(2f, 6f);
            SoundBotGirl._instance.AudioRobotGirl(timeMove);
            
            timeMoveCountdown = timeMove;
            //
            yield return new WaitForSeconds(timeMove);
            isCheck = true;
            Ground._instance.RedGround();
            BotGirlController.instance.RedLight();
            //
            yield return new WaitForSeconds(timeCheck);
            isCheck = false;
            Ground._instance.GreenGround();
            BotGirlController.instance.GreenLight();
        }

    }
    public void addlistener(UnityAction even)
    {
        m_MyEvent.AddListener(even);
    }
    public void removelistener(UnityAction even)
    {
        m_MyEvent.RemoveListener(even);
    }
}
