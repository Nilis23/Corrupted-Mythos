using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Attack State", menuName = "FSM/States/Abom/Attack", order = 4)]
public class attackState : State
{
    public State chaseState;
    public float timer;
    float t;
    public override void StartState(StateManager em)
    {
        //Begin the attack
        t = 0;
    }
    public override State RunCurrentState(StateManager em)
    {
        if(t >= timer)
        {
            return chaseState;
        }

        t += Time.deltaTime;

        return null;
    }
}
