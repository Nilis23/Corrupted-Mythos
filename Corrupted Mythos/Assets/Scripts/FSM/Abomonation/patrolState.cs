using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Patrol State", menuName = "FSM/States/Patrol", order = 2)]
public class patrolState : State
{
    public State attack;
    public State idle;
    public override State RunCurrentState()
    {
        //Patrol state will walk around once player is within a certian range. Once they are close enough to be detected, and are reachable, the attack state will be entered.
        Debug.Log("I am in patrol state");

        int colState = executingManager.getCollisionState();
        if (colState > 1) //The player has entered the second sphere, transfer to attack
        {
            return attack;
        }
        else if(colState < 1)
        {
            return idle;
        }
        
        return this;
    }
}
