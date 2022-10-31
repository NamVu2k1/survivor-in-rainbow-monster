using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    [SerializeField]
    protected float speed;
    [SerializeField]
    protected bool idle = true;
    protected bool isTriggerArea;
    public Rigidbody2D rb2d;
    protected Animator m_animator;
    protected bool isRun;
    protected Text NameBot;
    private void Awake()
    {
        rb2d = gameObject.GetComponent<Rigidbody2D>();
        m_animator = gameObject.GetComponent<Animator>();
        NameBot = gameObject.GetComponentInChildren<Text>();
        NameBot.text = "456";
    }
   
    private void Update()
    {
        if(Input.GetMouseButton(0))
        {
            isRun = true;            
            Run();
        }    
        if(Input.GetMouseButtonUp(0))
        {
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
            if(isTriggerArea == false)
            {
                Destroy(gameObject);
            }
            else
            {

            }
            
        }     
    }
    public void TriggerAreA()
    {
        isTriggerArea = true;
    }
   
}
