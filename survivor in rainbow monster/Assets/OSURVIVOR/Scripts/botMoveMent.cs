using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class botMoveMent : MonoBehaviour
{
    // Start is called before the first frame update
    Text NameBot;
    void Start()
    {
        NameBot = gameObject.GetComponentInChildren<Text>();
        NameBot.text = RandomName();
    }

    // Update is called once per frame
    void Update()
    {
        if (GameController._Controller.FirstClick >= 1)
        {
            gameObject.GetComponent<Bot>().enabled = true;
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
