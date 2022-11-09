using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneMain : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("start");
        Sound.Instance.PlayAudioGround();
    }

    // Update is called once per frame
    public void GreenRedLightScene()
    {
        SceneManager.LoadScene("OSURVIVOR/Scenes/Green Light Red Light");
    }
    public void BattleScene()
    {
        SceneManager.LoadScene("OSURVIVOR/Scenes/Battle");
    }
}
