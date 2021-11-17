using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetAudio : MonoBehaviour
{
    private void Start()
    {
        FindObjectOfType<AudioManager>()?.stopAllSounds();
    }
}
