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
        
        if (ObjectManager.Instance.IsEditMode)     
            StartCoroutine(PlayAudioWhenLoaded());
    }

    public void PlayAudio()
    {
        _audioSource.Play();
    }

    private IEnumerator PlayAudioWhenLoaded()
    {
        yield return new WaitForSeconds(3f);
        PlayAudio();
    }
}
