using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneMain : MonoBehaviour
{
    private void Awake()
    {
        Sound.Instance.PlayAudioGround();
    }
    public void GreenRedLightScene()
    {
        SceneManager.LoadScene("OSURVIVOR/Scenes/Green Light Red Light");
    }
    public void BattleScene()
    {
        SceneManager.LoadScene("OSURVIVOR/Scenes/Battle");
    }
}
