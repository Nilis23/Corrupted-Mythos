using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Idle State", menuName = "FSM/States/FrostGiant/Idle", order = 1)]
public class FrostIdleState : State
{
    public override State RunCurrentState(StateManager em)
    {
        return null;
    }

    public override void StartState(StateManager em)
    {
        em.idle = true;
    }
}
