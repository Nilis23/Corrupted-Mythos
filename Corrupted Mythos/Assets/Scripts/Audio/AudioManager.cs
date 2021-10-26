using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;
    public AudioMixer mixer;
    public static AudioManager instance;

    // Start is called before the first frame update
    void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            DestroyImmediate(gameObject);
            return;
        }

        foreach(Sound s in sounds)
        {
            GameObject ns = new GameObject();
            ns.transform.parent = this.gameObject.transform;
            ns.name = s.name;
            s.source = ns.AddComponent<AudioSource>();

            s.source.outputAudioMixerGroup = mixer.FindMatchingGroups("Master")[0];

            s.source.clip = s.clip;
            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
        }
    }

    public void PlaySound(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if(s != null && s.source != null)
            s.source.Play();

        if(s != null && s.source == null)
        {
            Debug.Log("Name: " + s.name + " source not existent in " + this.name);
        }
    }
    public void StopSound(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s != null && s.source.isPlaying)
            s.source.Stop();
    }
}
