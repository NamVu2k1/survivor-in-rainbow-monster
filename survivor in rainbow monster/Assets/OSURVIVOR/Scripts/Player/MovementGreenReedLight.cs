using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class MovementGreenReedLight : MonoBehaviour
{
    private static MovementGreenReedLight _instance;
    protected float speed;
    public Rigidbody2D rb2d;
    protected Animator m_animator;
    protected bool isRun;
    protected bool idle = true;
    protected bool isTriggerFinishLine;
    public bool pass = false;
    JoystickMovement joy;
    private void Awake()
    {
        _instance = this;
        rb2d = gameObject.GetComponent<Rigidbody2D>();
        m_animator = gameObject.GetComponent<Animator>();
        joy = gameObject.GetComponent<JoystickMovement>();
       
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            speed = 0.8f;
            isRun = true;
        }

        if (Input.GetMouseButton(0) && isTriggerFinishLine == false && !Utils.IsPointerOverUIElement())
        {
            Run();
        }
        if (Input.GetMouseButtonUp(0))
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
            if (isTriggerFinishLine == false && pass == false)
            {
                pass = true;
                Invoke("Die",Random.Range(0,1.5f));
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
    public virtual void Die()
    {
        GameController._Controller.m_MyEvent.Invoke();
        GameController._Controller.isLose = true;
        UIController.instance.Lose();
        m_animator.SetTrigger("Die");
        Destroy(gameObject);
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

}
