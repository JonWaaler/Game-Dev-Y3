
using UnityEngine;
using UnityEngine.Audio;

[System.Serializable]
public class Sounds {

    public string soundName;

    public AudioClip clip;

    [Range(0f, 1f)]
    public float volume = .75f;
    
    [Range(.1f, 3f)]
    public float pitch = 1f;
    
    public bool loop = false;

    public AudioMixerGroup mixerGroup;

    [HideInInspector]
    public AudioSource source;
}
