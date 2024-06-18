using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource audioSource;

    void Awake()
    {
        audioSource = GetComponent<AudioSource>();

        audioSource.clip.LoadAudioData();
        StartCoroutine(PlayAudioWhenLoaded());
    }

    private IEnumerator PlayAudioWhenLoaded()
    {
        while (audioSource.clip.loadState != AudioDataLoadState.Loaded)
        {
            yield return null;
        }

        audioSource.Play();
    }
}
