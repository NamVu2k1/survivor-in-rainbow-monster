using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneMain : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    public void GreenRedLightScene()
    {
        SceneManager.LoadScene(0);
    }
    public void BattleScene()
    {
        SceneManager.LoadScene(1);
    }
}
