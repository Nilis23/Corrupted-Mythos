using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

[CreateAssetMenu(fileName = "Attack State", menuName = "FSM/States/Attack", order = 3)]
public class attackState : State
{
    public State patrolState;
    bool atkplaying;

    public override void StartState(StateManager em)
    {
        CreatePath(em, em.player);
    }

    public override State RunCurrentState(StateManager em)
    {
        //Move into range of the player. Once in range use attack animation. 
        //If the player leaves detection range, swap back to patrol state.
        
        int colState = em.getCollisionState();
        if(Vector2.Distance(em.gameObject.transform.position, em.player.transform.position) >= 6.5f) //Needs a fix for when player is destroyed
        {
            return patrolState;
        }
        
        CreatePath(em, em.player);
        //stateDebugInfo();

        return null;
    }

    public override void stateDebugInfo()
    {
        base.stateDebugInfo();
        Debug.Log("Attack anim status: " + atkplaying.ToString());
    }
}
