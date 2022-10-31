using UnityEngine;
using UnityEngine.UI;
public class Bot : Player
{
    public float _timeMove;
    float DelayMove;
    private void Start()
    {
        NameBot = gameObject.GetComponentInChildren<Text>();
        NameBot.text = RandomName();
        _timeMove = RandomTimeMove();
        DelayMove = RandomTimeDelayMove();
    }
    private void Update()
    {
        _timeMove -= Time.deltaTime;   
        if ( _timeMove > 0)
        {
            DelayMove -= Time.deltaTime;
            if (DelayMove < 0)
            {
                isRun = true;
                Run();
            }
        }
        else if(_timeMove < -3 && GameController._Controller.isCheck == false)
        {
            DelayMove = RandomTimeDelayMove();
            _timeMove = RandomTimeMove();          
        }
        else
        {
            idle = true;
            isRun = false;
            m_animator.SetBool("Run", isRun);
        }       
    }
    float RandomTimeMove()
    {
        return Random.Range(GameController._Controller.timeMove - 0.6f, GameController._Controller.timeMove + 0.1f);
    }
    float RandomTimeDelayMove()
    {
        return Random.Range(0, 0.6f);
    }
    public   string RandomName()
    { int value = Random.Range(0, 999);
        if (value < 10)
        {
            return "00" + value.ToString();
        }
        else if (9 < value && value < 100)
        {
            return "0" + value.ToString();
        }
        else
        {
            return value.ToString();
        }
        
    }
}