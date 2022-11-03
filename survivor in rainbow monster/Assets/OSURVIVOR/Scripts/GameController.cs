using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GameController : MonoBehaviour
{
    public static GameController _Controller; 
    public bool isCheck= false;
    public float timeCheck = 3;
    public float timeMove;
    public float timeMoveCountdown;
    public bool isVictory;
    public bool isLose;


    private void Awake()
    {
        _Controller = this;
        timeMoveCountdown = timeMove;
        StartCoroutine(Turn());
    }

    private void Update()
    {
        timeMoveCountdown -= Time.deltaTime;
        if (UIController.instance)
        {
            UIController.instance.UpdateTimer(timeMoveCountdown / timeMove);
        }
    }
    IEnumerator Turn()
    {
        while (true)//(isVictory == false && isLose == false)
        {
            timeMove = Random.Range(2.5f, 4f);
            timeMoveCountdown = timeMove;
            yield return new WaitForSeconds(timeMove);
            isCheck = true;
            Ground._instance.RedGround();
            BotGirlController.instance.RedLight();
            yield return new WaitForSeconds(timeCheck);
            isCheck = false;
            Ground._instance.GreenGround();
            BotGirlController.instance.GreenLight();
        }

    }
}
