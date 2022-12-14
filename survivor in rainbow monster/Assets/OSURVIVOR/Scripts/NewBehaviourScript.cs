using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class NewBehaviourScript : MonoBehaviour
{
    // Start is called before the first frame update
    UnityEvent m_MyEvent = new UnityEvent();

    void Start()
    {
        //Add a listener to the new Event. Calls MyAction method when invoked
        m_MyEvent.AddListener(MyAction);
    }

    void Update()
    {
        // Press Q to close the Listener
        if (Input.GetKeyDown("q") && m_MyEvent != null)
        {
            Debug.Log("Quitting");
            m_MyEvent.RemoveListener(MyAction);


        }

        //Press any other key to begin the action if the Event exists
        if (Input.anyKeyDown && m_MyEvent != null)
        {
            //Begin the action
            m_MyEvent.Invoke();
        }
    }

    void MyAction()
    {
        //Output message to the console
        Debug.Log("Do Stuff");
    }
}
