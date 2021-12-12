using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Chase State", menuName = "FSM/States/FrostGiant/Chase", order = 2)]
public class FrostChaseState : State
{
    public State frostIdle;
    public State frostAttack;
    bool atkplaying;
    float WPDist;
    bool retreating = false;

    public override State RunCurrentState(StateManager em)
    {
        if (em.player != null)
        {
            int colState = em.getCollisionState();
            if (Mathf.Abs(em.gameObject.transform.position.x - em.player.transform.position.x) > 6.5f)
            {
                return frostIdle;
            }

            Debug.Log(Vector2.Distance(em.transform.position, em.player.transform.position));

            if(Vector2.Distance(em.transform.position, em.player.transform.position) < 3.5 && !retreating)
            {
                if((em.transform.position.x - em.player.transform.position.x) > 0)
                {
                    em.nav.target = new Vector2(em.transform.position.x + 6, em.transform.position.y);
                }
                else if ((em.transform.position.x - em.player.transform.position.x) < 0)
                {
                    em.nav.target = new Vector2(em.transform.position.x - 6, em.transform.position.y);
                }

                retreating = true;
            }
            else if(retreating && Mathf.Abs(em.gameObject.transform.position.x - em.player.transform.position.x) > 7f)
            {
                em.SetTarget(em.player);
                retreating = false;
            }

            if (em.attack)
            {
                retreating = false;
                return frostAttack;
            }
        }
        //stateDebugInfo();

        return null;
    }

    public override void StartState(StateManager em)
    {
        em.SetTarget(em.player);
        WPDist = em.nav.nWaypointDistance;
        em.attack = false;
    }
}
