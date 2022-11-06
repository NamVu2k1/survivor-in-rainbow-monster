using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class Player : MonoBehaviour
{
    private static Player _instance;    
    protected float speed;
    public Rigidbody2D rb2d;
    protected Animator m_animator;
    protected Text NameBot;


    protected bool isRun;
    protected bool idle = true;
    protected bool isTriggerFinishLine;
    bool FirstClick;
    private void Awake()
    {
        _instance = this;
        rb2d = gameObject.GetComponent<Rigidbody2D>();
        m_animator = gameObject.GetComponent<Animator>();
        NameBot = gameObject.GetComponentInChildren<Text>();
        NameBot.text = "456";
    }
   
    private void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
           
            speed = 0.8f;
            isRun = true;
            //if(FirstClick == false)
            //{
            //    GameController._Controller.Playgame();
            //    FirstClick = true;
            //}
        }

        if(Input.GetMouseButton(0) && isTriggerFinishLine == false && !Utils.IsPointerOverUIElement())
        {    
            Run();
        }    
        if(Input.GetMouseButtonUp(0))
        {
            speed = 0;           
            idle = true;
            isRun = false;           
            m_animator.SetBool("Run", isRun);
        }
    }

    public void Run()
    {
        bool pass = false;
        idle = false;
        m_animator.SetBool("Run", isRun);        
        gameObject.transform.Translate(-speed * Time.deltaTime, 0, 0);
        if (GameController._Controller.isCheck == true && idle == false)
        {
            if(isTriggerFinishLine == false && pass == false)
            {                
                pass = true;
                Die();  
            }
            else
            {

            }           
        }     
    }
    public virtual void TriggerFinishLine()
    {
        isTriggerFinishLine = true;
        gameObject.transform.DOMoveX(gameObject.transform.position.x - 0.8f, 5f);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Finish line"))
        {
            isTriggerFinishLine = true;
            gameObject.transform.DOMoveX(gameObject.transform.position.x - 0.8f, 1f);
            GameController._Controller.isVictory = true;
            UIController.instance.PassLevel();
        }
    }
    public virtual void Die()
    {
        GameController._Controller.isLose = true;
        UIController.instance.Lose();
        m_animator.SetTrigger("Die");   
    }
}
