using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitDetect : MonoBehaviour
{
    public StateManager em;
    public Animator fganim;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" &&  em.stagr <= 0)
        {
            em.attack = true;
            fganim.SetTrigger("Attack");
        }
    }
}
