using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AmbienceCntrl : MonoBehaviour
{
    AudioManager manager;
    Scene scenetoplay;
    [SerializeField]
    string songName;

    bool play = false;
    private void Start()
    {
        manager = FindObjectOfType<AudioManager>();
    }
    // Update is called once per frame
    void Update()
    {
        if(!play && manager!= null)
        {
            manager.PlaySound(songName);
            play = true;
        }
    }
}
