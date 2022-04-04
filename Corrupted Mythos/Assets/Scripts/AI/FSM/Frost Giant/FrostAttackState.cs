using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Attack State", menuName = "FSM/States/FrostGiant/Attack", order = 3)]
public class FrostAttackState : State
{
    public State idle;
    public float timer;
    float t;
    public override void StartState(StateManager em)
    {
        //Begin the attack
        t = 0;
    }
    public override State RunCurrentState(StateManager em)
    {
        if (t >= timer)
        {
            em.attack = false;
            return idle;
        }

        t += Time.deltaTime;

        return null;
    }
}
