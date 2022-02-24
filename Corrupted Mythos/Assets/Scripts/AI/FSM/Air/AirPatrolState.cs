using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Air Patrol State", menuName = "FSM/States/Air/Patrol", order = 2)]
public class AirPatrolState : State
{
    public State attack;
    public State idle;


    public override void StartState(StateManager em)
    {
        em.SwapTarget();

        return;
    }

    public override State RunCurrentState(StateManager em)
    {
        //Patrol state will walk around once player is within a certian range. Once they are close enough to be detected, and are reachable, the attack state will be entered.
        //stateDebugInfo();

        if (em.nav.getEOP() && em.timer == 0) //If the ai has reached the end of it's path
        {
            if (em.point == 0)
            {
                em.SwapTarget();
            }
            else
            {
                em.SwapTarget();
            }
        }

        int colState = em.getCollisionState();
        if (em.attack) //The player has entered the attack range
        {
            return attack;
        }
        else if (colState < 1)
        {
            em.idle = true;
            return idle;
        }


        return null;
    }
}
