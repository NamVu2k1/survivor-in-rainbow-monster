using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotGirlController : MonoBehaviour
{
    public static BotGirlController instance;
    
     SpriteRenderer SpriteGirl;
    private void Awake()
    {
        instance = this;      
    }
    private void Start()
    {
        SpriteGirl = gameObject.GetComponent<SpriteRenderer>();
    }
    public void GreenLight()
    {
        SpriteGirl.color = Color.green;      
       
    }
    public void RedLight()
    {
        SpriteGirl.color = Color.red;     
    }
 
    
}
