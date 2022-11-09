using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class Sound : MonoBehaviour
{
    public static Sound Instance;
    public AudioClip AudioGround;
    public AudioClip AudioGunfire;


    public AudioSource audioSource;
    public AudioSource audioSourceGround;
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
        if(audioSourceGround == null)
        {
            audioSourceGround = gameObject.AddComponent<AudioSource>();
        }
    }
    private void Start()
    {
    }
    public void PlayAudioGround()
    {
        audioSourceGround.volume = 1;
        audioSourceGround.Play();
    }
    public void VolumeDown()
    {
        audioSourceGround.DOFade(0, 1) ;
    }    
    public void Gunfire()
    {
        audioSource.PlayOneShot(AudioGunfire,0.3f);
    }
}
