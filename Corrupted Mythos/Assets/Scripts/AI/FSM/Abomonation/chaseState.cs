using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

[CreateAssetMenu(fileName = "Chase State", menuName = "FSM/States/Abom/Chase", order = 3)]
public class chaseState : State
{
    public State patrolState;
    public State attackState;
    bool atkplaying;
    float WPDist;

    public override void StartState(StateManager em)
    {
        em.SetTarget(em.player);
        WPDist = em.nav.nWaypointDistance;
        em.attack = false;
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
            else if(em.attack)
            {
                return attackState;
            }
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
