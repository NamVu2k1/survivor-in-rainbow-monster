using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
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

    private static UnityEvent updateCoinEvent = new UnityEvent();
    private void Awake()
    {
        _Controller = this;
        timeMoveCountdown = timeMove;
        Playgame();
    }

    private void Start()
    {
       
    }
    private void Update()
    {
        timeMoveCountdown -= Time.deltaTime;
        timeGameCountdown -= Time.deltaTime;
        if (UIController.instance)
        {
            UIController.instance.UpdateTimer(timeMoveCountdown / timeMove,timeGameCountdown);
        }
    }
    public void Playgame()
    {
        StartCoroutine(Turn());
    }
    public void AddListener(UnityAction updatecoin)
    {
        updateCoinEvent.AddListener(updatecoin);
    }
    public void RemoveListener(UnityAction updatecoin)
    {
        updateCoinEvent.RemoveListener(updatecoin);
    }
    IEnumerator Turn()
    {
        updateCoinEvent.Invoke();
        while (true)//(isVictory == false && isLose == false)
        {
            timeMove = Random.Range(2f, 6f);
            Sound.Instance.AudioRobotGirl(timeMove);
            timeGameCountdown = 45;
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
}
