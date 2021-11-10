using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

[CreateAssetMenu(fileName = "Attack State", menuName = "FSM/States/Abom/Attack", order = 3)]
public class attackState : State
{
    public State patrolState;
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
            int colState = em.getCollisionState();
            if (Mathf.Abs(em.gameObject.transform.position.x - em.player.transform.position.x) > 6.5f || Mathf.Abs(em.gameObject.transform.position.y - em.player.transform.position.y) > 1f)
            {
                return patrolState;
            }
            
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
