using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StrikerController : MonoBehaviour
{
    Animator anim;
    private void Awake()
    {
        anim = gameObject.GetComponent<Animator>();
    }
   
    void Start()
    {
        GameController._Controller.addlistener(shotting);
    }
    void shotting()
    {
        anim.SetTrigger("shot");
    }
    void gunfireAudio()
    {
        Sound.Instance.Gunfire();
    }
}
