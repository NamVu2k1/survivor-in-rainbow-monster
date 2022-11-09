using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hitbox : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            ALive.instance.m_MyEvent.Invoke();
            collision.SendMessage("OnHit");
          
        }
    }
}