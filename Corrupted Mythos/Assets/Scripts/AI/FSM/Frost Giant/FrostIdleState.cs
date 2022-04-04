using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Idle State", menuName = "FSM/States/FrostGiant/Idle", order = 1)]
public class FrostIdleState : State
{
    public State FrostAttack;
    public override State RunCurrentState(StateManager em)
    {
        int colState = em.getCollisionState();
        if (em.attack) //If the collision state is greater than 0, transfer to the patrol state
        {
            em.idle = false;
            return FrostAttack;
        }


        return null;
    }

    public override void StartState(StateManager em)
    {
        em.idle = true;
    }
}
