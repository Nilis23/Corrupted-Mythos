using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class State : ScriptableObject
{
    public StateManager executingManager;
    public abstract State RunCurrentState();
}
