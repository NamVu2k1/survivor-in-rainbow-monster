using UnityEngine;

using DG.Tweening;
public class Bot : Player
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
        return Random.Range(GameController._Controller.timeMove - 0.6f, GameController._Controller.timeMove + 0.1f);
    }
    float RandomTimeDelayMove()
    {
        return Random.Range(0, 0.6f);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Finish line"))
        {
            isTriggerFinishLine = true;
          
            gameObject.transform.DOMoveX(gameObject.transform.position.x - 0.8f, 1f);
            Debug.Log("trigger");
        }
    }
    public override void Die()
    {
        Destroy(gameObject);
        m_animator.SetTrigger("Die");
    }    
}