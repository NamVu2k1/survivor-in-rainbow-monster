using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotGirlController : MonoBehaviour
{
    public static BotGirlController instance;
    Animator anim;
    SpriteRenderer SpriteGirl;
    private void Awake()
    {
        instance = this;
        anim = GetComponent<Animator>();
    }
    private void Start()
    {
        SpriteGirl = gameObject.GetComponent<SpriteRenderer>();
    }
    public void GreenLight()
    {
        SpriteGirl.color = Color.green;
        anim.SetBool("isCheck", false);
    }
    public void RedLight()
    {
        SpriteGirl.color = Color.red;
        anim.SetBool("isCheck", true);
    }
   
}
