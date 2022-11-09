using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MovementBattle : MonoBehaviour
{
    Animator anim;
    Rigidbody2D rb;
    protected Vector3 theScale;
    public float speed;
    [SerializeField]
    private GameObject joystick;
    [SerializeField]
    private GameObject joystickBG;
    Vector2 joystickVec;
    private Vector2 joystickTouchPos;
    private Vector2 joystickOriginalPos;
    private float joystickRadius;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }
    void Start()
    {
        joystickOriginalPos = joystickBG.transform.position;
        joystickRadius = joystickBG.GetComponent<RectTransform>().sizeDelta.y / 4;
    }
    [SerializeField]
    private void PointerDown()
    {
      
        joystick.transform.position = Input.mousePosition;
        joystickBG.transform.position = Input.mousePosition;
        joystickTouchPos = Input.mousePosition;
    }
    [SerializeField]
    private void Drag(BaseEventData baseEventData)
    {


        PointerEventData pointerEventData = baseEventData as PointerEventData;
        Vector2 dragPos = pointerEventData.position;
        joystickVec = (dragPos - joystickTouchPos).normalized;
        float joystickDist = Vector2.Distance(dragPos, joystickTouchPos);

        if (joystickDist < joystickRadius)
        {
            joystick.transform.position = joystickTouchPos + joystickVec * joystickDist;

        }
        else
        {
            joystick.transform.position = joystickTouchPos + joystickVec * joystickRadius;
        }

        flip();
        run();
    }
    [SerializeField]
    private void PointerUp()
    {
        joystickVec = Vector2.zero;
        joystick.transform.position = joystickOriginalPos;
        joystickBG.transform.position = joystickOriginalPos;
        run();
        anim.SetBool("Run", false);
    }
    void run()
    {
        rb.velocity = new Vector3(joystickVec.x*speed, joystickVec.y*speed, 0);
        anim.SetBool("Run", true);
    }
    public virtual void flip()
    {
        if(joystickVec.x < 0)
        {
            theScale = transform.localScale;
            theScale.x = -1;
            transform.localScale = theScale;
        }
        else
        {
            theScale = transform.localScale;
            theScale.x = 1;
            transform.localScale = theScale;
        }
    }
    protected void Attack()
    {
        anim.SetTrigger("Attack");
        rb.velocity = Vector2.zero;
        anim.SetBool("Run", false);
       
    }
    protected void GunfireSound()
    {
        Sound.Instance.Gunfire();
    }
    public virtual void OnHit()
    {
        Destroy(gameObject);
        UIController.instance.Lose();   
    }
    
}
