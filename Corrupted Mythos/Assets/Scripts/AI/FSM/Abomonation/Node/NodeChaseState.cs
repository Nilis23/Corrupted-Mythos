using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

[CreateAssetMenu(fileName = "Node Chase State", menuName = "FSM/States/AbomNode/Node Chase", order = 1)]
public class NodeChaseState : State
{
    public State NodeAttackState;
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
            if (dist >= 6.5f)
            {
                em.SetTarget(em.player);
            }
            else if (em.attack)
            {
                return NodeAttackState;
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
