using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GameController : MonoBehaviour
{
    public static GameController _Controller;
    Slider _time;  
    public bool check;
    private void Awake()
    {
        _Controller = this;
    }
    void Start()
    {
        StartCoroutine(Turn());
    }  
    IEnumerator Turn()
    {
        while(true)
        {
            yield return new WaitForSeconds(Random.Range(5f, 7f));
            check = true;
            yield return new WaitForSeconds(Random.Range(5f, 7f));
            check = false;
           
        }
    }
    
    
}
