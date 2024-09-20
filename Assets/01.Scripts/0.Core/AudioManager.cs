using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoSingleton<AudioManager>
{
    private AudioSource _audioSource;

    void Awake()
    {
        _audioSource = GetComponent<AudioSource>();

        _audioSource.clip.LoadAudioData();
        //StartCoroutine(PlayAudioWhenLoaded());
    }

    public void PlayAudio()
    {
        _audioSource.Play();
    }
}
