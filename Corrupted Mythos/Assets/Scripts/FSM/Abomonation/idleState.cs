using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Idle State", menuName = "FSM/States/Idle", order = 1)]
public class idleState : State
{
    public State patrol; //The chase state it can swap into

    public override State RunCurrentState()
    {
        //Idle enemy patrols a limited area around them.
        //If the player is within chase range, and can be reached, enter chase state. Otherwise continue in idle.

        Debug.Log("I am in idle state");

        int colState = executingManager.getCollisionState();
        if (colState > 0) //If the collision state is greater than 0, transfer to the patrol state
        {
            return patrol;
        }

        return this;
    }
}
