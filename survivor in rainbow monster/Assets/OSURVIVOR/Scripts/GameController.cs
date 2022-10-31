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
        while(true)
        {
            timeMove = Random.Range(2.5f, 4f);
            timeMoveCountdown = timeMove;            
            yield return new WaitForSeconds(timeMove);         
            isCheck = true;
            BotGirlController.instance.RedLight();
            yield return new WaitForSeconds(timeCheck);
            isCheck = false;
            BotGirlController.instance.GreenLight();

        }
    }

   
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
           
            collision.GetComponent<Player>().TriggerAreA();
        }

    }
}
