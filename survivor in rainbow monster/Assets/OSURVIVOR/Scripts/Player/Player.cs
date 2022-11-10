using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class Player : MonoBehaviour
{
    public static Player _instance;    
    Text NameBot;

    private void Awake()
    {
        _instance = this;      
        NameBot = gameObject.GetComponentInChildren<Text>();
        NameBot.text = "456";
    }
    
}
