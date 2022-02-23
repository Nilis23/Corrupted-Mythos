using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Air Idle State", menuName = "FSM/States/Air/Idle", order = 1)]
public class AirIdleState : State
{
    public State patrol; //The chase state it can swap into

    public override State RunCurrentState(StateManager em)
    {
        //Idle enemy patrols a limited area around them.
        //If the player is within chase range, and can be reached, enter chase state. Otherwise continue in idle.

        //stateDebugInfo();

        int colState = em.getCollisionState();
        if (colState > 0) //If the collision state is greater than 0, transfer to the patrol state
        {
            em.idle = false;
            return patrol;
        }

        return null;
    }

    public override void StartState(StateManager em)
    {
        em.idle = true;
        return;
    }
}
