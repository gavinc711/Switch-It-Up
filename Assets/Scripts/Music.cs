using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Music : MonoBehaviour
{
    public static Music instance;

    public AudioSource musicSource;      // For background music
    public AudioSource sfxSource;        // Separate AudioSource for sound effects
    public AudioClip[] musicClips;       // Assign different music tracks here

    private int currentTrackIndex = 0;

    void Awake()
    {
        // Make this Music manager persistent across scenes
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        PlayMusic(currentTrackIndex); // Start playing the first track
    }

    // Plays the music clip at a given index without restarting the same track
    public void PlayMusic(int trackIndex)
    {
        if (trackIndex != currentTrackIndex)
        {
            currentTrackIndex = trackIndex;
            musicSource.clip = musicClips[trackIndex];
            musicSource.Play();
        }
    }

    // Button method to switch music, called through UI
    public void SwitchMusic(int newTrackIndex)
    {
        if (newTrackIndex >= 0 && newTrackIndex < musicClips.Length)
        {
            PlayMusic(newTrackIndex);
        }
    }

    // Method to play a one-time sound effect
    public void PlaySoundEffect(AudioClip clip)
    {
        sfxSource.PlayOneShot(clip);  // Plays the sound effect once
    }
}
