using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIBotBattle : MonoBehaviour
{
    public float speed;
    Rigidbody2D rb;
    SpriteRenderer sprite;
    Animator anim;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        StartCoroutine(AI());
    }

   
    void Update()
    {
       
    }
    IEnumerator AI()
    {
        while(true)
        {
            randomVectorVelocity();
            flip();
            anim.SetBool("Run", true);
            yield return new WaitForSeconds(Random.Range(1f,5f));
            rb.velocity = Vector2.zero;
            anim.SetBool("Run", false);
            yield return new WaitForSeconds(Random.Range(0, 2f));
        }
    }
    void randomVectorVelocity()
    {
        rb.velocity = new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f),0).normalized*speed;
      
        //rb.velocity = new Vector3(1, 1, 0);
    }
    void flip()
    {
        if (rb.velocity.x > 0)
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
}
