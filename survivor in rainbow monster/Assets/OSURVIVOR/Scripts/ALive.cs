using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class ALive : MonoBehaviour
{

    public static ALive instance;
    public GameObject parent;
    public int alive;
    public Text alive_txt;
    public GameObject player;
    public List<GameObject> bots;
    private void Awake()
    {
        instance = this;
        bots.Add(player);
        for (int i = 0; i < gameObject.transform.childCount; i++)
        {
            bots.Add(gameObject.transform.GetChild(i).gameObject);
        }
        for (int i = 0; i < bots.Count - 1; i++)
        {
            for (int j = i + 1; j < bots.Count; j++)
            {
                var cur = bots[i].GetComponents<Collider2D>()[0];
                var other = bots[j].GetComponents<Collider2D>()[0];
                Physics2D.IgnoreCollision(cur, other);
            }
        }
    }
    void Start()
    {
        updateAliveTxt();

    }
    void updateAliveTxt()
    {
        if(alive_txt != null)
            alive_txt.text = "a live: " + bots.Count.ToString();
        
        
    }
    public void RemoveBot(GameObject bot )
    {
        bots.Remove(bot);
        updateAliveTxt();
    }
    public void RemoveAll()
    {
        foreach(var bot in bots)
        {
            if(bot != null)
                bot.GetComponent<MovementGreenReedLight>().Invoke("Die", Random.Range(0, 4f));

        }
     
    }
}
