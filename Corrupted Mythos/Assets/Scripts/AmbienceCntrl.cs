using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AmbienceCntrl : MonoBehaviour
{
    AudioManager manager;
    Scene scenetoplay;

    bool play = false;
    private void Start()
    {
        manager = FindObjectOfType<AudioManager>();
        scenetoplay = SceneManager.GetActiveScene();
        SceneManager.sceneLoaded += OnSceneLoaded;
    }
    // Update is called once per frame
    void Update()
    {
        if(!play && manager!= null && SceneManager.GetActiveScene() == scenetoplay)
        {
            manager.PlaySound("main");
            play = true;
        }
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        manager.StopSound("main");
        play = false;
    }
}
