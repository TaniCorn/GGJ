using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using System;
using UnityEngine.UIElements;

public class AudioManager : MonoBehaviour
{
    public AudioClips[] aud;
    public AudioSource audioSource;

    public Slider musicVolume;
    public Slider soundVolume;

    public float mVol = 1;
    public float sVol = 1;
    public float masVol = 1;

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
        mVol = 1;
        sVol = 1;
        masVol = 1;
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

    public void MusicVolume(float vol)
    {
        mVol = vol;
        ChangeVol();
    }
    public void SoundVolume(float vol)
    {
        sVol = vol;
        ChangeVol();
    }
    public void MasterVolume(float vol)
    {
        masVol = vol;
        foreach (AudioClips audio in aud)
        {
                audio.audioSource.volume = mVol * masVol;
                audio.audioSource.volume = sVol * masVol;
        }
    }


    public void ChangeVol()
    {
        foreach (AudioClips audio in aud)
        {
            if (audio.loop == true)
            {
                audio.audioSource.volume = mVol * masVol;
            }
            else
            {
                audio.audioSource.volume = sVol * masVol;
            }
        }
    }
}
