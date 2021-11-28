using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Idle State", menuName = "FSM/States/FrostGiant/Idle", order = 1)]
public class FrostIdleState : State
{
    public State FrostChase;
    public override State RunCurrentState(StateManager em)
    {
        int colState = em.getCollisionState();
        if (colState > 0) //If the collision state is greater than 0, transfer to the patrol state
        {
            em.idle = false;
            return FrostChase;
        }


        return null;
    }

    public override void StartState(StateManager em)
    {
        em.idle = true;
    }
}
