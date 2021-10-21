using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Artifact : ScriptableObject
{ 
    [SerializeField]
    float timer;
    
    public string soundName;

    public abstract void doAction(GameObject caller);

    public float getTimer()
    {
        return timer;
    }
}
