using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Chase State", menuName = "FSM/States/FrostGiant/Chase", order = 2)]
public class FrostChaseState : State
{
    public State frostIdle;
    //public State frostAttack;
    bool atkplaying;
    float WPDist;

    public override State RunCurrentState(StateManager em)
    {
        if (em.player != null)
        {
            int colState = em.getCollisionState();
            if (Mathf.Abs(em.gameObject.transform.position.x - em.player.transform.position.x) > 6.5f || Mathf.Abs(em.gameObject.transform.position.y - em.player.transform.position.y) > 1f)
            {
                return frostIdle;
            }
            else if (em.attack)
            {
                //return attackState;
            }
        }
        //stateDebugInfo();

        return null;
    }

    public override void StartState(StateManager em)
    {
        em.SetTarget(em.player);
        WPDist = em.nav.nWaypointDistance;
    }
}
