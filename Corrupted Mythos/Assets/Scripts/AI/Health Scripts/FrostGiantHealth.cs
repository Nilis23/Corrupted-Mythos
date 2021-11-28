using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrostGiantHealth : EnemyHealth
{
    bool inv = true;

    public override void minusHealth(int damage, int knockback = 0)
    {
        if (!inv)
        {
            takeDamage(damage, knockback); //Find a way to make frost giant take less knockback (this will probably be larger overhaul)
        }
        else
        {
            //Probably do some fancy flashing to show hes immune?
        }
    }

    public void changeInv()
    {
        inv = false;
        Invoke("resetInv", 1f);
    }
    void resetInv()
    {
        inv = true;
    }
}
