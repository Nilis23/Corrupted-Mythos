using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Flee State", menuName = "FSM/States/Fireling/Flee", order = 2)]
public class FirelingFlee : State
{
    public Vector2 targ;
    public State firelingactive;

    public override State RunCurrentState(StateManager em)
    {
        //At target?
        if(Vector2.Distance(em.transform.position, em.player.transform.position) > 4f)
        {
            (em.hp as OWFirelingHealth).inv = false;
            (em.hp as OWFirelingHealth).animator.SetTrigger("GasLeave");
            em.SetFleeGraphic(false);
            return firelingactive;
        }
        return null;
    }

    public override void StartState(StateManager em)
    {
        //Gas mode activate
        (em.hp as OWFirelingHealth).inv = true;
        (em.hp as OWFirelingHealth).animator.SetTrigger("GasEnter");
        em.SetFleeGraphic(true);
    }
}
