using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using System;

public class AudioManager : MonoBehaviour
{
    public AudioClips[] aud;
    public AudioSource audioSource;

    [System.Serializable]
    public class AudioClips
    {
        public string clipName;
        public AudioClip audioClip;
        public float clipVolume = 1;
        public bool loop;

        public AudioSource audioSource;
    };

    public static AudioManager existant;

    private void Awake()
    {

        if (existant == null)
        {
            existant = this;
        }
        else
        {
            Destroy(this.gameObject);
            return;
        }

        DontDestroyOnLoad(this.gameObject);

        foreach (AudioClips audio in aud)
        {
            audio.audioSource = gameObject.AddComponent<AudioSource>();
            audio.audioSource.clip = audio.audioClip;

            audio.audioSource.volume = audio.clipVolume;
            audio.audioSource.loop = audio.loop;
        }
    }

    private void Start()
    {
        PlaySound("Music");
    }

    public void PlaySound(string audioName)
    {
        AudioClips audioFound = Array.Find(aud, AudioClips => AudioClips.clipName == audioName);
        if (audioFound != null)
        {
            audioFound.audioSource.Play();
        }
    }
}
