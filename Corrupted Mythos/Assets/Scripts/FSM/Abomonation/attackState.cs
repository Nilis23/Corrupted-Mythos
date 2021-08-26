using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Attack State", menuName = "FSM/States/Attack", order = 3)]
public class attackState : State
{
    public State patrolState;

    public override State RunCurrentState()
    {
        //Move into range of the player. Once in range use attack animation. 
        //If the player leaves detection range, swap back to patrol state.
        int colState = executingManager.getCollisionState();
        if(colState == 1)
        {
            return patrolState;
        }

        return this;
    }
}
