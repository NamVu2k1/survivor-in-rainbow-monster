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
    Text alive_txt;
    public UnityEvent m_MyEvent = new UnityEvent();

    private void Awake()
    {
        instance = this;
        alive_txt = gameObject.GetComponent<Text>();
    }
    void Start()
    {
        m_MyEvent.AddListener(updateAliveTxt);
        alive_txt.text = "a live: " + (parent.transform.childCount + 1).ToString();
    }
    void updateAliveTxt()
    {
        alive_txt.text = "a live: " + (parent.transform.childCount + 1).ToString();
    }
    private void OnEnable()
    {
        m_MyEvent.RemoveAllListeners();
    }
}
