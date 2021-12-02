using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Active State", menuName = "FSM/States/Fireling/Active", order = 2)]
public class FirelingActive : State
{
    public State firelingidle;
    public State firelingflee;

    public override State RunCurrentState(StateManager em)
    {
        int colstate = em.getCollisionState();
        if(colstate < 1)
        {
            return firelingidle;
        }
        else if (Mathf.Abs(em.gameObject.transform.position.x - em.player.transform.position.x) < 4f || Mathf.Abs(em.gameObject.transform.position.y - em.player.transform.position.y) > 1f)
        {
            //Run away
            return firelingflee;
        }

        return null;
    }

    public override void StartState(StateManager em)
    {
        
    }
}
