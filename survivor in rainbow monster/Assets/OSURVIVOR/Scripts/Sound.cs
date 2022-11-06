using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sound : MonoBehaviour
{
    public static Sound Instance;
    public AudioClip AudioGround; 
   
    public AudioClip RobotGirl;
    public AudioSource audioSource;
    private void Awake()
    {
        Instance = this;
    }
    private void OnValidate()
    {
        if(audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
            audioSource.playOnAwake = false;
        }
    }
    private void Start()
    {
        PlayAudioGround();
    }
    public void PlayAudioGround()
    {
        audioSource.PlayOneShot(AudioGround);
    }
    public void AudioRobotGirl(float timeMove)
    {
        audioSource.pitch = 4.833f/ timeMove;
        audioSource.PlayOneShot(RobotGirl);
    }
}
