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
        else if (Vector2.Distance(em.transform.position, em.player.transform.position) < 4f)
        {
            //Run away
            return firelingflee;
        }


        em.gameObject.GetComponent<projectileManager>().attemptProjectileLaunch(em.gameObject); //intensive line, ideally once EM is broken up I can store this as a reference 
        return null;
    }

    public override void StartState(StateManager em)
    {
        em.nav.FacePlayer();
    }
}
