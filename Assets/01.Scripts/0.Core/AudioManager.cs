using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    private AudioSource _audioSource;

    void Awake()
    {
        _audioSource = GetComponent<AudioSource>();

        _audioSource.clip.LoadAudioData();
        StartCoroutine(PlayAudioWhenLoaded());
    }

    private IEnumerator PlayAudioWhenLoaded()
    {
        while (_audioSource.clip.loadState != AudioDataLoadState.Loaded)
        {
            yield return null;
        }

        GameManager.Instance.SetPlayer();
        _audioSource.Play();
    }
}
