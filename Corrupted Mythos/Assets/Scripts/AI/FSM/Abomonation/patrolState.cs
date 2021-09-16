using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

[CreateAssetMenu(fileName = "Patrol State", menuName = "FSM/States/Patrol", order = 2)]
public class patrolState : State
{
    public State attack;
    public State idle;

    

    public override void StartState(StateManager em)
    {
        if(em.point == 0)
        {
            CreatePath(em, em.pointOne);
            //em.point = 1;
        }
        else
        {
            CreatePath(em, em.pointTwo);
            //em.point = 0;
        }
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
                CreatePath(em, em.pointOne);
                em.point = 1;
            }
            else
            {
                CreatePath(em, em.pointTwo);
                em.point = 0;
            }
        }
        
        int colState = em.getCollisionState();
        if (Vector2.Distance(em.gameObject.transform.position, em.player.transform.position) < 6.5f) //The player has entered the second sphere, transfer to attack
        {
            return attack;
        }
        else if(colState < 1)
        {
            em.idle = true;
            return idle;
        }
        
        
        return null;
    }
}
