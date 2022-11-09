using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIBotBattle : MovementBattle
{
  
    public float attackspeed;
    Rigidbody2D rb;
    SpriteRenderer sprite;
    Animator anim;
    Collider2D col;


    void Start()
    {
        col = GetComponent<Collider2D>();
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        StartCoroutine(AI());
    }

   
    void Update()
    {
        attackspeed -= Time.deltaTime; 
       
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
            yield return new WaitForSeconds(Random.Range(0, 1f));
        }
    }
    void randomVectorVelocity()
    {
        rb.velocity = new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f),0).normalized*speed;
      
        //rb.velocity = new Vector3(1, 1, 0);
    }
    public override void flip()
    {
        if (rb.velocity.x < 0)
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
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player") && attackspeed < 0)
        {
            Invoke("Attack", Random.Range(0, 1f));
            attackspeed = 3;
        }
    }
    public override void OnHit()
    {
      
        Destroy(gameObject);      
    }

}
