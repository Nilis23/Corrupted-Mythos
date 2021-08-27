using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class State : ScriptableObject
{
    //public StateManager executingManager;
    public abstract State RunCurrentState(StateManager em);

    public virtual void stateDebugInfo()
    {
        Debug.Log("State: " + this.GetType().Name);
    }
}
