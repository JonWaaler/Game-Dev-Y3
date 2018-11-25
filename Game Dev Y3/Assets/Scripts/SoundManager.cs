using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SoundManager : MonoBehaviour {


    public static SoundManager instance;
    public AudioMixerGroup MixerGroup;
    public Sounds[] sounds;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
            return;
        }
        else
            Destroy(this);
    }

    // Use this for initialization
    void Start () {
        Debug.Log("SoundManager", gameObject);

        foreach (Sounds sound in sounds)
        {
            sound.source = gameObject.AddComponent<AudioSource>();
            sound.source.clip = sound.clip;
            sound.source.loop = sound.loop;
            sound.source.outputAudioMixerGroup = MixerGroup;
        }
	}
	

    public void Play(string soundName)
    {
        foreach (Sounds sound in sounds)
        {
            if (sound.soundName == soundName)
            {


                sound.source.volume = sound.volume;
                sound.source.pitch = sound.pitch;
                sound.source.Play();
                return;
            }
        }
    }

	// Update is called once per frame
	void Update () {
        

		
	}
}
