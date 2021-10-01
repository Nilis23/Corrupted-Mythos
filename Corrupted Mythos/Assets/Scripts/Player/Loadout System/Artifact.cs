using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Artifact : ScriptableObject
{ 
    [SerializeField]
    float timer;

    public abstract void doAction(GameObject caller);

    public float getTimer()
    {
        return timer;
    }
}
