using UnityEngine;

using DG.Tweening;
public class BotMovement : MovementGreenReedLight
{
    public float _timeMove;
    float DelayMove;
    private void Start()
    {       
        _timeMove = RandomTimeMove();
        DelayMove = RandomTimeDelayMove();
        speed = 0.8f;
    }
    private void Update()
    {
        
            _timeMove -= Time.deltaTime;
            if (_timeMove > 0 && isTriggerFinishLine == false)
            {
                DelayMove -= Time.deltaTime;
                if (DelayMove < 0)
                {
                    isRun = true;
                    Run();
                }
            }
            else if (_timeMove < -3 && GameController._Controller.isCheck == false)
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
        return Random.Range(GameController._Controller.timeMove - 1.2f, GameController._Controller.timeMove + 0.3f);
    }
    float RandomTimeDelayMove()
    {
        return Random.Range(0, 0.6f);
    }
    public override void Die()
    {
        m_animator.SetTrigger("Die");
        Destroy(gameObject);
    }
    private void OnDisable()
    {
        ALive.instance.RemoveBot(gameObject);
        GameController._Controller.m_MyEvent.Invoke();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Finish line"))
        {
            isTriggerFinishLine = true;
            gameObject.transform.DOMoveX(gameObject.transform.position.x - 0.8f, 1f);
            ALive.instance.RemoveBot(gameObject);
        }
    }
}