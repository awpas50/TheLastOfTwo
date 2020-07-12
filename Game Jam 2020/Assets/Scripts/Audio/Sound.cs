using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum SoundList
{
    PlayerShootEffect1,
    PlayerShootEffect2,
    PlayerShootEffect3,
    PlayerShootEffect4,
    RocketFallEffect,
    PlayerFallEffect,
    ExplosionEffect1,
    ExplosionEffect2
}

[System.Serializable]
public class Sound
{
    // as we are going to add audio in the AudioManager gameObject, we need a reference
    public AudioClip clip;
    public SoundList soundList;
    [HideInInspector] public AudioSource source;
    [Range(0f, 2f)] public float volume;
    [Range(0.1f, 3f)] public float pitch;
    // determine 2D or 3D sound.
    [Range(0f, 1f)] public float reverbZoneMix;
}
