using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrostGiantHealth : EnemyHealth
{
    bool inv = true;
    [Space]
    [SerializeField]
    float stagertime;

    private void Start()
    {
        script = gameObject.GetComponent<PlayerMovement>();
    }

    public override void minusHealth(int damage, int knockback = 0)
    {
        if (!inv)
        {
            takeDamage(damage, knockback); //Find a way to make frost giant take less knockback (this will probably be larger overhaul)
            //inv = true;
        }
        else
        {
            //Probably do some fancy flashing to show hes immune?
        }

        if (script != null)
        {
            script.killCount++;
            script.GodBarctrl.IncrementBar(script.GodBarctrl.GetFullSize() / 15);
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
