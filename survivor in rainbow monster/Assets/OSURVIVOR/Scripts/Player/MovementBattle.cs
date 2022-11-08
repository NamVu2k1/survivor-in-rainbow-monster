using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MovementBattle : MonoBehaviour
{
    Animator anim;
    Rigidbody2D rg;

    public float speed;
    public GameObject joystick;
    public GameObject joystickBG;
    public Vector2 joystickVec;
    private Vector2 joystickTouchPos;
    private Vector2 joystickOriginalPos;
    private float joystickRadius;
    private void Awake()
    {
        rg = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }
    void Start()
    {
        joystickOriginalPos = joystickBG.transform.position;
        joystickRadius = joystickBG.GetComponent<RectTransform>().sizeDelta.y / 4;
    }
   
    public void PointerDown()
    {
        Debug.Log("down");
        joystick.transform.position = Input.mousePosition;
        joystickBG.transform.position = Input.mousePosition;
        joystickTouchPos = Input.mousePosition;
    }
    public void Drag(BaseEventData baseEventData)
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
    public void PointerUp()
    {
        joystickVec = Vector2.zero;
        joystick.transform.position = joystickOriginalPos;
        joystickBG.transform.position = joystickOriginalPos;
        run();
        anim.SetBool("Run", false);
    }
    void run()
    {
        rg.velocity = new Vector3(joystickVec.x*speed, joystickVec.y*speed, 0);
        anim.SetBool("Run", true);
    }
    void flip()
    {
        if(joystickVec.x < 0)
        {
            Vector3 theScale = transform.localScale;
            theScale.x = -1;
            transform.localScale = theScale;
        }
        else
        {
            Vector3 theScale = transform.localScale;
            theScale.x = 1;
            transform.localScale = theScale;
        }
    }
    public void Attack()
    {
        anim.SetTrigger("Attack");
        rg.velocity = Vector2.zero;
        anim.SetBool("Run", false);
        
    }
    void GunfireSound()
    {
        Sound.Instance.Gunfire();
    }

}
