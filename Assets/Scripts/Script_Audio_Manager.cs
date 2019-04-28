using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script_Audio_Manager : MonoBehaviour
{
    public static Script_Audio_Manager Instance { get; private set; }

    private AudioSource audiosource;

    private void Start()
    {
        audiosource = GetComponent<AudioSource>();    
    }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }
    }

    public void PlayAudioClip(AudioClip audio)
    {
        audiosource.PlayOneShot(audio);
    }
}
