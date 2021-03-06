using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

[CreateAssetMenu(fileName = "Patrol State", menuName = "FSM/States/Abom/Patrol", order = 2)]
public class patrolState : State
{
    public State chase;
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
        if (Mathf.Abs(em.gameObject.transform.position.x - em.player.transform.position.x) < 6.5f && Mathf.Abs(em.gameObject.transform.position.y - em.player.transform.position.y) < 1f) //The player has entered the second sphere, transfer to attack
        {
            return chase;
        }
        else if(colState < 1)
        {
            em.idle = true;
            return idle;
        }
        
        
        return null;
    }
}
