using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    AudioSource audioSource;
    public AudioClip gameMusic;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = gameMusic;
        audioSource.Play();
    }
}
