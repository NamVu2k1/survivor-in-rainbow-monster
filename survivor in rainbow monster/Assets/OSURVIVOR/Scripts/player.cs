using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class Player : MonoBehaviour
{
    private static Player _instance;
    [SerializeField]
    protected float speed;
    [SerializeField]
    protected bool idle = true;
    protected bool isTriggerFinishLine;
    public Rigidbody2D rb2d;
    protected Animator m_animator;
    protected bool isRun;
    protected Text NameBot;
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
        }

        if(Input.GetMouseButton(0) && isTriggerFinishLine == false)
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
        idle = false;
        m_animator.SetBool("Run", isRun);
        
        gameObject.transform.Translate(-speed * Time.deltaTime, 0, 0);
        if (GameController._Controller.isCheck == true && idle == false)
        {
            if(isTriggerFinishLine == false)
            {
                Destroy(gameObject);
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
   
}
