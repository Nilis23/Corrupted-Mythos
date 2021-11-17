using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Node Attack State", menuName = "FSM/States/AbomNode/Attack Chase", order = 1)]
public class NodeAttackState : State
{
    public State NodeChaseState;
    public float timer;
    float t;

    public override State RunCurrentState(StateManager em)
    {
        if (t >= timer)
        {
            em.attack = false;
            return NodeChaseState;
        }

        t += Time.deltaTime;

        return null;
    }

    public override void StartState(StateManager em)
    {
        t = 0;
    }
}
