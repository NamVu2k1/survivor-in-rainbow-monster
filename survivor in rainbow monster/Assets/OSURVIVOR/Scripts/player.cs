using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public interface A_Interface
{
    abstract void Run();
}
public class Player : MonoBehaviour,A_Interface
{
    
    public bool idle;
   
    void Start()
    {
        idle = true;
    }
    
    
    void Update()
    {
        if(Input.GetMouseButton(0))
        {
            Run();
        }    
        if(Input.GetMouseButtonUp(0))
        {
            idle = true;
        }
    }

    public void Run()
    {
        idle = false;
        gameObject.transform.Translate(-1 * Time.deltaTime, 0, 0);
        if(GameController._Controller.check && idle == false)
        {
            Debug.Log("gameover");
        }
       
    }
}
