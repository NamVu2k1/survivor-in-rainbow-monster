using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IgnoreCollision : MonoBehaviour
{
    
    public List<Transform> bots;
  
    public GameObject player;
    private void Awake()
    {
        for(int i = 0; i < gameObject.transform.childCount; i++)
        {
            bots.Add(gameObject.transform.GetChild(i));
        }
        
        for (int i = 0; i < bots.Count - 1; i++)
        {
            var cur = bots[i].GetComponents<Collider2D>()[0];
            var other = player.GetComponents<Collider2D>()[0];
            Physics2D.IgnoreCollision(cur, other);
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
    private void Update()
    {
        Debug.Log(bots.Count);
    }
}
