using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundBotGirl : MonoBehaviour
{
  
    public static SoundBotGirl _instance;
    public AudioSource audioSource;
    public AudioClip RobotGirl;
    private void Awake()
    {
        _instance = this;
    }
    private void OnValidate()
    {
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
            audioSource.playOnAwake = false;
        }
    }
  
    public void AudioRobotGirl(float timeMove)
    {
        audioSource.pitch = 4.833f / timeMove;
        audioSource.PlayOneShot(RobotGirl);
    }
}
