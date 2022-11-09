using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Bot : MonoBehaviour
{
    // Start is called before the first frame update
    Text NameBot;
    BotMovement bot;
    GameController controller;
    private void Awake()
    {
        bot = gameObject.GetComponent<BotMovement>();
    }
    void Start()
    {
        NameBot = gameObject.GetComponentInChildren<Text>();
        NameBot.text = RandomName();
        controller = FindObjectOfType<GameController>();

    }
    void Update()
    {
        if(controller == null)
        {

        }
        else
        {
            if (controller.FirstClick >= 1)
            {
                bot.enabled = true;
            }
        }
       
    }
    public string RandomName()
    {
        int value = Random.Range(0, 999);
        if (value < 10)
        {
            return "00" + value.ToString();
        }
        else if (9 < value && value < 100)
        {
            return "0" + value.ToString();
        }
        else
        {
            return value.ToString();
        }

    }
}
