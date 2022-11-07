using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementBattle : MonoBehaviour
{
    Animator anim;
    Rigidbody2D rg;
    public JoystickMovement joy;
    private void Awake()
    {
        rg = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }
    void Start()
    {
        
    }
    void Update()
    {
        if (  !Utils.IsPointerOverUIElement())
        {
            run();
        }
        
    }
    void run()
    {
        rg.velocity = new Vector3(joy.joystickVec.x, joy.joystickVec.y, 0);
        anim.SetBool("Run", true);
    }
}
