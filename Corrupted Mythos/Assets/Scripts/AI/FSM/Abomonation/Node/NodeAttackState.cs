using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

[CreateAssetMenu(fileName = "Node Attack State", menuName = "FSM/States/Abom/Node Attack", order = 4)]
public class NodeAttackState : State
{
    //public State patrolState;
    bool atkplaying;
    float WPDist;

    public override void StartState(StateManager em)
    {
        em.SetTarget(em.player);
        WPDist = em.nav.nWaypointDistance;
    }

    public override State RunCurrentState(StateManager em)
    {
        //Move into range of the player. Once in range use attack animation. 
        //If the player leaves detection range, swap back to patrol state.

        if (em.player != null)
        {
            float dist = Vector2.Distance(em.gameObject.transform.position, em.player.transform.position);
            /*if (dist >= 6.5f)
            {
                return patrolState;
            }
            We do not exit this state
            */
            
            /*
            if (dist >= WPDist)
            {
                //CreatePath(em, em.player);
            }
            */
        }
        //stateDebugInfo();

        return null;
    }

    public override void stateDebugInfo()
    {
        base.stateDebugInfo();
        Debug.Log("Attack anim status: " + atkplaying.ToString());
    }
}
