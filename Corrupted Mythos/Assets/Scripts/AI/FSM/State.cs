using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public abstract class State : ScriptableObject
{
    //public StateManager executingManager;
    public abstract State RunCurrentState(StateManager em);
    public abstract void StartState(StateManager em);

    public virtual void stateDebugInfo()
    {
        Debug.Log("State: " + this.GetType().Name);
    }

    public virtual void CreatePath(StateManager em, GameObject targ)
    {
        if (em.timer <= 0)
        {
            em.seeker.StartPath(em.gameObject.transform.position, targ.transform.position);
            em.timer = 20;
        }
    }
}
