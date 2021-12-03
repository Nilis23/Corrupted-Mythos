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
        if(Mathf.Abs(em.gameObject.transform.position.x - em.player.transform.position.x) > 4f || Mathf.Abs(em.gameObject.transform.position.y - em.player.transform.position.y) > 1f)
        {
            (em.hp as FirelingHealth).changeInv();
            return firelingactive;
        }
        return null;
    }

    public override void StartState(StateManager em)
    {
        //Gas mode activate
        (em.hp as FirelingHealth).changeInv();
    }
}
