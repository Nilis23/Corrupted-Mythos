using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SetVolume : MonoBehaviour
{
    public AudioMixer mixer;
    public void SetLevel(float val)
    {
        mixer.SetFloat("MasterVolume", Mathf.Log10(val) * 20);
        FindObjectOfType<Settings>().vol = val;
    }
}
