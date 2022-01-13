using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OWFrostGiantHealth : EnemyHealth
{
    bool inv = true;
    [Space]
    [SerializeField]
    float stagertime;
    private int points = 100;

    private void Start()
    {
        script = gameObject.GetComponent<PlayerMovement>();
    }

    public override void minusHealth(int damage, int knockback = 0)
    {
        if (!inv)
        {
            takeDamage(damage, knockback, points); //Find a way to make frost giant take less knockback (this will probably be larger overhaul)
            //inv = true;
        }
        else
        {
            //Probably do some fancy flashing to show hes immune?
        }

        if (script != null)
        {
            script.killCount++;
        }
    }

    public void changeInv()
    {
        inv = false;
        em.setStgr(stagertime, true);
        Invoke("resetInv", stagertime);
    }
    void resetInv()
    {
        inv = true;
    }
}
