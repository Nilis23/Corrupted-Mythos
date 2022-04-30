using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;
    public AudioMixer mixer;
    private static AudioManager instance;

    // Start is called before the first frame update
    void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
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
            //s.source = this.gameObject.AddComponent<AudioSource>();

            s.source.outputAudioMixerGroup = mixer.FindMatchingGroups("Master")[0];

            s.source.clip = s.clip;
            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
        }
        this.stopAllSounds();
    }

    public void PlaySound(string name, bool skip = false)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if(s != null && s.source != null)
        {
            if(skip)
            {
                s.source.time = 0.3f;
            }
            s.source.Play();
        }

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

    public void stopAllSounds()
    {
        foreach(Sound s in sounds)
        {
            if (s.source.isPlaying)
            {
                s.source.Stop();
            }
        }
    }
}
