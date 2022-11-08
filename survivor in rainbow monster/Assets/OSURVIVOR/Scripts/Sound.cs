using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sound : MonoBehaviour
{
    public static Sound Instance;
    public AudioClip AudioGround;
    public AudioClip AudioGunfire;

    public AudioSource audioSource;
    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(Instance);
        }
        else
        {
            Destroy(gameObject);
        }
        
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
       
    }
    public void PlayAudioGround()
    {
        audioSource.PlayOneShot(AudioGround);
    }
    public void Gunfire()
    {
        audioSource.PlayOneShot(AudioGunfire);
    }
}
