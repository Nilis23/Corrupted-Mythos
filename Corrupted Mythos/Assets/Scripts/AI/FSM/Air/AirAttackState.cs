using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Air Attack State", menuName = "FSM/States/Air/Attack", order = 3)]
public class AirAttackState : State
{
    [SerializeField]
    State Patrol;

    public override State RunCurrentState(StateManager em)
    {
        if(em.attack != true)
        {
            return Patrol;
        }
        else
        {
            return null;
        }
    }

    public override void StartState(StateManager em)
    {
        //Nothing to do
    }
}
